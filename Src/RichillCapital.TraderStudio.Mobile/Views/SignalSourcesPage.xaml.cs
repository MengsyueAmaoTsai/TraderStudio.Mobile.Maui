using RichillCapital.TraderStudio.Mobile.ViewModels;

namespace RichillCapital.TraderStudio.Mobile.Views;

public sealed partial class SignalSourcesPage : ContentPage
{
	public SignalSourcesPage(SignalSourcesViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is IViewModel viewModel)
        {
            viewModel.InitializeAsyncCommand.Execute(null);
        };
    }
}