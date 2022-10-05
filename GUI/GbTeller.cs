namespace GUI {
    public class GbTeller : GroupBox {
        private Color borderColor = Color.Black;

        public Color BorderColor {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public GbTeller() {
            Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Location = new Point(121, 260);
            Size = new Size(545, 123);
        }

        protected override void OnPaint(PaintEventArgs e) {
            Size tSize = TextRenderer.MeasureText(Text+1, Font);

            Rectangle borderRect = e.ClipRectangle;
            borderRect.Y = (borderRect.Y + (tSize.Height / 2));
            borderRect.Height = (borderRect.Height - (tSize.Height / 2));
            ControlPaint.DrawBorder(e.Graphics, borderRect, borderColor, ButtonBorderStyle.Solid);
            
            Rectangle textRect = e.ClipRectangle;
            textRect.X = (textRect.X + 6);
            textRect.Y = (textRect.Y + 15);
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRect);
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRect);
        }
    }
}


