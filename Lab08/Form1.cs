using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab08
{
    public enum DrawMode { Pen, Line, Rectangle, Ellipse }

    public class DrawItem
    {
        public DrawMode Mode { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }
        public float Width { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();
    }

    public class DrawSurface : Panel
    {
        public DrawSurface()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            Dock = DockStyle.Fill;
        }
    }

    public partial class FrmPaint : Form
    {
        private readonly List<DrawItem> items = new List<DrawItem>();
        private DrawItem currentItem;
        private bool isDrawing = false;
        private Color currentColor = Color.Black;

        public FrmPaint()
        {
            InitializeComponent();
        }

        private DrawMode CurrentMode
        {
            get
            {
                string mode = cboMode.SelectedItem.ToString();
                return (DrawMode)Enum.Parse(typeof(DrawMode), mode);
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using ColorDialog dialog = new ColorDialog();
            dialog.Color = currentColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = dialog.Color;
                btnColor.BackColor = currentColor;
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) return;
            items.RemoveAt(items.Count - 1);
            canvas.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Xóa toàn bộ vùng vẽ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                items.Clear();
                canvas.Invalidate();
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            isDrawing = true;
            currentItem = new DrawItem
            {
                Mode = CurrentMode,
                Start = e.Location,
                End = e.Location,
                Color = currentColor,
                Width = (float)nudWidth.Value
            };

            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X = {e.X}, Y = {e.Y}, Items = {items.Count}";
            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;
            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);

            canvas.Invalidate();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing || currentItem == null) return;
            currentItem.End = e.Location;
            items.Add(currentItem);
            currentItem = null;
            isDrawing = false;
            canvas.Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (DrawItem item in items)
                DrawOneItem(e.Graphics, item);

            if (currentItem != null)
                DrawOneItem(e.Graphics, currentItem);
        }

        private void DrawOneItem(Graphics g, DrawItem item)
        {
            using Pen pen = new Pen(item.Color, item.Width);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;

            Rectangle rect = GetRectangle(item.Start, item.End);

            switch (item.Mode)
            {
                case DrawMode.Pen:
                    if (item.Points.Count >= 2)
                    {
                        for (int i = 1; i < item.Points.Count; i++)
                            g.DrawLine(pen, item.Points[i - 1], item.Points[i]);
                    }
                    break;
                case DrawMode.Line:
                    g.DrawLine(pen, item.Start, item.End);
                    break;
                case DrawMode.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case DrawMode.Ellipse:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private Rectangle GetRectangle(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(start.X - end.X);
            int height = Math.Abs(start.Y - end.Y);
            return new Rectangle(x, y, width, height);
        }
    }
}