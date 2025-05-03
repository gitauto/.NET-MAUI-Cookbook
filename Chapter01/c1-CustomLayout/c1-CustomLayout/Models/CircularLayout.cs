using Microsoft.Maui.Layouts;

namespace c1_CustomLayout.Models;

public partial class CircularLayout : Layout
{
    protected override ILayoutManager CreateLayoutManager() => new CircularLayoutManager(this);

    public double Radius
    { 
        get => (double)GetValue(RadiusProperty); 
        set => SetValue(RadiusProperty, value);
    }

    public static readonly BindableProperty RadiusProperty = BindableProperty.Create(nameof(Radius), typeof(double), typeof(CircularLayout));
}
