using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Editor
{
    public partial class LayerOptionsForm : Form
    {
        public int opacity_val;
        private Layer layer;
        public LayerOptionsForm(Layer layer)
        {
            this.layer = layer;
            InitializeComponent();
            NameEditBox.Text = layer.Name;
            OpacityTrackBar.Value = layer.Opacity;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            layer.Name = NameEditBox.Text;
        }

        private void OpacityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            opacity_val = (int)Math.Round((OpacityTrackBar.Value / (255f / 100)));
            layer.Opacity = OpacityTrackBar.Value;
            label5.Text = opacity_val.ToString() + "%";
            label5.Location = new Point(MousePosition.X - this.Location.X - 10, label5.Location.Y);
        }
    }
}
