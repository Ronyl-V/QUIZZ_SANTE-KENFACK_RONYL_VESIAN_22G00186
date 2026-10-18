using Microsoft.Maui.Controls.Shapes;

namespace QuizSante.Controls;

/// <summary>Barre de progression arrondie : &lt;c:Bar Progress="0.6" FillColor="..." TrackColor="..." HeightRequest="8" /&gt;</summary>
public class Bar : ContentView
{
    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(double), typeof(Bar), 0.0,
        propertyChanged: (b, _, _) => ((Bar)b).Update());
    public static readonly BindableProperty FillColorProperty = BindableProperty.Create(nameof(FillColor), typeof(Color), typeof(Bar), Color.FromArgb("#4F2E98"),
        propertyChanged: (b, _, _) => ((Bar)b).Update());
    public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(Bar), Color.FromArgb("#D3E4FE"),
        propertyChanged: (b, _, _) => ((Bar)b).Update());
    public static readonly BindableProperty FillBrushProperty = BindableProperty.Create(nameof(FillBrush), typeof(Brush), typeof(Bar), null,
        propertyChanged: (b, _, _) => ((Bar)b).Update());

    public double Progress { get => (double)GetValue(ProgressProperty); set => SetValue(ProgressProperty, value); }
    public Color FillColor { get => (Color)GetValue(FillColorProperty); set => SetValue(FillColorProperty, value); }
    public Color TrackColor { get => (Color)GetValue(TrackColorProperty); set => SetValue(TrackColorProperty, value); }
    public Brush? FillBrush { get => (Brush?)GetValue(FillBrushProperty); set => SetValue(FillBrushProperty, value); }

    readonly Border _track = new() { StrokeThickness = 0, StrokeShape = new RoundRectangle { CornerRadius = 99 } };
    readonly Border _fill = new() { StrokeThickness = 0, StrokeShape = new RoundRectangle { CornerRadius = 99 } };
    readonly Grid _grid = new();

    public Bar()
    {
        HeightRequest = 8;
        _grid.ColumnDefinitions.Add(new ColumnDefinition());
        _grid.ColumnDefinitions.Add(new ColumnDefinition());
        _grid.Children.Add(_track);
        Grid.SetColumnSpan(_track, 2);
        _grid.Children.Add(_fill);
        Content = _grid;
        Update();
    }

    void Update()
    {
        double p = Math.Clamp(Progress, 0, 1);
        _grid.ColumnDefinitions[0].Width = new GridLength(Math.Max(p, 0.0001), GridUnitType.Star);
        _grid.ColumnDefinitions[1].Width = new GridLength(Math.Max(1 - p, 0.0001), GridUnitType.Star);
        _track.BackgroundColor = TrackColor;
        if (FillBrush is not null) _fill.Background = FillBrush; else _fill.BackgroundColor = FillColor;
        _fill.IsVisible = p > 0;
    }
}
