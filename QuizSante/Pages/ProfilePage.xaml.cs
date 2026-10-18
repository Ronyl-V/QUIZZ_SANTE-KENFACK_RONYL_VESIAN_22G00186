namespace QuizSante.Pages;

public partial class ProfilePage : ContentPage
{
    static readonly Color Active = Color.FromArgb("#4F2E98");
    static readonly Color Idle = Color.FromArgb("#4A4455");

    public ProfilePage() => InitializeComponent();

    // Segment « taille du texte » (visuel uniquement pour l'instant)
    void OnTextSizeTapped(object? sender, TappedEventArgs e)
    {
        bool large = (string)e.Parameter! == "1";
        TextNormal.BackgroundColor = large ? Colors.Transparent : Colors.White;
        TextLarge.BackgroundColor = large ? Colors.White : Colors.Transparent;
        TextNormalLbl.TextColor = large ? Idle : Active;
        TextLargeLbl.TextColor = large ? Active : Idle;
    }

    // Segment « thème » (visuel uniquement : le vrai thème sombre viendra avec le back-end/préférences)
    void OnThemeTapped(object? sender, TappedEventArgs e)
    {
        bool dark = (string)e.Parameter! == "1";
        ThemeLight.BackgroundColor = dark ? Colors.Transparent : Colors.White;
        ThemeDark.BackgroundColor = dark ? Colors.White : Colors.Transparent;
        ThemeLightLbl.Text = dark ? "Clair" : "Clair (Actif)";
        ThemeDarkLbl.Text = dark ? "Sombre (Actif)" : "Sombre";
        ThemeLightLbl.TextColor = ThemeLightIcon.TextColor = dark ? Idle : Active;
        ThemeDarkLbl.TextColor = ThemeDarkIcon.TextColor = dark ? Active : Idle;
    }
}
