using Android.App;
using Android.Content.PM;

namespace RichillCapital.TraderStudio.Mobile;

[Activity(
    NoHistory = true, 
    LaunchMode = LaunchMode.SingleTop, 
    Exported = true)]
[IntentFilter(
    [Android.Content.Intent.ActionView],
    Categories = [Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable],
    DataScheme = "myapp",
    DataHost = "callback")]
public class AuthenticationCallbackActivity : 
    WebAuthenticatorCallbackActivity
{
}