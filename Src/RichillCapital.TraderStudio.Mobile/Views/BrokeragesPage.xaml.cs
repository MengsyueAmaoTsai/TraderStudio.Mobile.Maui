using RichillCapital.TraderStudio.Mobile.ViewModels;

namespace RichillCapital.TraderStudio.Mobile.Views;

public sealed partial class BrokeragesPage : ContentPage
{
    public BrokeragesPage(BrokeragesViewModel viewModel)
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