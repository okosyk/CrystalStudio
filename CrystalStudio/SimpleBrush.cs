using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using AForge.Imaging.Filters;

namespace Image_Editor
{
    public class SimpleBrush
    {
        public int _size;
        public int size
        {
            get { return _size; }
            set
            {
                _size = value;
                update();
            }
        }
        public int _smooth;
        public int smooth
        {
            get { return _smooth; }
            set
            {
                _smooth = value;
                update();
            }
        }
        public int _opacity;
        public int opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                update();
            }
        }
        private Color _color;
        public Color color
        {
            get { return _color; }
            set
            {
                _color = value;
                brush = new SolidBrush(_color);
                update();
            }
        }
        public SolidBrush brush;
        public Bitmap BrushMask;
        public Bitmap Brush;
        public Bitmap InvertedBrushMask;
        public SimpleBrush(int size, int smooth, Byte opacity)
        {
            this.size = size;
            this.smooth = smooth;
            this.opacity = opacity;
            update();
        }
        public SimpleBrush()
        {
            this.size = 10;
            this.smooth = 0;
            this.opacity = 255;
            this.color = Color.Black;
            update();
        }
        private void update()
        {
            BrushMask = new Bitmap(size, size);
            Bitmap BrushMaskB = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(BrushMask);
            Rectangle bounds = new Rectangle(0, 0, size, size);
           
            using (var ellipsePath = new GraphicsPath())
            {
                ellipsePath.AddEllipse(bounds);
                using (var brush = new PathGradientBrush(ellipsePath))
                {
                    brush.CenterPoint = new PointF(bounds.Width / 2f, bounds.Height / 2f);
                    brush.CenterColor = Color.FromArgb(opacity,opacity,opacity);
                    brush.SurroundColors = new[] { Color.Black};
                    brush.FocusScales = new PointF(smooth/100f, smooth /100f);
                    g.FillRectangle(brush, bounds);
                }
            }
            g = Graphics.FromImage(BrushMaskB);
            g.Clear(Color.Black);
            g.DrawImageUnscaled(BrushMask,new Point(0,0));
            BrushMask = BrushMaskB;
            Brush = new Bitmap(size, size);
            g = Graphics.FromImage(Brush);
            g.Clear(this.color);
            InvertedBrushMask = new Bitmap(size, size);
            g = Graphics.FromImage(InvertedBrushMask);
            AForge.Imaging.Filters.IFilter filter = new AForge.Imaging.Filters.Invert();
            AForge.Imaging.Filters.IFilter filter2 = new AForge.Imaging.Filters.GrayscaleBT709();
            InvertedBrushMask = filter.Apply(filter2.Apply(BrushMask));
            AForge.Imaging.Filters.ReplaceChannel ch = new AForge.Imaging.Filters.ReplaceChannel(AForge.Imaging.RGB.A, new GrayscaleBT709().Apply(BrushMask));
            ch.ApplyInPlace(Brush);
        }
    }
}
