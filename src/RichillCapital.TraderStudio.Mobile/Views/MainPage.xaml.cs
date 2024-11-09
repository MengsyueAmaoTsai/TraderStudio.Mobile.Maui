using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

using RichillCapital.TraderStudio.Mobile.ViewModels;

namespace RichillCapital.TraderStudio.Mobile.Views;

public sealed partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IViewModel viewModel)
        {
            return;
        }

        await viewModel.InitializeAsyncCommand.ExecuteAsync(null);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("Hello world", ToastDuration.Long, 30);
        toast.Show(default);
    }
}
