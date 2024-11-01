using RichillCapital.TraderStudio.Mobile.Pages;

namespace RichillCapital.TraderStudio.Mobile;

public sealed partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SignalSourcesPage));
    }
}

