using QuizSante.Helpers;

namespace QuizSante.Controls;

public partial class SessionHeader : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SessionHeader), "Session Quiz",
        propertyChanged: (b, _, n) => ((SessionHeader)b).TitleLabel.Text = n as string);
    public static readonly BindableProperty InitialsProperty = BindableProperty.Create(nameof(Initials), typeof(string), typeof(SessionHeader), "DR",
        propertyChanged: (b, _, n) => ((SessionHeader)b).AvatarLabel.Text = n as string);
    public static readonly BindableProperty BackRouteProperty = BindableProperty.Create(nameof(BackRoute), typeof(string), typeof(SessionHeader), null,
        propertyChanged: (b, _, n) => Nav.SetTo(((SessionHeader)b).BackIcon, n as string));
    public static readonly BindableProperty SolidAvatarProperty = BindableProperty.Create(nameof(SolidAvatar), typeof(bool), typeof(SessionHeader), false,
        propertyChanged: (b, _, n) =>
        {
            var self = (SessionHeader)b;
            bool solid = (bool)n;
            self.AvatarBox.BackgroundColor = solid ? Color.FromArgb("#4F2E98") : Color.FromArgb("#E9DDFF");
            self.AvatarLabel.TextColor = solid ? Colors.White : Color.FromArgb("#23005C");
        });

    public string? Title { get => (string?)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
    public string? Initials { get => (string?)GetValue(InitialsProperty); set => SetValue(InitialsProperty, value); }
    public string? BackRoute { get => (string?)GetValue(BackRouteProperty); set => SetValue(BackRouteProperty, value); }
    public bool SolidAvatar { get => (bool)GetValue(SolidAvatarProperty); set => SetValue(SolidAvatarProperty, value); }

    public SessionHeader()
    {
        InitializeComponent();
        AvatarLabel.Text = "DR";
    }
}
