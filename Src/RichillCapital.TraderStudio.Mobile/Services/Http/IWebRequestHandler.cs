using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.TraderStudio.Mobile.Services.Http;

public interface IWebRequestHandler
{
    Task<Result<TResponse>> GetAsync<TResponse>(string uri);
}
