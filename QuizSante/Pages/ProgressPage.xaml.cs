using QuizSante.Models;

namespace QuizSante.Pages;

public partial class ProgressPage : ContentPage
{
    static Color C(string hex) => Color.FromArgb(hex);

    public List<BadgeItem> Badges { get; } = new()
    {
        new("professional-hexagon", C("#FDF1C4"), C("#D97706"), "Premier Geste", "Obtenu", C("#00531F"), false),
        new("fire",                 C("#FFF1E3"), C("#F97316"), "Flamme 7j",     "5 / 7 j", C("#EA580C"), false),
        new("heart",                C("#FFDDE3"), C("#E11D48"), "Maître Réa",    "Obtenu", C("#00531F"), false),
        new("shield",               C("#E9DDFF"), C("#4F2E98"), "Prot. AVC",     "Obtenu", C("#00531F"), false),
        new("star-outline",         C("#DCE9FF"), C("#7B7487"), "Sans Faute",    "🔒 Bloqué", C("#7B7487"), true),
        new("cloud-sync-outline",   C("#C9F6EA"), C("#0F766E"), "Hors-ligne",    "Obtenu", C("#00531F"), false),
    };

    public ProgressPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
