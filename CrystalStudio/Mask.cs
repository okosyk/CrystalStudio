using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using AForge.Imaging.Filters;
using AForge;

namespace Image_Editor
{
    public static class Mask //creates mask from shape (mask is represented by grayscale image white-255 alpha, black - 0 alpha)
    {
        public static Bitmap GetMask(int width, int heght, GraphicsPath path, bool inverted)
        {
            Bitmap tmp = new Bitmap(width, heght,PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(tmp);
            if (!inverted) g.Clear(Color.White);
            else g.Clear(Color.Black);
            if (!inverted) g.FillPath(Brushes.Black, path);
            else g.FillPath(Brushes.White, path);
            g.Dispose();
            return tmp;
        }
        public static Bitmap GetMask(Bitmap alpha, byte opacity)
        { 
            Bitmap tmp = new Bitmap(alpha.Width, alpha.Height,PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(tmp);
            g.DrawImageUnscaled(alpha, new System.Drawing.Point(0, 0));
            g.Dispose();
            ColorFiltering filter = new ColorFiltering();
            filter.Red = new IntRange(0, opacity-1);
            filter.Green = new IntRange(0, opacity-1);
            filter.Blue = new IntRange(0, opacity-1);
            filter.FillOutsideRange = true;
            filter.FillColor = new AForge.Imaging.RGB(opacity, opacity, opacity);
            filter.ApplyInPlace(tmp);
            return new GrayscaleBT709().Apply(tmp);
        }
    }
}
