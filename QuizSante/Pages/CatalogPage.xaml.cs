using QuizSante.Models;

namespace QuizSante.Pages;

public partial class CatalogPage : ContentPage
{
    public List<CatalogItem> Items { get; }
    readonly List<(Border Chip, Label Text)> _filters = new();

    static Color C(string hex) => Color.FromArgb(hex);

    public CatalogPage()
    {
        InitializeComponent();

        var urgenceBg = C("#FFDAD6"); var urgenceFg = C("#93000A");
        var maladieBg = C("#DCE9FF"); var maladieFg = C("#2B3A67");
        var secoursBg = C("#E9DDFF"); var secoursFg = C("#4F2E98");
        var enfantsBg = C("#DDE1FF"); var enfantsFg = C("#2B3EB5");
        var ok = C("#00531F"); var dl = C("#7B7487");

        Items = new List<CatalogItem>
        {
            new() { Tag="Urgence vitale", TagBg=urgenceBg, TagFg=urgenceFg, StatusIcon="check-circle-outline", StatusColor=ok,
                    Icon="heart-pulse", IconBg=C("#FFE8E6"), IconFg=C("#BA1A1A"), Title="Arrêt cardiaque & RCP", Meta="4 quiz • Débutant", Progress=0.75 },
            new() { Tag="Urgence vitale", TagBg=urgenceBg, TagFg=urgenceFg, StatusIcon="check-circle-outline", StatusColor=ok,
                    Icon="weather-windy", IconBg=C("#DDE6FF"), IconFg=C("#3B55C9"), Title="Étouffement & Heimlich", Meta="3 quiz • Débutant", Progress=0.35 },
            new() { Tag="Maladies", TagBg=maladieBg, TagFg=maladieFg, StatusIcon="check-circle-outline", StatusColor=ok,
                    Icon="head-cog", IconBg=C("#DDE1FF"), IconFg=C("#2B3EB5"), Title="AVC & Méthode FAST", Meta="4 quiz • Intermédiaire", Progress=0.50 },
            new() { Tag="1ers secours", TagBg=secoursBg, TagFg=secoursFg, StatusIcon="download-circle-outline", StatusColor=dl,
                    Icon="fire", IconBg=C("#E6EAFF"), IconFg=C("#4F2E98"), Title="Brûlures & Traumatismes", Meta="3 quiz • Débutant", Progress=0.0 },
            new() { Tag="Urgence", TagBg=urgenceBg, TagFg=urgenceFg, StatusIcon="check-circle-outline", StatusColor=ok,
                    Icon="water", IconBg=C("#FFE8E6"), IconFg=C("#BA1A1A"), Title="Hémorragies & Garrot", Meta="3 quiz • Intermédiaire", Progress=1.0,
                    ButtonText="Revoir", ButtonIcon="refresh", ButtonBg=C("#EFF4FF"), ButtonFg=C("#4F2E98") },
            new() { Tag="1ers secours", TagBg=secoursBg, TagFg=secoursFg, StatusIcon="check-circle-outline", StatusColor=ok,
                    Icon="bed", IconBg=C("#E6EAFF"), IconFg=C("#4F2E98"), Title="Malaises & PLS", Meta="3 quiz • Débutant", Progress=0.70 },
            new() { Tag="Maladies", TagBg=maladieBg, TagFg=maladieFg, StatusIcon="check-circle-outline", StatusColor=ok,
                    Icon="thermometer", IconBg=C("#E6EAFF"), IconFg=C("#4F2E98"), Title="Paludisme & Fièvre", Meta="4 quiz • Débutant", Progress=0.22 },
            new() { Tag="Enfants", TagBg=enfantsBg, TagFg=enfantsFg, StatusIcon="cloud-download-outline", StatusColor=dl,
                    Icon="lungs", IconBg=C("#E6EAFF"), IconFg=C("#4F2E98"), Title="Crise d'asthme & Allergies", Meta="3 quiz • Avancé", Progress=0.0 },
        };

        BuildFilters(new[] { "Tous (16)", "Premiers secours", "Maladies courantes", "Enfants" });
        BindingContext = this;
    }

    void BuildFilters(string[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            var text = new Label { Text = names[i], FontFamily = "InterBold", FontSize = 14, VerticalOptions = LayoutOptions.Center };
            var chip = new Border
            {
                StrokeThickness = 0,
                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 20 },
                Padding = new Thickness(18, 11),
                Content = text
            };
            int index = i;
            var tap = new TapGestureRecognizer();
            tap.Tapped += (_, _) => SelectFilter(index);
            chip.GestureRecognizers.Add(tap);
            _filters.Add((chip, text));
            FilterRow.Children.Add(chip);
        }
        SelectFilter(0);
    }

    void SelectFilter(int selected)
    {
        for (int i = 0; i < _filters.Count; i++)
        {
            bool on = i == selected;
            _filters[i].Chip.BackgroundColor = on ? C("#4F2E98") : C("#E4EBFC");
            _filters[i].Text.TextColor = on ? Colors.White : C("#33304A");
        }
    }
}
