using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Image_Editor.Renderer
{
    public class Renderer //asyncronous paralel renderer
    {
        Size render_size;
        public Renderer(List<Layer> layers)
        {
            render_size = layers[0].LayerBitmap.Size;
            int i;
            List<RendererThread> RThreads = new List<RendererThread>();
            for (i = 0; i+1 < layers.Count; i+=2)
            {
                RThreads.Add(new RendererThread(layers[i], layers[i + 1]));
            }
        }
    }
}
