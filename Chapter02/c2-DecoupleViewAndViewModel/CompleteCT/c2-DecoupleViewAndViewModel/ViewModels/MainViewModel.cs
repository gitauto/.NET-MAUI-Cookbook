using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace c2_DecoupleViewAndViewModel.ViewModels;

// https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm-community-toolkit-features#observableobject

public partial class MainViewModel : ObservableObject
{
    private int _count = 0;

    public ICommand UpdateTextCommand { get; set; }

    public MainViewModel()
    {
        UpdateTextCommand = new Command(UpdateText);
    }

    [ObservableProperty]
    public partial string TextValue { get; set; } = "Click Me!";        // <LangVersion>preview</LangVersion> in the project file is required for this to work

    public void UpdateText()
    {
        TextValue = $"Clicked {++_count} time{(_count > 1 ? "s":"")}";
    }
}
