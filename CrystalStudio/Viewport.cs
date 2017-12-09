using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Image_Editor
{
    public class Viewport
    {

        private Bitmap viewportImage;
        private EditableImage EImage;
        private SimpleBrush brush;
        private Selection selection;
        private IntPtr picturebox_handle;
        private PictureBox picture_box;
        private Graphics viewport_canvas;
        private Pen selection_pen = new Pen(new SolidBrush(Color.BlueViolet));  //selection color better use HatchBrush but i dont like it
        private Timer timer = new Timer();
        private ViewportTool curent_tool = ViewportTool.None;
        private Point move_start_position = new Point(0, 0);
        private Point lastposition = new Point(0, 0);
        public ViewportTool CurentTool
        {
            get { return curent_tool; }
            private set
            {
                curent_tool = value;
                if (curent_tool == ViewportTool.None)
                {
                    picture_box.Cursor = Cursors.Default;
                }
                else if (curent_tool == ViewportTool.Move || curent_tool == ViewportTool.MoveSelection)
                {
                    picture_box.Cursor = Cursors.Default;
                }
                else if (curent_tool == ViewportTool.Selection)
                {
                    picture_box.Cursor = Cursors.Cross;
                }
                else if (curent_tool == ViewportTool.BrushPaint || curent_tool == ViewportTool.Earser)
                {
                    picture_box.Cursor = Cursors.Default;
                }
                else if (curent_tool == ViewportTool.Fill)
                {
                    picture_box.Cursor = Cursors.Cross;
                }
                onToolChange();
            }
        }

        public Viewport(EditableImage image, IntPtr pb_handle)
        {
            EImage = image;
            picturebox_handle = pb_handle;
            picture_box = (PictureBox)Control.FromHandle(pb_handle);
            picture_box.Focus();
            viewport_canvas = picture_box.CreateGraphics();
            selection_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            selection_pen.Width = 2;
            picture_box.MouseMove += Picture_box_MouseMove;
            picture_box.MouseUp += Picture_box_MouseUp;
            picture_box.MouseDown += Picture_box_MouseDown;
            picture_box.MouseEnter += Picture_box_MouseEnter;
            picture_box.MouseLeave += Picture_box_MouseLeave;
            EImage.onLayerChanged += EImage_onLayerChange;
            EImage.onLayerPositionChanged += EImage_onLayerChange;
            EImage.onLayerVisibilityChanged += EImage_onLayerVisibilityChange;
            Update();
        }

        //event handlers
        //pls God help and protect the person who see the following code and spend countles hours in order to understand it. Amen.
        private void Picture_box_MouseMove(object sender, MouseEventArgs e)
        {

            if (CurentTool == ViewportTool.Selection)
            {
                if (e.Button == MouseButtons.Left)
                {
                    selection.Select(e.Location);
                    picture_box.Refresh();
                    if (selection.Type == SelectionType.Rectangle)
                    {
                        viewport_canvas.DrawRectangle(selection_pen, selection.GetSelectionRectangle());
                    }
                    else if (selection.Type == SelectionType.Elips)
                    {
                        viewport_canvas.DrawEllipse(selection_pen, selection.GetSelectionRectangle());
                    }
                    else if (selection.Type == SelectionType.FreeForm)
                    {
                        viewport_canvas.DrawPath(selection_pen, selection.GetSelectionPath());
                    }
                }
            }
            else if (CurentTool == ViewportTool.MoveSelection)
            {
                if (selection.isInsideSelection(e.Location))
                {
                    picture_box.Cursor = Cursors.SizeAll;
                    if (e.Button == MouseButtons.Left)
                    {
                        selection.Move(e.Location);
                    }
                }
                else
                {
                    picture_box.Cursor = Cursors.Default;
                }
            }
            else if (CurentTool == ViewportTool.Move)
            {
                if (e.Button == MouseButtons.Left)
                {
                    EImage.ActiveLayerPosition = new Point(e.Location.X - move_start_position.X, e.Location.Y - move_start_position.Y);
                }

            }
            else if (CurentTool == ViewportTool.BrushPaint)
            {
                int tmp = (int)(brush.size / 2f);
                if (e.Button == MouseButtons.Left)
                {
                    Rectangle draw_area = new Rectangle(e.Location.X - tmp, e.Location.Y - tmp, brush.size, brush.size);
                    
                    viewport_canvas.DrawImageUnscaled(brush.Brush, draw_area.Location);
                    EImage.AddBrushDrawPoint(draw_area.Location);
                }
            }
            else if (CurentTool == ViewportTool.Earser)
            {
                int tmp = (int)(brush.size / 2f);
                if (e.Button == MouseButtons.Left)
                {
                    Rectangle draw_area = new Rectangle(e.Location.X - tmp, e.Location.Y - tmp, brush.size, brush.size);
                    EImage.Earse(brush, draw_area);
                }
            }
        }//need some redesign. onPaint event would work better with drawind withou flickering
        private void Picture_box_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurentTool == ViewportTool.Selection)
            {
                timer.Tick -= Timer_Tick;
                picture_box.Refresh();
                timer.Stop();
                SelectionStart(selection.Type);
            }
            else if (CurentTool == ViewportTool.MoveSelection)
            {
                if (selection.isInsideSelection(e.Location))
                {
                    selection.MoveStart(e.Location);
                    timer.Interval = 20;
                }
                else
                {
                    ClearSelection();
                    lastposition.X = EImage.ActiveLayerPosition.X;
                    lastposition.Y = EImage.ActiveLayerPosition.Y;
                    move_start_position = new Point(e.Location.X - EImage.ActiveLayerPosition.X, e.Location.Y - EImage.ActiveLayerPosition.Y);
                    CurentTool = ViewportTool.Move;
                }
            }
            else if (CurentTool == ViewportTool.Move)
            {
                lastposition.X = EImage.ActiveLayerPosition.X;
                lastposition.Y = EImage.ActiveLayerPosition.Y;
                move_start_position = new Point(e.Location.X - EImage.ActiveLayerPosition.X, e.Location.Y - EImage.ActiveLayerPosition.Y);
            }
            else if (CurentTool == ViewportTool.BrushPaint || CurentTool==ViewportTool.Earser)
            {
                EImage.NewAction(Actions.LayerChanged);
                Picture_box_MouseMove(sender, e);
            }
            else if (CurentTool == ViewportTool.Fill)
            {
                EImage.Fill(new Point(e.X-EImage.ActiveLayerPosition.X, e.Y - EImage.ActiveLayerPosition.Y),brush.color);
            }
        }
        private void Picture_box_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurentTool == ViewportTool.Selection)
            {
                if (selection.Status == SelectionStatus.inProgress)
                {
                    selection.SelectionFinished();
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
            }
            else if (CurentTool == ViewportTool.MoveSelection)
            {
                timer.Interval = 100;
            }
            else if (CurentTool == ViewportTool.Move)
            {
                EImage.NewAction(Actions.LayerMoved, lastposition);
                onMoveFinished();
            }
            else if (CurentTool == ViewportTool.BrushPaint)
            {
                EImage.DrawBrush(brush);
                EImage.ActiveLayer.UpdateThumbianal();
                EImage.Update();
                
            }


        }
        private void Picture_box_MouseLeave(object sender, EventArgs e)
        {
            if (curent_tool == ViewportTool.BrushPaint)
            {
                Cursor.Show();
                picture_box.Refresh();
            }
        }
        private void Picture_box_MouseEnter(object sender, EventArgs e)
        {
            if (curent_tool == ViewportTool.BrushPaint || curent_tool == ViewportTool.Earser)
            {
                Bitmap img = new Bitmap(brush.size+1, brush.size+1);
                Graphics g = Graphics.FromImage(img);
                g.DrawEllipse(Pens.Gray, new Rectangle(0, 0, brush.size, brush.size));
                Pen pen = new Pen(Color.Gray);
                pen.DashStyle = DashStyle.Dash;
                pen.DashPattern = new float[] { 8.0F, 3.0F};
                int tmp = (int)(brush.size * (brush.smooth / 100f));
                g.DrawEllipse(pen, new Rectangle(brush.size/2-tmp/2, brush.size / 2 - tmp / 2,tmp,tmp));
                Icon icono = Icon.FromHandle(img.GetHicon());
                Cursor a = new Cursor(icono.Handle);
                picture_box.Cursor = a;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CurentTool == ViewportTool.Selection || CurentTool == ViewportTool.MoveSelection)
            {
                selection_pen.DashOffset += 1f;
                picture_box.Refresh();
                if (selection.Type == SelectionType.Rectangle)
                {
                    viewport_canvas.DrawRectangle(selection_pen, selection.SelectionRectangle);
                }
                else if (selection.Type == SelectionType.Elips)
                {
                    viewport_canvas.DrawEllipse(selection_pen, selection.SelectionRectangle);
                }
                else if (selection.Type == SelectionType.FreeForm)
                {
                    viewport_canvas.DrawPath(selection_pen, selection.SelectionPath);
                }
                if (selection.isInverted)
                {
                    viewport_canvas.DrawRectangle(selection_pen, new Rectangle(0, 0, EImage.Width, EImage.Height));
                }
            }
            else if (CurentTool == ViewportTool.Move)
            {
                ClearSelection();
            }
        }
        private void EImage_onLayerChange()
        {
            picture_box.Image = EImage.RenderViewport();
            picture_box.Update();
        }//redawing viewport when smthng changed
        private async void EImage_onLayerVisibilityChange()
        {
            await Task.Delay(1);
            picture_box.Image = EImage.RenderViewport();
            picture_box.Update();
        }  //renders viewport when visivility of layer changed async cause of layer selection tool flickers without delay

        //suspend invoke events
        public void SuspendEvents()
        {
            picture_box.MouseMove -= Picture_box_MouseMove;
            picture_box.MouseUp -= Picture_box_MouseUp;
            picture_box.MouseDown -= Picture_box_MouseDown;
        }
        public void InvokeEvents()
        {
            picture_box.MouseMove += Picture_box_MouseMove;
            picture_box.MouseUp += Picture_box_MouseUp;
            picture_box.MouseDown += Picture_box_MouseDown;
        }

        //paint tool logic
        public void StartPaint(SimpleBrush brush)
        {
            this.brush = brush;
            CurentTool = ViewportTool.BrushPaint;
        }
        public void ChangeBrush(SimpleBrush brush)
        {
            this.brush = brush;
        }

        //move tool logic
        public void MoveStart()
        {
            if (CurentTool == ViewportTool.Selection)
            {
                if (selection.Status == SelectionStatus.Finished)
                {
                    CurentTool = ViewportTool.MoveSelection;
                }
                else if (selection.Status == SelectionStatus.Waiting)
                {
                    CurentTool = ViewportTool.Move;
                }
            }
            else if (CurentTool == ViewportTool.None || CurentTool == ViewportTool.BrushPaint)
            {
                CurentTool = ViewportTool.Move;
            }

        }

        //selection logic
        public void InvertSelection()
        {
            if (selection.Status == SelectionStatus.Finished)
            {
                selection.Invert();
            }
        }
        public void SelectionStart(SelectionType type)
        {
            CurentTool = ViewportTool.Selection;
            selection = new Selection(EImage.ActiveLayerBitmap.Size, type);
        }

        internal void ResetTool()
        {
            CurentTool = ViewportTool.None;
        }

        public void SelectAll()
        {
            CurentTool = ViewportTool.Selection;
            selection = new Selection(EImage.ActiveLayerBitmap.Size, SelectionType.Rectangle);
            selection.SelectAll();
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        public void ClearSelection()
        {

            CurentTool = ViewportTool.Move;
            timer.Tick -= Timer_Tick;
            selection = null;
            picture_box.Refresh();
            timer.Stop();
        }

        // copy/cut/paste/delete logic
        public void DeleteSelection()
        {
            if (selection != null && selection.Status == SelectionStatus.Finished)
            {
                EImage.DeleteSelection(selection);
                ClearSelection();
            }
        }

        public void Update()
        {
            viewportImage = EImage.RenderViewport();
            picture_box.Image = viewportImage;
            picture_box.Update();
        }//Viewport update

        public void Dispose()//USED BEFORE DESTRUCTION
        {
            timer.Stop();
        }

        //viewport event declaration
        public delegate void MethodContainer();
        public event MethodContainer onToolChange;
        public event MethodContainer onMoveFinished;

        internal void StartEarse(SimpleBrush brush)
        {
            this.brush = brush;
            CurentTool = ViewportTool.Earser;
        }

        internal void StartFill()
        {
            CurentTool = ViewportTool.Fill;
        }
    }

    public enum ViewportTool
    {
        None = 0, Move = 1, Selection = 2, MoveSelection = 3, BrushPaint = 4, Earser=5, Fill=6
    }//viewport tools
}
