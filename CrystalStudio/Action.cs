using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_Editor
{
    public class Action //this class is used for declares an action that was applied to the EditableImage and required for redo/undo logic in EI class
    {
        public Actions Type;
        public List<int> LayerIDs;
        public Dictionary<int, Bitmap> LayerBitmaps;
        public Dictionary<int,Point> LayerPositions;

        public Action(Actions type, int layerID, Bitmap bitmap)
        {
            Type = type;
            LayerIDs = new List<int>() { layerID };
            LayerBitmaps =new Dictionary<int, Bitmap>();
            LayerBitmaps.Add(layerID, (Bitmap)bitmap.Clone());
        }//used for LayerChanged action type

        public Action(Actions type, int layerID, int x, int y)
        {
            Type = type;
            LayerIDs = new List<int>() { layerID };
            LayerPositions = new Dictionary<int, Point>();
            LayerPositions.Add(layerID, new Point(x, y));
        }//used for LayerMoved action type

        public Action(Actions type)
        {
            Type = type;
            LayerIDs = new List<int>();
            LayerBitmaps = new Dictionary<int, Bitmap>();
            LayerPositions = new Dictionary<int, Point>();
        }//declares empty action with selected type
        public void AddLayer(int layerID, Bitmap bitmap)
        {
            LayerIDs.Add(layerID);
            LayerBitmaps.Add(layerID, (Bitmap)bitmap.Clone());
        }//add affected layer to action
        public void AddLayer(int layerID, int x, int y)
        {
            LayerIDs.Add(layerID);
            LayerPositions.Add(layerID, new Point(x, y));
        }//add affected layer to action
    }
    public enum Actions //action types
    {
        LayerChanged = 1, //any change on layer bitmap
        LayerMoved = 2
    }
}
