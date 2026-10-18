namespace QuizSante.Controls;

/// <summary>Anneau de progression (ex. 65 % sur l'accueil).</summary>
public class RingView : GraphicsView, IDrawable
{
    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(
        nameof(Progress), typeof(double), typeof(RingView), 0.0, propertyChanged: (b, _, _) => ((RingView)b).Invalidate());
    public static readonly BindableProperty ArcColorProperty = BindableProperty.Create(
        nameof(ArcColor), typeof(Color), typeof(RingView), Color.FromArgb("#4F2E98"), propertyChanged: (b, _, _) => ((RingView)b).Invalidate());
    public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(
        nameof(TrackColor), typeof(Color), typeof(RingView), Color.FromArgb("#EFF4FF"), propertyChanged: (b, _, _) => ((RingView)b).Invalidate());
    public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(
        nameof(Thickness), typeof(double), typeof(RingView), 9.0, propertyChanged: (b, _, _) => ((RingView)b).Invalidate());

    public double Progress { get => (double)GetValue(ProgressProperty); set => SetValue(ProgressProperty, value); }
    public Color ArcColor { get => (Color)GetValue(ArcColorProperty); set => SetValue(ArcColorProperty, value); }
    public Color TrackColor { get => (Color)GetValue(TrackColorProperty); set => SetValue(TrackColorProperty, value); }
    public double Thickness { get => (double)GetValue(ThicknessProperty); set => SetValue(ThicknessProperty, value); }

    public RingView() => Drawable = this;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float t = (float)Thickness;
        float size = Math.Min(dirtyRect.Width, dirtyRect.Height) - t;
        float x = dirtyRect.Center.X - size / 2, y = dirtyRect.Center.Y - size / 2;

        canvas.StrokeSize = t;
        canvas.StrokeColor = TrackColor;
        canvas.DrawEllipse(x, y, size, size);

        if (Progress <= 0) return;
        canvas.StrokeColor = ArcColor;
        canvas.StrokeLineCap = LineCap.Round;
        float end = 90f - 360f * (float)Math.Min(1.0, Progress);   // départ en haut, sens horaire
        canvas.DrawArc(x, y, size, size, 90f, end, true, false);
    }
}
