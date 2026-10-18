using Microsoft.Maui.Handlers;

namespace QuizSante;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Inter_400Regular.ttf", "Inter");
                fonts.AddFont("Inter_500Medium.ttf", "InterMedium");
                fonts.AddFont("Inter_600SemiBold.ttf", "InterSemi");
                fonts.AddFont("Inter_700Bold.ttf", "InterBold");
                fonts.AddFont("Inter_800ExtraBold.ttf", "InterXBold");
                fonts.AddFont("MaterialCommunityIcons.ttf", "MDI");
            });

        // Entry sans bordure ni soulignement : le champ est dessiné par le Border parent.
        EntryHandler.Mapper.AppendToMapping("QuizSanteNoBorder", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetPadding(0, 0, 0, 0);
#elif WINDOWS
            var tb = handler.PlatformView;
            var transparent = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Transparent);
            tb.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            tb.Padding = new Microsoft.UI.Xaml.Thickness(0, 6, 0, 0);
            tb.Background = transparent;
            // WinUI redessine un fond/bordure au survol et au focus : on les neutralise aussi.
            tb.Resources["TextControlBackground"] = transparent;
            tb.Resources["TextControlBackgroundPointerOver"] = transparent;
            tb.Resources["TextControlBackgroundFocused"] = transparent;
            tb.Resources["TextControlBorderBrush"] = transparent;
            tb.Resources["TextControlBorderBrushPointerOver"] = transparent;
            tb.Resources["TextControlBorderBrushFocused"] = transparent;
            tb.Resources["TextControlBorderThemeThickness"] = new Microsoft.UI.Xaml.Thickness(0);
            tb.Resources["TextControlBorderThemeThicknessFocused"] = new Microsoft.UI.Xaml.Thickness(0);
#endif
        });

        return builder.Build();
    }
}
