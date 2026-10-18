using QuizSante.Helpers;

namespace QuizSante.Controls;

public partial class BackHeader : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(BackHeader), null,
        propertyChanged: (b, _, n) => ((BackHeader)b).TitleLabel.Text = n as string);
    public static readonly BindableProperty BackRouteProperty = BindableProperty.Create(nameof(BackRoute), typeof(string), typeof(BackHeader), null,
        propertyChanged: (b, _, n) => Nav.SetTo(((BackHeader)b).BackIcon, n as string));

    public string? Title { get => (string?)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
    public string? BackRoute { get => (string?)GetValue(BackRouteProperty); set => SetValue(BackRouteProperty, value); }

    public BackHeader() => InitializeComponent();
}
