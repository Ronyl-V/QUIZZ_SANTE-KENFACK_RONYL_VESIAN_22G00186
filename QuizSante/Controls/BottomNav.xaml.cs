using QuizSante.Helpers;

namespace QuizSante.Controls;

public partial class BottomNav : ContentView
{
    static readonly (string Route, string Icon, string IconActive, string Label)[] Items =
    {
        ("home",     "home-outline",                    "home",                    "Accueil"),
        ("catalog",  "frequently-asked-questions",      "frequently-asked-questions",                "Quiz"),
        ("memos",    "book-open-page-variant-outline",  "book-open-page-variant",  "Fiches"),
        ("progress", "chart-timeline-variant-shimmer",  "chart-timeline-variant-shimmer", "Progression"),
        ("profile",  "account-circle-outline",          "account-circle",          "Profil"),
    };

    public static readonly BindableProperty ActiveProperty = BindableProperty.Create(
        nameof(Active), typeof(string), typeof(BottomNav), "home", propertyChanged: (b, _, _) => ((BottomNav)b).Build());

    public string Active { get => (string)GetValue(ActiveProperty); set => SetValue(ActiveProperty, value); }

    public BottomNav()
    {
        InitializeComponent();
        Build();
    }

    void Build()
    {
        Row.Children.Clear();
        for (int i = 0; i < Items.Length; i++)
        {
            var (route, icon, iconActive, label) = Items[i];
            bool on = route == Active;
            var color = on ? Color.FromArgb("#380F81") : Color.FromArgb("#4A4455");

            var stack = new VerticalStackLayout { Spacing = 3, HorizontalOptions = LayoutOptions.Fill };
            stack.Add(new Ico { Name = on ? iconActive : icon, Size = 26, TextColor = color });
            stack.Add(new Label
            {
                Text = label,
                FontFamily = on ? "InterBold" : "InterSemi",
                FontSize = 12,
                TextColor = color,
                HorizontalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.NoWrap
            });
            Nav.SetTo(stack, route);
            Grid.SetColumn(stack, i);
            Row.Children.Add(stack);
        }
    }
}
