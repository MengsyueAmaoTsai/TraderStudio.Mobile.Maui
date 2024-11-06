namespace RichillCapital.TraderStudio.Mobile.Services.CurrentUser;

public interface ICurrentUser
{
    bool IsAuthenticated { get; }
    string Id { get; }
    string Name { get; }
    string Email { get; }
}