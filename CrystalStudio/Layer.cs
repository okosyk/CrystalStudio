using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;

namespace Image_Editor
{
    public class Layer
    {
        private static float  thumbnail_size=30f; //thumbnail image height
        public Bitmap layer_bmp;
        private Bitmap op_layer_bmp;
        private Bitmap tmp_bmp;
        private Bitmap thumbnail_background;
        private Point position = new Point(0, 0);
        private bool visible = true;
        private string name;
        public Image Thumbnail;
        public Graphics LayerGraphics;
        private int opacity = 255;
        public int Width, Height;
        public Bitmap LayerBitmap
        {
            get
            {
                if (Opacity==255)
                {
                    return layer_bmp;
                }
                else
                {
                    return op_layer_bmp;
                }
            }
            set
            {
                update_opacity(value);
                layer_bmp = value;
                LayerGraphics = Graphics.FromImage(layer_bmp);
                UpdateThumbianal();
            }
        }
        public bool Visble { get { return visible; } set { visible = value; } }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
                UpdateThumbianal();
            }
        }
        public int Opacity
        {
            get { return opacity; }
            set
            {
                if (opacity!=value)
                {
                    opacity = value;
                    if (value != 255)
                    {
                        update_opacity(layer_bmp);
                        onOpacityChange();
                    }
                   
                }
            }
        }


        public Layer(Bitmap bmp, string _name) //layer from bitmap
        {
            Width = bmp.Width;
            Height = bmp.Height;
            tmp_bmp = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(tmp_bmp).DrawImageUnscaledAndClipped(bmp,new Rectangle(0,0,bmp.Width,bmp.Height));
            LayerBitmap = tmp_bmp;
            name = _name;
        }

        public Layer(Bitmap bmp)//new layer from bitmap
        {
            Width = bmp.Width;
            Height = bmp.Height;
            tmp_bmp = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(tmp_bmp).DrawImageUnscaledAndClipped(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            LayerBitmap = tmp_bmp;
            name = "New layer";
        }

        public Layer(int width, int height)//new layer from size
        {
            Width = width;
            Height = height;
            LayerBitmap = new Bitmap(width,height,PixelFormat.Format32bppArgb);
            name = "New layer";
        }

        public void UpdateThumbianal()
        {
            float k = layer_bmp.Height / thumbnail_size;
            Thumbnail = new Bitmap((int)(layer_bmp.Width / k), (int)thumbnail_size);
            Graphics g = Graphics.FromImage(Thumbnail);
            if (thumbnail_background == null) create_background();
            g.DrawImageUnscaled(thumbnail_background, new Point(0, 0));
            Bitmap b = new Bitmap(layer_bmp,(int)(layer_bmp.Width / k), (int)thumbnail_size);
            g.DrawImage(b,new Point((int)(Position.X/(layer_bmp.Width/((float)Thumbnail.Width))), (int)(Position.Y / (layer_bmp.Height/ ((float)Thumbnail.Height)))));
            g.Dispose();
        }//updates Thambnail
        private void update_opacity(Bitmap bmp)
        {
            op_layer_bmp = (Bitmap)bmp.Clone();
            AForge.Imaging.Filters.ReplaceChannel ch = new AForge.Imaging.Filters.ReplaceChannel(AForge.Imaging.RGB.A, Mask.GetMask(new ExtractChannel(3).Apply(op_layer_bmp), (byte)Opacity));
            ch.ApplyInPlace(op_layer_bmp);
            
        }
        private void create_background()
        {
            thumbnail_background = new Bitmap(400, 400);
            Graphics g = Graphics.FromImage(thumbnail_background);
            List<SolidBrush> brushes = new List<SolidBrush>() { new SolidBrush(Color.LightGray), new SolidBrush(Color.White) };
            int k = 1;
            int start_k = k;
            for (int i = 0; i < 400; i += 3)
            {
                for (int j = 0; j < 400; j += 3)
                {
                    if (k == 1) k = 0;
                    else k = 1;
                    g.FillRectangle(brushes[k], new Rectangle(j, i, 3, 3));
                }
                if (start_k == 1)
                {
                    k = 0;
                    start_k = 0;
                }
                else
                {
                    k = 1;
                    start_k = 1;
                }

            }
        }//called when object is created and returns a bitmap with bacground



        public delegate void MethodContainer();
        public event MethodContainer onOpacityChange;
    }
}
/*Known issues
 * thumbnail image may appear to big if layer bitmap has non-standart aspect ratio
 */