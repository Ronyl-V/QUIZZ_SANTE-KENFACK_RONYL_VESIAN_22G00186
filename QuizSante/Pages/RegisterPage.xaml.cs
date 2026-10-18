using System.Text.RegularExpressions;

namespace QuizSante.Pages;

public partial class RegisterPage : ContentPage
{
    static readonly Color Primary = Color.FromArgb("#4F2E98");
    bool _consent = true;

    public RegisterPage() => InitializeComponent();

    void OnAgeTapped(object? sender, TappedEventArgs e)
    {
        int selected = int.Parse((string)e.Parameter!);
        var boxes = new[] { Age0, Age1, Age2 };
        for (int i = 0; i < boxes.Length; i++)
        {
            bool on = i == selected;
            boxes[i].BackgroundColor = on ? Primary : Colors.White;
            ((Label)boxes[i].Content!).TextColor = on ? Colors.White : Color.FromArgb("#0B1C30");
        }
    }

    void OnConsentTapped(object? sender, TappedEventArgs e)
    {
        _consent = !_consent;
        ConsentBox.BackgroundColor = _consent ? Primary : Color.FromArgb("#DCE9FF");
        ConsentTick.IsVisible = _consent;
    }

    // Jauge de sécurité du mot de passe (affichage uniquement, la validation viendra avec le back-end).
    void OnPasswordChanged(object? sender, TextChangedEventArgs e)
    {
        string p = e.NewTextValue ?? "";
        int score = 0;
        if (p.Length >= 8) score++;
        if (Regex.IsMatch(p, "[A-Z]") && Regex.IsMatch(p, "[a-z]")) score++;
        if (Regex.IsMatch(p, "[0-9]")) score++;
        if (Regex.IsMatch(p, "[^A-Za-z0-9]")) score++;

        (string label, double pct, string color) = score switch
        {
            0 => ("Très faible", 0.10, "#BA1A1A"),
            1 => ("Faible", 0.25, "#BA1A1A"),
            2 => ("Moyen", 0.50, "#F59E0B"),
            3 => ("Correct", 0.75, "#00531F"),
            _ => ("Excellent", 1.00, "#00531F"),
        };
        StrengthText.Text = label;
        StrengthText.TextColor = Color.FromArgb(color);
        StrengthPct.Text = $"{(int)(pct * 100)}%";
        StrengthPct.TextColor = Color.FromArgb(color);
        StrengthBar.FillColor = Color.FromArgb(color);
        StrengthBar.Progress = pct;
    }
}
