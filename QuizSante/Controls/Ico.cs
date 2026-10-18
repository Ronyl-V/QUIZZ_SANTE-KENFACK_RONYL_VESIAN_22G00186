using QuizSante.Helpers;

namespace QuizSante.Controls;

/// <summary>Icône Material Design Icons : &lt;c:Ico Name="home-outline" Size="22" TextColor="..." /&gt;</summary>
public class Ico : Label
{
    public static readonly BindableProperty NameProperty = BindableProperty.Create(
        nameof(Name), typeof(string), typeof(Ico), null,
        propertyChanged: (b, _, n) => ((Ico)b).Text = Icons.Get(n as string));

    public string? Name
    {
        get => (string?)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public double Size
    {
        get => FontSize;
        set => FontSize = value;
    }

    public Ico()
    {
        FontFamily = "MDI";
        FontSize = 22;
        HorizontalTextAlignment = TextAlignment.Center;
        VerticalTextAlignment = TextAlignment.Center;
        LineBreakMode = LineBreakMode.NoWrap;
        HorizontalOptions = LayoutOptions.Center;
        VerticalOptions = LayoutOptions.Center;
    }
}
