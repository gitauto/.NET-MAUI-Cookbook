using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace c2_DecoupleViewAndViewModel.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private int _count;

    [ObservableProperty]
    public partial string TextValue { get; set;  } = "Click Me!";       // <LangVersion>preview</LangVersion> in the project file is required for this to work

    [RelayCommand]
    public void UpdateText()
    {        
        TextValue = $"Clicked {++_count} time{(_count > 1 ? "s" : "")}";
    }
}
