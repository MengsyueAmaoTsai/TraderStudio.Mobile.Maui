﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using RichillCapital.TraderStudio.Mobile.Services;

namespace RichillCapital.TraderStudio.Mobile.ViewModels;

public abstract partial class ViewModel : 
    ObservableObject, 
    IViewModel
{
    private long _isBusy;

    protected readonly ICurrentUser _currentUser;
    protected readonly INavigationService _nagivationService;

    protected ViewModel(
        ICurrentUser currentUser,
        INavigationService navigationService)
    {
        _currentUser = currentUser;
        _nagivationService = navigationService;

        InitializeAsyncCommand =
            new AsyncRelayCommand(
                async () =>
                {
                    await IsBusyFor(InitializeAsync);
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
    }
    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;
    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    protected virtual Task InitializeAsync() => Task.CompletedTask;

    protected async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }
}
