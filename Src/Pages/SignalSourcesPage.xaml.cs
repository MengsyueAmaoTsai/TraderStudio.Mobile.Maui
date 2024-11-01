using RichillCapital.TraderStudio.Mobile.ViewModels;

namespace RichillCapital.TraderStudio.Mobile.Pages;

public sealed partial class SignalSourcesPage : ContentPage
{
    public SignalSourcesPage(SignalSourcesPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}