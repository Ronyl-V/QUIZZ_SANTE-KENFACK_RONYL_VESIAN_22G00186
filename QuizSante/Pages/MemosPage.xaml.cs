using QuizSante.Models;

namespace QuizSante.Pages;

public partial class MemosPage : ContentPage
{
    static Color C(string hex) => Color.FromArgb(hex);

    public record UrgentMemo(string Icon, Color IconBg, Color IconFg, string Title, string Description, string Duration,
                             string Footer, Color FooterColor, string ButtonText, Color ButtonBg, Color ButtonFg);

    public List<UrgentMemo> Urgent { get; }
    public List<MemoRow> Others { get; }

    public MemosPage()
    {
        InitializeComponent();

        Urgent = new()
        {
            new("pulse", C("#FFDAD6"), C("#BA1A1A"), "Arrêt cardiaque : Massage & DAE", "Protocole 30:2, pose des électrodes et...", "2 min",
                "100 à 120 bpm", C("#00531F"), "Action immédiate", C("#4F2E98"), Colors.White),
            new("weather-windy", C("#DDE1FF"), C("#2B3EB5"), "Étouffement adulte et enfant (Heimlich)", "5 claques dans le dos puis compressions...", "1 min",
                "Obstruction totale", C("#BA1A1A"), "Consulter", C("#DCE9FF"), C("#380F81")),
            new("asterisk", C("#FFDAD6"), C("#BA1A1A"), "Signes d'un AVC (FAST : Visage, Bras, Parole)", "Repérer la déviation faciale, faiblesse...", "2 min",
                "Heure d'apparition cruciale", C("#4A4455"), "Consulter", C("#DCE9FF"), C("#380F81")),
        };

        Others = new()
        {
            new("bed", "Position Latérale de Sécurité (PLS)", "Mise en sécurité complète d'une victime inconsciente", "• 4 étapes clés", "• 2 min"),
            new("fire", "Brûlure thermique ou chimique", "Refroidir sous eau tiède sans glaçon", "• Règle 15-15-15", "• 1 min"),
            new("head-cog", "Crise convulsive / Épilepsie", "Protéger la boîte crânienne, ne rien introduire", "• Gestes protecteurs", "• 1 min"),
            new("water-plus", "Saignement de nez et plaies", "Tête penchée en avant, pression ferme", "• Compression directe", "• 2 min"),
            new("bug-outline", "Piqûres & réactions anaphylactiques", "Reconnaître l'œdème de Quincke et agir", "• Stylo auto-injecteur", "• 2 min"),
        };

        BindingContext = this;
    }
}
