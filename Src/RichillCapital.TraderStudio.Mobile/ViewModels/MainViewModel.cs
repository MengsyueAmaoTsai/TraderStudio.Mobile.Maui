using IdentityModel.Client;
using IdentityModel.OidcClient;

using RichillCapital.TraderStudio.Mobile.Services.CurrentUser;
using RichillCapital.TraderStudio.Mobile.Services.Dialog;
using RichillCapital.TraderStudio.Mobile.Services.Navigation;
using RichillCapital.TraderStudio.Mobile.Views.Controls;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed partial class MainViewModel : ViewModel
{
    private readonly ICurrentUser _currentUser;

    public MainViewModel(
        INavigationService navigationService,
        IDialogService dialogService,
        ICurrentUser currentUser)
        : base(navigationService, dialogService)
    {
        _currentUser = currentUser;
    }

    protected override async Task InitializeAsync() =>
        await IsBusyFor(async () =>
        {
            if (_currentUser.IsAuthenticated)
            {
                await _dialogService.ShowAlertAsync("Error", "User is already authenticated", "Ok");
                return;
            }

            var oidcClient = new OidcClient(new()
            {
                Authority = "https://10.0.2.2:9999",
                ClientId = "RichillCapital.TraderStudio.Mobile",
                ClientSecret = "secret",
                Scope = "openid offline_access",
                RedirectUri = "myapp://callback",
                Browser = new AuthenticationBrowser(),
                BackchannelHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                },
                Policy = new Policy
                {
                    Discovery = new DiscoveryPolicy
                    {
                        ValidateIssuerName = false,
                    },
                },
            });

            var result = await oidcClient.LoginAsync();

            if (result.IsError)
            {
                await _dialogService.ShowAlertAsync("Error", $"{result.Error} -> {result.ErrorDescription}", "Ok");
                return;
            }

            var accessToken = result.AccessToken;
            var refreshToken = result.RefreshToken;

            var claimsString = result.User.Claims.Select(c => $"{c.Type}: {c.Value}").Aggregate((c1, c2) => $"{c1}\n{c2}");

            await _dialogService.ShowAlertAsync("Success", $"Successfully initialized the app, AccessToken: {accessToken}, RefreshToken: {refreshToken}", "Ok");
            await _dialogService.ShowAlertAsync("Success", $"Successfully authenticated the user, {claimsString}", "Ok");
        });
}
