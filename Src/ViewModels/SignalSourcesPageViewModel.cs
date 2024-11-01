using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using RichillCapital.TraderStudio.Mobile.Models;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public sealed class SignalSourcesPageViewModel : ObservableObject
{
    public SignalSourcesPageViewModel()
    {
    }

    public ObservableCollection<SignalSourceModel> SignalSources { get; } = [];
}
