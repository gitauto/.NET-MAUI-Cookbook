using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace c2_DecoupleViewAndViewModel.ViewModels;

public partial class MainViewModel : INotifyPropertyChanged
{
    private int _count = 0;
    private string _textValue = "Click Me!";

    public MainViewModel()
    {
        UpdateTextCommand = new Command(UpdateText);
    }

    public string TextValue
    {
        get => _textValue;
        set
        {
            _textValue = value;
            OnPropertyChanged();
        }
    }

    public ICommand UpdateTextCommand { get; set; }
    
    public void UpdateText()
    {
        TextValue = $"Clicked {++_count} time{(_count > 1 ? "s":"")}";
    }
    
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
}
