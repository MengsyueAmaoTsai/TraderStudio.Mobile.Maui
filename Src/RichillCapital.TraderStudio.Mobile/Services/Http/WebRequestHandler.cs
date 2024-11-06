using System.Net.Http.Headers;
using System.Net.Http.Json;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.TraderStudio.Mobile.Services.Http;

internal sealed class WebRequestHandler : IWebRequestHandler
{
    private readonly Lazy<HttpClient> _httpClient = new(() =>
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true
            };

            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        },
        LazyThreadSafetyMode.ExecutionAndPublication);
    
    public async Task<Result<TResponse>> GetAsync<TResponse>(string uri)
    {
        var client = GetOrCreateHttpClient();
        
        try
        {
            var response = await client.GetAsync(uri, cancellationToken: default);

            var maybeError = await HandleResponseAsync(response);

            if (maybeError.HasValue)
            {
                return Result<TResponse>.Failure(maybeError.Value);
            }

            var typedResponse = await response.Content.ReadFromJsonAsync<TResponse>();

            return Result<TResponse>.With(typedResponse!);
        }
        catch (Exception ex)
        {
            return Result<TResponse>.Failure(Error.Unexpected($"{ex}"));
        }
    }

    private static async Task<Maybe<Error>> HandleResponseAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken = default)
    {
        if (response.IsSuccessStatusCode)
        {
            return Maybe<Error>.Null;
        }

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        var error = Error.Unexpected("Response is error");

        return Maybe<Error>.With(error);
    }
    private HttpClient GetOrCreateHttpClient()
    {
        var client = _httpClient.Value;

        return client;
    }
}
