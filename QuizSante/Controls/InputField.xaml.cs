namespace QuizSante.Controls;

public partial class InputField : ContentView
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(InputField), null,
        propertyChanged: (b, _, n) => ((InputField)b).LeftIcon.Name = n as string);
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(InputField), null,
        propertyChanged: (b, _, n) => ((InputField)b).Field.Placeholder = n as string);
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(InputField), null, BindingMode.TwoWay,
        propertyChanged: (b, _, n) => { var f = ((InputField)b).Field; if (f.Text != (string?)n) f.Text = n as string; });
    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(InputField), false,
        propertyChanged: (b, _, n) =>
        {
            var self = (InputField)b;
            self.Field.IsPassword = (bool)n;
            self.EyeIcon.IsVisible = (bool)n;
        });
    public static readonly BindableProperty FieldColorProperty = BindableProperty.Create(nameof(FieldColor), typeof(Color), typeof(InputField), null,
        propertyChanged: (b, _, n) => ((InputField)b).Box.BackgroundColor = (Color)n);
    public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.Create(nameof(KeyboardType), typeof(Keyboard), typeof(InputField), Keyboard.Default,
        propertyChanged: (b, _, n) => ((InputField)b).Field.Keyboard = (Keyboard)n);

    public string? Icon { get => (string?)GetValue(IconProperty); set => SetValue(IconProperty, value); }
    public string? Placeholder { get => (string?)GetValue(PlaceholderProperty); set => SetValue(PlaceholderProperty, value); }
    public string? Text { get => (string?)GetValue(TextProperty); set => SetValue(TextProperty, value); }
    public bool IsPassword { get => (bool)GetValue(IsPasswordProperty); set => SetValue(IsPasswordProperty, value); }
    public Color FieldColor { get => (Color)GetValue(FieldColorProperty); set => SetValue(FieldColorProperty, value); }
    public Keyboard KeyboardType { get => (Keyboard)GetValue(KeyboardTypeProperty); set => SetValue(KeyboardTypeProperty, value); }

    public event EventHandler<TextChangedEventArgs>? TextChanged;

    public InputField()
    {
        InitializeComponent();
        Field.TextChanged += (s, e) =>
        {
            Text = e.NewTextValue;
            TextChanged?.Invoke(this, e);
        };
    }

    void OnEyeTapped(object? sender, TappedEventArgs e)
    {
        Field.IsPassword = !Field.IsPassword;
        EyeIcon.Name = Field.IsPassword ? "eye-outline" : "eye-off-outline";
    }
}
