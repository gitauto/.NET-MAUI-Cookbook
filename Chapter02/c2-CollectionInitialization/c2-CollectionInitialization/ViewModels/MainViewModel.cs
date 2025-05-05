using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace c2_DecoupleViewAndViewModel.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private ObservableCollection<Customer>? _customers;
    public ObservableCollection<Customer>? Customers
    {
        get => _customers;
        set => SetProperty(ref _customers, value);
    }

    private bool _isInitialized;
    public bool IsInitialized
    {
        get => _isInitialized;
        set
        {
            if (SetProperty(ref _isInitialized, value))
            {
                InitializeCommand.NotifyCanExecuteChanged();
            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanInitialize))]
    async Task InitializeAsync()
    {
        _customers = [.. await DummyService.GetCustomersAsync()];
        _isInitialized = true;
    }
    bool CanInitialize() => !_isInitialized;
}
public class Customer
{
    public int ID
    {
        get;
        set;
    }
    public string? Name
    {
        get;
        set;
    }
}

public static class DummyService
{
    public static async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        await Task.Delay(5000);
        return [new Customer(){ ID = 1, Name = "Jim" }, new Customer(){ ID = 2, Name = "Bob" }];
    }
}
