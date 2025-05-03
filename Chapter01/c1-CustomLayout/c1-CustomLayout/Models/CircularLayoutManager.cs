using Microsoft.Maui.Layouts;

namespace c1_CustomLayout.Models;

public class CircularLayoutManager(CircularLayout layout) : ILayoutManager
{
    private readonly CircularLayout parentLayout = layout;

    public Size Measure(double widthConstraint, double heightConstraint)
    {
        for (int n = 0; n < parentLayout.Count; n++)
        {
            var child = parentLayout[n];
            if (child.Visibility == Visibility.Collapsed)
            {
                continue;
            }
            child.Measure(double.PositiveInfinity, double.PositiveInfinity);
        }
        return new Size(parentLayout.WidthRequest, parentLayout.HeightRequest);
    }

    public Size ArrangeChildren(Rect bounds)
    {
        double radius = parentLayout.Radius;
        double angleStep = Math.PI * 2 / parentLayout.Count;

        for (int i = 0; i < parentLayout.Count; i++)
        {
            var child = parentLayout[i];
            if (child.Visibility == Visibility.Collapsed) { continue; }
            
            child.Arrange(new Rect(radius * Math.Cos(angleStep * i) + radius, 
                          radius * Math.Sin(angleStep * i) + radius, 
                          child.DesiredSize.Width, 
                          child.DesiredSize.Height));
        }
        return new Size(parentLayout.WidthRequest, parentLayout.HeightRequest);
    }
}
