namespace QuizSante.Models;

// ---------------------------------------------------------------------------
//  Données d'exemple (reprises des maquettes). Le back-end les remplacera plus tard :
//  il suffira d'alimenter ces mêmes classes depuis une API ou une base locale (SQLite).
// ---------------------------------------------------------------------------

public record ThemeCard(string Icon, string Duration, string Title, string Description, string QuizCount);

public class HomeViewModel
{
    public List<ThemeCard> Themes { get; } = new()
    {
        new("fire-circle",  "10 min", "Brûlures du quotidien", "Eau tiède 15-15-15, cloques, produits chimiques et pièges à éviter.", "3 quiz pratiques"),
        new("bed",          "8 min",  "Malaises & PLS",        "Reconnaître un malaise, installer la victime en sécurité.",             "3 quiz pratiques"),
        new("water",        "12 min", "Hémorragies & Garrot",  "Compression directe, pansement compressif et garrot en dernier recours.", "3 quiz pratiques"),
    };
}

public class CatalogItem
{
    public string Tag { get; set; } = "";
    public Color TagBg { get; set; } = Colors.Transparent;
    public Color TagFg { get; set; } = Colors.Black;
    public string StatusIcon { get; set; } = "check-circle-outline";
    public Color StatusColor { get; set; } = Colors.Green;
    public string Icon { get; set; } = "";
    public Color IconBg { get; set; } = Colors.Transparent;
    public Color IconFg { get; set; } = Colors.Black;
    public string Title { get; set; } = "";
    public string Meta { get; set; } = "";
    public double Progress { get; set; }
    public string ButtonText { get; set; } = "Démarrer";
    public string ButtonIcon { get; set; } = "play-outline";
    public Color ButtonBg { get; set; } = Color.FromArgb("#4F2E98");
    public Color ButtonFg { get; set; } = Colors.White;
}

public record MemoItem(string Icon, Color IconBg, Color IconFg, string Title, string Description, string Duration,
                       string Footer, bool FooterIsAlert, string ButtonText, bool Primary);

public record MemoRow(string Icon, string Title, string Description, string Tag, string Duration);

public record BadgeItem(string Icon, Color IconBg, Color IconFg, string Name, string Status, Color StatusColor, bool Locked)
{
    public Color CardBg => Locked ? Color.FromArgb("#E9F0FF") : Colors.White;
    public double Fade => Locked ? 0.75 : 1.0;
}
