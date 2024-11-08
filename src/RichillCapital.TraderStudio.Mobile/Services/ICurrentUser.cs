namespace RichillCapital.TraderStudio.Mobile.Services;

public interface ICurrentUser
{
    bool IsAuthenticated { get; }
    string Id { get; }
    string Name { get; }
    string Email { get; }
}
