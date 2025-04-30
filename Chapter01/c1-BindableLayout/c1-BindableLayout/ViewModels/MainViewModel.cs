using c1_BindableLayout.Models;
using System.Collections.ObjectModel;

namespace c1_BindableLayout.ViewModels;

public class MainViewModel
{
    public ObservableCollection<ActionInfo> DynamicActions { get; set; }

    public MainViewModel()
    {
        DynamicActions = 
        [
            new() { Caption = "Action1" },
            new() { Caption = "Action2" },
            new() { Caption = "Action3" }
        ];
    }
}

