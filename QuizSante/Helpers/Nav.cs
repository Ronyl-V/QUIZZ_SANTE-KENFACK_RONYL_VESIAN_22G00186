namespace QuizSante.Helpers;

/// <summary>Navigation simple par routes : h:Nav.To="home" sur n'importe quel élément.</summary>
public static class Nav
{
    public static readonly BindableProperty ToProperty =
        BindableProperty.CreateAttached("To", typeof(string), typeof(Nav), null, propertyChanged: OnToChanged);

    public static string? GetTo(BindableObject b) => (string?)b.GetValue(ToProperty);
    public static void SetTo(BindableObject b, string? value) => b.SetValue(ToProperty, value);

    static void OnToChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not View view || newValue is not string route) return;
        var tap = new TapGestureRecognizer();
        tap.Tapped += async (_, _) => await Go(route);
        view.GestureRecognizers.Add(tap);
    }

    public static Task Go(string route) => Shell.Current.GoToAsync($"//{route}");
}
