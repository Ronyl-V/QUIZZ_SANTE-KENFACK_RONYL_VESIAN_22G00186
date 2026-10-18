namespace QuizSante.Pages;

public partial class LoginPage : ContentPage
{
    bool _remember = true;

    public LoginPage() => InitializeComponent();

    void OnRememberTapped(object? sender, TappedEventArgs e)
    {
        _remember = !_remember;
        RememberBox.BackgroundColor = _remember ? Color.FromArgb("#380F81") : Color.FromArgb("#DCE9FF");
        RememberTick.IsVisible = _remember;
    }
}
