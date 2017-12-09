using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Image_Editor
{
    public class Selection
    {
        private Size layerSize;
        private SelectionType type;
        private SelectionStatus status;
        private Point move_offset;
        private bool invert = false;
        private List<Point> selection = new List<Point>();
        private int xg, yg, xg2, yg2;
        public SelectionStatus Status { get { return status; } }
        private Rectangle selection_bounds = new Rectangle();
        private Rectangle selection_rect = new Rectangle();
        private GraphicsPath selection_path = new GraphicsPath();
        public Rectangle SelectionRectangle { get { return selection_rect; } }//used for rectangle/elipse selection
        public GraphicsPath SelectionPath { get { return selection_path; } }// used for freeform selection
        public SelectionType Type { get { return type; } }
        public bool isInverted { get { return invert; } }

        public Selection(Size layer_size, SelectionType _type)
        {
            layerSize = layer_size;
            type = _type;
            status = SelectionStatus.Waiting;
        }//when object created selection is considered started its status is set to Waiting
        
        //selection logic
        public void Select(Point apoint)
        {
            if (apoint.X < 0) apoint.X = 0;
            if (apoint.Y < 0) apoint.Y = 0;
            if (apoint.X > layerSize.Width) apoint.X = layerSize.Width;
            if (apoint.Y > layerSize.Height) apoint.Y = layerSize.Height;
            if (type == SelectionType.Rectangle || type == SelectionType.Elips)
            {
                if (selection.Count == 0)
                {
                    selection.Add(apoint);
                    selection.Add(apoint);
                    status = SelectionStatus.inProgress;
                }
                else
                {

                    selection[1] = apoint;
                }
            }
            if (type == SelectionType.FreeForm)
            {
                selection.Add(apoint);
                status = SelectionStatus.inProgress;
            }
        }// when called first after selection started it recods point as the start of the selection all next points will be recorded at position 1(represents end of selection as w/h proptry) for rectangle or elips or added to selection for ff selection
        public void SelectAll()
        {
            selection_rect = new Rectangle(0, 0, layerSize.Width, layerSize.Height);
            SelectionFinished();
        }
        public void SelectionFinished()
        {
            status = SelectionStatus.Finished;
            if (type == SelectionType.FreeForm)
            {
                selection_path.CloseAllFigures();
            }
            calculate_bounds();
        }//finishes the selection. till this method called selection status is inProgress, after its Finished

        public bool isInsideSelection(Point point)
        {
            if (point.X >= selection_bounds.X && point.X <= selection_bounds.X + selection_bounds.Width && point.Y >= selection_bounds.Y && point.Y <= selection_bounds.Y + selection_bounds.Height)
            {
                return true;
            }
            else return false;
        }// true if point are inside of RACTANGLE that are drawn around selection form

        public void MoveStart(Point point)
        {
            move_offset = new Point(point.X - selection_bounds.X, point.Y - selection_bounds.Y);
        }  //should be used befor selection movment to record cursor offset from upper left corner of selection 
        public void Move(Point point)
        {
            xg = point.X - move_offset.X;
            yg = point.Y - move_offset.Y;
            if (xg < 0) xg = 0;
            if (yg < 0) yg = 0;
            if (type == SelectionType.Rectangle || type == SelectionType.Elips)
            {
                if (xg + selection_rect.Width > layerSize.Width) xg = layerSize.Width - selection_rect.Width;
                if (yg + selection_rect.Height > layerSize.Height) yg = layerSize.Height - selection_rect.Height;
                selection_rect.X = xg;
                selection_rect.Y = yg;
                selection_bounds.X = xg;
                selection_bounds.Y = yg;
            }
            else if (type == SelectionType.FreeForm)
            {
                if (xg + selection_bounds.Width > layerSize.Width) xg = layerSize.Width - selection_bounds.Width;
                if (yg + selection_bounds.Height > layerSize.Height) yg = layerSize.Height - selection_bounds.Height;
                xg2 = xg - selection_bounds.X;
                yg2 = yg - selection_bounds.Y;
                selection_bounds.X = xg;
                selection_bounds.Y = yg;
                for (int i = 0; i < selection.Count; i++)
                {
                    selection[i] = new Point(selection[i].X + xg2, selection[i].Y + yg2);
                }
                selection_path.Reset();
                selection_path.AddLines(selection.ToArray());
                selection_path.CloseAllFigures();
            }
        }

        public Rectangle GetSelectionRectangle()
        {
            if (selection[0].X < selection[1].X)
            {
                selection_rect.X = selection[0].X;
                selection_rect.Width = selection[1].X - selection_rect.X;
            }
            else
            {
                selection_rect.X = selection[1].X;
                selection_rect.Width = selection[0].X - selection_rect.X;
            }
            if (selection[0].Y < selection[1].Y)
            {
                selection_rect.Y = selection[0].Y;
                selection_rect.Height = selection[1].Y - selection_rect.Y;
            }
            else
            {
                selection_rect.Y = selection[1].Y;
                selection_rect.Height = selection[0].Y - selection_rect.Y;
            }
            return selection_rect;
        }//for elips/ rectangle
        public GraphicsPath GetSelectionPath()
        {
            selection_path.Reset();
            selection_path.AddLines(selection.ToArray());
            return selection_path;
        }// for ff selection
        public Bitmap GetSelectionMask()
        {
            GraphicsPath tmppath = new GraphicsPath();
            if (type == SelectionType.Rectangle) tmppath.AddRectangle(selection_rect);
            else if (type == SelectionType.Elips) tmppath.AddEllipse(selection_rect);
            else if (type == SelectionType.FreeForm) tmppath.AddPath(selection_path, false);
            return Mask.GetMask(layerSize.Width, layerSize.Height, tmppath, invert);
        }// returns selection mask

        public void Invert()
        {
            if (invert) invert = false;
            else invert = true;
        } //invert selection

        private void calculate_bounds()
        {
            if (type == SelectionType.Rectangle || type == SelectionType.Elips)
            {
                selection_bounds = selection_rect;
            }
            else if (type == SelectionType.FreeForm)
            {
                float x = selection_path.PathPoints[0].X;
                float y = selection_path.PathPoints[0].Y;
                float width = 0;
                float height = 0;
                foreach (PointF point in selection_path.PathPoints)
                {
                    if (point.X < x)
                    {
                        x = point.X;
                    }
                    if (point.Y < y)
                    {
                        y = point.Y;
                    }
                }
                foreach (PointF point in selection_path.PathPoints)
                {
                    if (point.X - x > width)
                    {
                        width = point.X - x;
                    }
                    if (point.Y - y > height)
                    {
                        height = point.Y - y;
                    }
                }
                selection_bounds = new Rectangle((int)x, (int)y, (int)width, (int)height);
            }
        }//creates a rectangle drawn around selection form

    }

    public enum SelectionType
    {
        Rectangle = 1, Elips = 2, FreeForm = 3
    }
    public enum SelectionStatus
    {
        Waiting = 1, inProgress = 2, Finished = 3
    }
}
