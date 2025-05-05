using c2_DecoupleViewAndViewModel.Models;
using c2_DecoupleViewAndViewModel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace c2_DecoupleViewAndViewModel.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial ObservableCollection<Customer>? Customers { get; set; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(InitializeCommand))]
    public partial bool IsInitialized { get; set; }

    [RelayCommand(CanExecute = nameof(CanInitialize))]
    async Task InitializeAsync()
    {
        Customers = [.. await DummyService.GetCustomersAsync()];
        IsInitialized = true;
    }

    bool CanInitialize() => !IsInitialized;
}
