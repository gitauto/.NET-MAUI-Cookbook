using c2_DecoupleViewAndViewModel.Models;
using c2_DecoupleViewAndViewModel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace c2_DecoupleViewAndViewModel.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial ObservableCollection<Customer>? Customers { get; set; }      // <LangVersion>preview</LangVersion> in the project file is required for this to work

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(InitializeCommand))]
    public partial bool IsInitialized { get; set; }                             // <LangVersion>preview</LangVersion> in the project file is required for this to work

    [RelayCommand(CanExecute = nameof(CanInitialize))]
    private async Task InitializeAsync()
    {
        Customers = [.. await DummyService.GetCustomersAsync()];
        IsInitialized = true;
    }

    private bool CanInitialize() => !IsInitialized;
}
