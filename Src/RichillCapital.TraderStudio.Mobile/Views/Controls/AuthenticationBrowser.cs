using IdentityModel.Client;
using IdentityModel.OidcClient.Browser;

using IBrowser = IdentityModel.OidcClient.Browser.IBrowser;

namespace RichillCapital.TraderStudio.Mobile.Views.Controls;

internal sealed class AuthenticationBrowser : IBrowser
{
    public async Task<BrowserResult> InvokeAsync(
        BrowserOptions options, 
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await WebAuthenticator.Default.AuthenticateAsync(
                new Uri(options.StartUrl),
                new Uri(options.EndUrl));

            var url = new RequestUrl("myapp://callback")
                .Create(new Parameters(result.Properties));

            return new BrowserResult
            {
                Response = url,
                ResultType = BrowserResultType.Success,
            };
        }
        catch (TaskCanceledException)
        {
            return new BrowserResult
            {
                ResultType = BrowserResultType.UserCancel
            };
        }
    }
}