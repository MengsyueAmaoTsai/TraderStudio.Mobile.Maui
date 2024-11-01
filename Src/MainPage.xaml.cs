namespace RichillCapital.TraderStudio.Mobile;

public sealed partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}

