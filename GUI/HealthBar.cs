using System.Drawing.Drawing2D;

namespace GUI {
    public class HealthBar : ProgressBar {

        public HealthBar() {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.Opaque, true);
        }

        protected override void OnPaint(PaintEventArgs e) {
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, ClientRectangle);

            float width = (Width - 3) * ((float)Value / Maximum);
            if (width > 0) {
                var rect = new RectangleF(1, 1, width, Height - 3);
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                using (var brush = new LinearGradientBrush(rect, Color.Red, Color.DarkRed, LinearGradientMode.Vertical)) {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }
    }
}

