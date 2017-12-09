using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Image_Editor.Renderer
{
    public class RendererThread //Blending thread for paralel renderer
    {
        Thread thread;
        List<Layer> Layers = new List<Layer>();
        public Layer BlendedLayer;
        public RendererThread(Layer layer1, Layer layer2)
        {
            Layers.Add(layer1);
            Layers.Add(layer2);
            thread = new Thread(this.blend);
            thread.Start(Layers);
            thread.Join();
        }
        void blend(object Layers)
        {
            Layer layer1 = ((List<Layer>)Layers)[0];
            Layer layer2 = ((List<Layer>)Layers)[1];
            Bitmap b_layer1 = (Bitmap)layer1.LayerBitmap.Clone();
            Bitmap b_layer2 = (Bitmap)layer2.LayerBitmap.Clone();
            Random r = new Random();
            Bitmap bmp = new Bitmap(b_layer1.Width, b_layer1.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            if (layer1.Visble)
            {
                g.DrawImageUnscaled(b_layer1, layer1.Position);
            }
            if (layer2.Visble)
            {
                g.DrawImageUnscaled(b_layer2, layer2.Position);
            }
            g.Dispose();
            b_layer1.Dispose();
            b_layer2.Dispose();
            BlendedLayer = new Layer(bmp);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
