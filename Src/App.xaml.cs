namespace RichillCapital.TraderStudio.Mobile;

public sealed partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
