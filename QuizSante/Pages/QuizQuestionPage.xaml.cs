using Microsoft.Maui.Controls.Shapes;
using QuizSante.Controls;

namespace QuizSante.Pages;

public partial class QuizQuestionPage : ContentPage
{
    static readonly string[] Letters = { "A", "B", "C", "D" };
    static readonly string[] Answers =
    {
        "Pratiquer immédiatement le bouche-à-bouche seul",
        "Alerter immédiatement les secours (15, 18 ou 112) et débuter le massage cardiaque",
        "Lui donner un verre d'eau et attendre son réveil",
        "La secouer vigoureusement pour la réveiller",
    };

    readonly List<(Border Card, Border Letter, Label LetterText, Label Text, Border Radio, Ico Tick)> _options = new();
    int _selected = 1;   // état de la maquette : réponse B cochée

    public QuizQuestionPage()
    {
        InitializeComponent();
        for (int i = 0; i < Answers.Length; i++) OptionsHost.Add(BuildOption(i));
        Refresh();
    }

    View BuildOption(int index)
    {
        var letterText = new Label { Text = Letters[index], FontFamily = "InterBold", FontSize = 18, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
        var letter = new Border
        {
            WidthRequest = 44, HeightRequest = 44, StrokeThickness = 0, VerticalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle { CornerRadius = 12 }, Content = letterText
        };
        var text = new Label { Text = Answers[index], FontSize = 16, VerticalOptions = LayoutOptions.Center };
        var tick = new Ico { Name = "check", Size = 16, TextColor = Colors.White };
        var radio = new Border
        {
            WidthRequest = 30, HeightRequest = 30, StrokeThickness = 0, VerticalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle { CornerRadius = 15 }, Content = tick
        };

        var grid = new Grid { ColumnSpacing = 14, ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) } };
        grid.Add(letter); grid.Add(text, 1); grid.Add(radio, 2);

        var card = new Border
        {
            StrokeShape = new RoundRectangle { CornerRadius = 20 },
            Padding = new Thickness(14, 14),
            BackgroundColor = Colors.White,
            Shadow = new Shadow { Brush = new SolidColorBrush(Color.FromArgb("#0B1C30")), Opacity = 0.06f, Radius = 10, Offset = new Point(0, 4) },
            Content = grid
        };
        var tap = new TapGestureRecognizer();
        tap.Tapped += (_, _) => { _selected = index; Refresh(); };
        card.GestureRecognizers.Add(tap);

        _options.Add((card, letter, letterText, text, radio, tick));
        return card;
    }

    void Refresh()
    {
        for (int i = 0; i < _options.Count; i++)
        {
            var o = _options[i];
            bool on = i == _selected;
            o.Card.Stroke = on ? Color.FromArgb("#380F81") : Colors.Transparent;
            o.Card.StrokeThickness = on ? 2 : 0;
            o.Letter.BackgroundColor = on ? Color.FromArgb("#380F81") : Color.FromArgb("#DCE9FF");
            o.LetterText.TextColor = on ? Colors.White : Color.FromArgb("#4A4455");
            o.Text.FontFamily = on ? "InterBold" : "Inter";
            o.Text.TextColor = on ? Color.FromArgb("#380F81") : Color.FromArgb("#0B1C30");
            o.Radio.BackgroundColor = on ? Color.FromArgb("#380F81") : Color.FromArgb("#DCE9FF");
            o.Tick.IsVisible = on;
        }
    }
}
