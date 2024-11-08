namespace RichillCapital.TraderStudio.Mobile.Services;

internal sealed class CurrentUser : ICurrentUser
{
    public bool IsAuthenticated => true;
    public string Id => "UID0000001";
    public string Name => "Mengsyue Amao Tsai";
    public string Email => "mengsyue.tsai@outlook.com";
}
