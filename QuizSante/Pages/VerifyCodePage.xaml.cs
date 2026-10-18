using System.Text.RegularExpressions;
using QuizSante.Controls;

namespace QuizSante.Pages;

public partial class VerifyCodePage : ContentPage
{
    readonly Border[] _boxes = new Border[6];
    readonly Label[] _digits = new Label[6];
    IDispatcherTimer? _timer;
    int _seconds = 47;

    public VerifyCodePage()
    {
        InitializeComponent();
        BuildCodeBoxes();
        CodeEntry.Text = "849";              // état de la maquette
        OnPwdChanged(null, null!);
    }

    void BuildCodeBoxes()
    {
        for (int i = 0; i < 6; i++)
        {
            var label = new Label
            {
                Text = "•",
                FontFamily = "InterXBold",
                FontSize = 28,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromArgb("#7B7487")
            };
            var box = new Border
            {
                HeightRequest = 62,
                StrokeThickness = 0,
                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 14 },
                BackgroundColor = Color.FromArgb("#EFF4FF"),
                Content = label
            };
            var tap = new TapGestureRecognizer();
            tap.Tapped += (_, _) => CodeEntry.Focus();
            box.GestureRecognizers.Add(tap);
            _boxes[i] = box;
            _digits[i] = label;
            Grid.SetColumn(box, i);
            CodeRow.Children.Add(box);
        }
    }

    void OnCodeChanged(object? sender, TextChangedEventArgs e)
    {
        string code = Regex.Replace(e.NewTextValue ?? "", "[^0-9]", "");
        for (int i = 0; i < 6; i++)
        {
            bool filled = i < code.Length;
            _digits[i].Text = filled ? code[i].ToString() : "•";
            _digits[i].TextColor = filled ? Color.FromArgb("#380F81") : Color.FromArgb("#7B7487");
            _boxes[i].BackgroundColor = i == Math.Min(code.Length, 5) ? Color.FromArgb("#E9DDFF") : Color.FromArgb("#EFF4FF");
        }
    }

    void OnPwdChanged(object? sender, TextChangedEventArgs e)
    {
        string a = Pwd1.Text ?? "", b = Pwd2.Text ?? "";
        SetCrit(Crit0, a.Length >= 8);
        SetCrit(Crit1, Regex.IsMatch(a, "[A-Z]") && Regex.IsMatch(a, "[a-z]"));
        SetCrit(Crit2, Regex.IsMatch(a, "[0-9]") && Regex.IsMatch(a, "[^A-Za-z0-9]"));
        SetCrit(Crit3, a.Length > 0 && a == b);
    }

    static void SetCrit(Ico icon, bool ok)
    {
        icon.Name = ok ? "check-circle" : "circle-outline";
        icon.TextColor = ok ? Color.FromArgb("#8FF7A2") : Color.FromArgb("#7B7487");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _seconds = 47;
        _timer ??= Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick -= OnTick;
        _timer.Tick += OnTick;
        _timer.Start();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _timer?.Stop();
    }

    void OnTick(object? sender, EventArgs e)
    {
        if (_seconds > 0) _seconds--;
        TimerSpan.Text = _seconds > 0 ? $"{_seconds}s" : "maintenant";
    }
}
