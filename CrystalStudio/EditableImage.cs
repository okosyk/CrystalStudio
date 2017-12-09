using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace Image_Editor
{
    public class EditableImage
    {
       // private Renderer.Renderer renderer;
        private Bitmap curent_viewport;
        private string filename = "";
        private string tmpfilename = "";
        private int buf_pos = 0;
        private Stack<Action> rd_buffer = new Stack<Action>();
        private Stack<Action> ud_buffer = new Stack<Action>();
        private List<Layer> layers= new List<Layer>();
        private int grid_size = 10;
        private int active_layer_id=0;
        private int width, height;
        private bool affected = true;
        private Action tmp_action;
        private Action tmp_action2;
        private Color internal_fill_color;
        private List<Point> brush_draw_points = new List<Point>();
        public int ActiveLayerID { get { return active_layer_id - 1; } set { active_layer_id = value + 1; } } //active layer id; +-1 cause you shouldn get actual layer with id=0, its used for background
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public string FileName { get { return filename; } set {
                filename = value;
                layers[1].Name = Path.GetFileNameWithoutExtension(value);
            } }
        public string TmpFileName { get { return tmpfilename; } set { tmpfilename = value; } }
        public Bitmap ActiveLayerBitmap
        {
            get { return layers[active_layer_id].LayerBitmap; }
            set
            {
                layers[active_layer_id].LayerBitmap = value;
                onLayerChanged();
                
            }
        }
        public Layer ActiveLayer
        {
            get { return layers[active_layer_id]; }
            set
            {
                layers[active_layer_id] = value;
                onLayerChanged();

            }
        }
        public Point ActiveLayerPosition
        {
            get { return layers[active_layer_id].Position; }
            set
            {
                layers[active_layer_id].Position = value;
                onLayerPositionChanged();
            }
        }

        public EditableImage(Bitmap img)
        {
            width = img.Width;
            height = img.Height;
            AddLayer(img);
            curent_viewport = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
        }

        public Bitmap RenderImage()
        {
            Bitmap tmp_image = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(tmp_image);

            for (int i = 1; i < layers.Count; i++)
            {
                if (layers[i].Visble && layers[i].Opacity == 255)
                {
                    g.DrawImageUnscaled(layers[i].LayerBitmap, layers[i].Position);
                }
                else if (layers[i].Visble && layers[i].Opacity != 255)
                {
                    
                    g.DrawImageUnscaled(layers[i].LayerBitmap, layers[i].Position);
                }
            }
            return tmp_image;
        }//renders an output image(without background)
        public Bitmap RenderImage(ImageFormat format)
        {
            Bitmap tmp_image = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(tmp_image);
            if (format==ImageFormat.Jpeg)
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));
            }
            for (int i = 1; i < layers.Count; i++)
            {
                if (layers[i].Visble && layers[i].Opacity == 255)
                {
                    g.DrawImageUnscaled(layers[i].LayerBitmap, layers[i].Position);
                }
                else if (layers[i].Visble && layers[i].Opacity != 255)
                {
                    g.DrawImageUnscaled(layers[i].LayerBitmap, layers[i].Position);
                }
            }
            return tmp_image;
        }
        public Bitmap RenderViewport()
        {
            if (affected)
            {
                Graphics g = Graphics.FromImage(curent_viewport);

                for (int i = 0; i < layers.Count; i++)
                {
                    if (layers[i].Visble && layers[i].Opacity!=0)
                    {
                        g.DrawImageUnscaled(layers[i].LayerBitmap, layers[i].Position);
                    }
                }
                g.Dispose();
            }

            return curent_viewport;

        }//renders an image for viewport

        //layer add/delete/get logic
        public void AddLayer()
        {
            if (active_layer_id == 0)
            {
                layers.Add(new Layer(create_background(), "Background"));
            }
            Layer l = new Layer(width, height);
            l.onOpacityChange += Update;
            layers.Add(l);
            active_layer_id++;
            onLayerChanged();
        }
        public void AddLayer(Bitmap layer)
        {
            if (active_layer_id==0)
            {
                layers.Add(new Layer(create_background(), "Background"));
            }
            Layer l = new Layer(layer);
            l.onOpacityChange += Update;
            layers.Add(l);
            active_layer_id++;
        }
        public void AddLayer(Bitmap layer, string name)
        {
            if (active_layer_id == 0)
            {
                layers.Add(new Layer(create_background(), "Background"));
            }
            Layer l = new Layer(layer);
            l.onOpacityChange += Update;

            layers.Add(l);
            active_layer_id++;
            onLayerChanged();
        }

        internal void Earse(SimpleBrush brush, Rectangle location)
        {
            
            AForge.Imaging.Filters.ExtractChannel ch = new AForge.Imaging.Filters.ExtractChannel(AForge.Imaging.RGB.A);
            Bitmap chanel = new Bitmap(ActiveLayerBitmap.Width, ActiveLayerBitmap.Height);
            Graphics g = Graphics.FromImage(chanel);
            g.DrawImageUnscaled(ch.Apply(ActiveLayer.layer_bmp),new Point(0,0));

            // g.DrawImageUnscaled(brush.InvertedBrushMask, location);
            g.FillEllipse(Brushes.Black,location);

            AForge.Imaging.Filters.Grayscale f = new AForge.Imaging.Filters.Grayscale(0.33,0.33,0.33);
            AForge.Imaging.Filters.ColorFiltering filter = new AForge.Imaging.Filters.ColorFiltering();
            filter.Red = new AForge.IntRange(0, ActiveLayer.Opacity-10);
            filter.Green = new AForge.IntRange(0, ActiveLayer.Opacity-10);
            filter.Blue = new AForge.IntRange(0, ActiveLayer.Opacity-10);
            filter.FillOutsideRange = true;
            filter.FillColor = new AForge.Imaging.RGB(255, 255, 255);

            filter.ApplyInPlace(chanel);
            chanel = f.Apply(chanel);
            AForge.Imaging.Filters.ReplaceChannel ch2 = new AForge.Imaging.Filters.ReplaceChannel(AForge.Imaging.RGB.A, chanel);
            ch2.ApplyInPlace(ActiveLayer.layer_bmp);
            onLayerChanged();
        }

        public Layer GetLayer(int index)
        {
            return layers[index + 1];
        }
        public List<Layer> GetLayers()
        {
            List<Layer> tmp = new List<Layer>();
            for (int i = 1; i < layers.Count; i++)
            {
                tmp.Add(layers[i]);
            }
            return tmp;
        }//returns all layers inside of list without background layer(id=0)
        private void _fill(Point point, Color color)
        {
            if (ActiveLayerBitmap.GetPixel(point.X,point.Y) == internal_fill_color)
            {
                ActiveLayerBitmap.SetPixel(point.X, point.Y, color);

                if (point.X != 0)
                {
                    _fill(new Point(point.X - 1, point.Y), color);
                }
                if (point.X != ActiveLayerBitmap.Width)
                {
                    _fill(new Point(point.X + 1, point.Y), color);
                }
                if (point.Y != 0)
                {
                    _fill(new Point(point.X, point.Y - 1), color);
                }
                if (point.Y != ActiveLayerBitmap.Height)
                {
                    _fill(new Point(point.X, point.Y + 1), color);
                }
            }
        }
        internal void Fill(Point point, Color color)
        {
            if (point.X*point.Y>=0)
            {
                internal_fill_color = ActiveLayerBitmap.GetPixel(point.X, point.Y);
                _fill(point,color);
                onLayerChanged();
            }
           
        }

        public void ChangeLayerVisibility(int layerId, bool isVisible)
        {
            if (layers[layerId].Visble != isVisible)
            {
                layers[layerId].Visble = isVisible;
                onLayerVisibilityChanged();
            }
            
        }
        // redo/ubdo logic
        public void NewAction(Actions act, Point old_position)
        {
            tmp_action = new Action(act, active_layer_id, old_position.X, old_position.Y);
            ud_buffer.Push(tmp_action);
        } //may be neded in future if the chage on image has been done outside of EI object
        public void NewAction(Actions act)
        {
            if (act == Actions.LayerChanged)
            {
                tmp_action = new Action(act, active_layer_id, (Bitmap)ActiveLayerBitmap.Clone());
                ud_buffer.Push(tmp_action);
            }
        }
        public void Undo()
        {
            if (ud_buffer.Count != 0)
            {
                buf_pos--;
                tmp_action = ud_buffer.Pop();
                if (tmp_action.Type == Actions.LayerChanged)
                {
                    tmp_action2 = new Action(tmp_action.Type);
                    foreach (int layerId in tmp_action.LayerIDs)
                    {
                        tmp_action2.AddLayer(layerId, layers[layerId].LayerBitmap);
                        layers[layerId].LayerBitmap = tmp_action.LayerBitmaps[layerId];
                    }
                    onLayerChanged();
                    rd_buffer.Push(tmp_action2);
                }
                else if (tmp_action.Type == Actions.LayerMoved)
                {
                    tmp_action2 = new Action(tmp_action.Type);
                    foreach (int layerId in tmp_action.LayerIDs)
                    {
                        tmp_action2.AddLayer(layerId, layers[layerId].Position.X, layers[layerId].Position.Y);
                        layers[layerId].Position = tmp_action.LayerPositions[layerId];
                    }
                    onLayerChanged();
                    rd_buffer.Push(tmp_action2);
                }
            }
        }
        public void Redo()
        {
            if (rd_buffer.Count != 0)
            {
                buf_pos++;
                tmp_action = rd_buffer.Pop();
                if (tmp_action.Type == Actions.LayerChanged)
                {
                    tmp_action2 = new Action(tmp_action.Type);
                    foreach (int layerId in tmp_action.LayerIDs)
                    {
                        tmp_action2.AddLayer(layerId, layers[layerId].LayerBitmap);
                        layers[layerId].LayerBitmap = tmp_action.LayerBitmaps[layerId];
                    }
                    onLayerChanged();
                    ud_buffer.Push(tmp_action2);
                }
                else if (tmp_action.Type == Actions.LayerMoved)
                {
                    tmp_action2 = new Action(tmp_action.Type);
                    foreach (int layerId in tmp_action.LayerIDs)
                    {
                        tmp_action2.AddLayer(layerId, layers[layerId].Position.X, layers[layerId].Position.X);
                        layers[layerId].Position = tmp_action.LayerPositions[layerId];
                    }
                    onLayerChanged();
                    ud_buffer.Push(tmp_action2);
                }
            }
        }
      
        //delete selection logic
        public void DeleteSelection(Selection selection)
        {
            tmp_action = new Action(Actions.LayerChanged, active_layer_id, ActiveLayerBitmap);
            ud_buffer.Push(tmp_action);
            Bitmap tmpbmp = new Bitmap(ActiveLayer.Width, ActiveLayer.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(tmpbmp);
            g.Clear(Color.White);
            g.DrawImageUnscaled(selection.GetSelectionMask(),new Point(0-ActiveLayerPosition.X,0-ActiveLayerPosition.Y));
            AForge.Imaging.Filters.ApplyMask filter = new AForge.Imaging.Filters.ApplyMask(tmpbmp);
            ActiveLayerBitmap = filter.Apply((Bitmap)ActiveLayerBitmap.Clone());
 

        }

        //painting
        public void AddBrushDrawPoint(SimpleBrush brush, Rectangle _draw_area)
        {
            
            Rectangle draw_area = new Rectangle(_draw_area.X - ActiveLayerPosition.X, _draw_area.Y - ActiveLayerPosition.Y, _draw_area.Width, _draw_area.Height);
            ActiveLayer.LayerGraphics.FillEllipse(brush.brush, draw_area);
        }
        public void AddBrushDrawPoint(Point _draw_position)
        {
            Point draw_position = new Point(_draw_position.X - ActiveLayerPosition.X, _draw_position.Y - ActiveLayerPosition.Y);
            brush_draw_points.Add(draw_position);
        }
        public void DrawBrush(SimpleBrush brush)
        {
            if (brush_draw_points.Count == 1)
            {
                ActiveLayer.LayerGraphics.DrawImageUnscaled(brush.Brush, brush_draw_points[0]);
            }
            int k = 0;
            for (int i = 1; i < brush_draw_points.Count; i++)
            {
                List<Point> points = Helpers.Bresenhams(brush_draw_points[i - 1].X, brush_draw_points[i - 1].Y, brush_draw_points[i].X, brush_draw_points[i].Y);
                foreach (Point point in points)
                {
                    if (k==brush.size/3)
                    {
                        ActiveLayer.LayerGraphics.DrawImageUnscaled(brush.Brush, point);
                        k = 0;
                    }
                    k++; 
                }
            }
            brush_draw_points.Clear();
        }

        private Bitmap create_background()
        {
            Bitmap background = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(background);
            List<SolidBrush> brushes = new List<SolidBrush>() { new SolidBrush(Color.LightGray), new SolidBrush(Color.White) };
            int k = 1;
            int start_k = k;
            for (int i = 0; i < Height; i += grid_size)
            {
                for (int j = 0; j < Width; j += grid_size)
                {
                    if (k == 1) k = 0;
                    else k = 1;
                    g.FillRectangle(brushes[k], new Rectangle(j, i, grid_size, grid_size));
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
            return background;
        }//called when object is created and returns a bitmap with bacground; Should be redesigned to return a Layer type

        public void Update()
        {
            onLayerChanged();
        }//used to call onLayerChange event from outside of object 


        public void DisposeFile()
        {
            curent_viewport.Dispose();
            rd_buffer.Clear();
            ud_buffer.Clear();
        }//releases memory from bitmap objects...not sure if its stil needed
        
        //EI events
        public delegate void MethodContainer();
        public event MethodContainer onLayerChanged;
        public event MethodContainer onLayerVisibilityChanged;
        public event MethodContainer onLayerPositionChanged;
    }
}
