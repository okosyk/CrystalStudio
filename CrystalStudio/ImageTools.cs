using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge;
using AForge.Imaging.Filters;

namespace Image_Editor
{
    public static class ImageTools //all must be redesigned to work with layer system
    {
        public static void Rotate(EditableImage image, RotateFlipType rotateType)
        {
            Bitmap bmp = (Bitmap)image.ActiveLayerBitmap.Clone();
            bmp.RotateFlip(rotateType);
            image.ActiveLayerBitmap = bmp;
        }
    
        public static void ToGrayScale(EditableImage image)
        {

            if (image.ActiveLayerBitmap.PixelFormat!=PixelFormat.Format8bppIndexed || !AForge.Imaging.Image.IsGrayscale(image.ActiveLayerBitmap))
            {
                IFilter filter = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709;
                Bitmap bmp = new Bitmap((Bitmap)image.ActiveLayerBitmap.Clone());
                Bitmap tmp = new Bitmap(bmp.Width,bmp.Height, PixelFormat.Format32bppArgb);
                Graphics gf = Graphics.FromImage(tmp);
                gf.DrawImageUnscaled(bmp,new System.Drawing.Point(0,0));
                image.ActiveLayerBitmap = new Bitmap((Bitmap)filter.Apply(tmp).Clone());

            }
        }
        public static void ToBlackWhite(EditableImage image)
        {
            if (!AForge.Imaging.Image.IsGrayscale(image.ActiveLayerBitmap))
            {
                IFilter filter = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709;
                Threshold filtert = new Threshold(100);
                Bitmap bmp = filter.Apply((Bitmap)image.ActiveLayerBitmap.Clone());
                filtert.ApplyInPlace(bmp);
                image.ActiveLayerBitmap = (Bitmap)bmp.Clone();
                bmp.Dispose();
            }
            else
            {
                Threshold filtert = new Threshold(100);
                Bitmap bmp = (Bitmap)image.ActiveLayerBitmap.Clone();
                filtert.ApplyInPlace(bmp);
                image.ActiveLayerBitmap = (Bitmap)bmp.Clone();
                bmp.Dispose();
            }
        }
        public static void ToRGB(EditableImage image)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImageUnscaled(image.ActiveLayerBitmap, 0, 0);
            g.Dispose();
            image.ActiveLayerBitmap = bmp;
        }
        public static void ToARGB(EditableImage image)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImageUnscaled(image.ActiveLayerBitmap, 0, 0);
            g.Dispose();
            image.ActiveLayerBitmap = bmp;
        }
    }
}
