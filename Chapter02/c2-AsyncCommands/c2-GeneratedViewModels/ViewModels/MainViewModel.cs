using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace c2_DecoupleViewAndViewModel.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand(IncludeCancelCommand = true)]
    public static async Task UpdateTextAsync(CancellationToken token)
    {
        try
        {
            Debug.WriteLine("UpdateTextAsync started.");
            await Task.Delay(5000, token);
            Debug.WriteLine("UpdateTextAsync completed.");
        }
        catch (OperationCanceledException)
        {
            Debug.WriteLine("UpdateTextAsync was cancelled | OperationCanceledException");
            return;
        }
        //other logic
    }
}
