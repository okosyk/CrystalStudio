using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Image_Editor
{
    public partial class MainForm : Form
    {

        List<EditableImage> Images = new List<EditableImage>();
        List<Viewport> Viewports = new List<Viewport>();
        List<PictureBox> PictureBoxes = new List<PictureBox>();
        SelectionType globalSelectionType = SelectionType.Rectangle;
        LayerOptionsForm layerOptions;
        List<Color> colors = new List<Color>() { Color.Black, Color.White };
        SimpleBrush brush;

[DllImport("user32.dll", CharSet = CharSet.Unicode)] //needed to use winapi functions directly
        static public extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);// sets scrollbars to show

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true; // dont seems to make any change but in theory should decrese flickering
            LayersListView.Scrollable = false;
            ShowScrollBar(this.LayersListView.Handle, (int)1, true);
            updateColorPanel();
            brush = new SimpleBrush(10,0,255);
            brush.color = colors[0];
            BrushSizeTrackBar.Value = brush.size;
            SmoothBrushTrackBar.Value = brush.smooth;
            opacityBrushTrackBar.Value = brush.opacity;
        }

        private void updateColorPanel()
        {
            mainColorPictureBox.Image = new Bitmap(mainColorPictureBox.Width, mainColorPictureBox.Height);
            additionalColorPictureBox.Image = new Bitmap(additionalColorPictureBox.Width, additionalColorPictureBox.Height);
            Graphics g = Graphics.FromImage(mainColorPictureBox.Image);
            g.FillRectangle(new SolidBrush(colors[0]), new Rectangle(0, 0, mainColorPictureBox.Image.Width, mainColorPictureBox.Image.Height));
            g = Graphics.FromImage(additionalColorPictureBox.Image);
            g.FillRectangle(new SolidBrush(colors[1]), new Rectangle(0, 0, additionalColorPictureBox.Image.Width, additionalColorPictureBox.Image.Height));
            g.Dispose();
            if (brush != null) brush.color = colors[0];
        }

        private EditableImage GetActiveImage()
        {
            return Images[ViewportsTabControl.SelectedIndex];
        }
        private Viewport GetActiveViewport()
        {
            return Viewports[ViewportsTabControl.SelectedIndex];
        }
        private PictureBox GetActivePictureBox()
        {
            return PictureBoxes[ViewportsTabControl.SelectedIndex];
        }

        // open/create
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
            OpenFileDialog.Title = "Choose file";
            OpenFileDialog.FilterIndex = 1;
            OpenFileDialog.Multiselect = true;
            OpenFileDialog.RestoreDirectory = true;
            OpenFileDialog.CheckFileExists = true;
            OpenFileDialog.CheckPathExists = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Random r = new Random();
                ViewportsTabControl.Visible = true;
                PictureBox tmp_pic_box;
                Viewport tmp_view_port;
                string tmp_path;
                EditableImage img;
                Panel tmp_panel;
                TabPage tmp_tab_page;
                for (int i = 0; i < OpenFileDialog.FileNames.Length; i++)
                {
                    tmp_path = Path.GetDirectoryName(OpenFileDialog.FileNames[i]) + "\\" + "~" + r.Next(1000000, 9999999).ToString() + Path.GetFileName(OpenFileDialog.FileNames[i]);

                    File.Copy(OpenFileDialog.FileNames[i], tmp_path);
                    File.SetAttributes(tmp_path, File.GetAttributes(tmp_path) | FileAttributes.Hidden);
                    img = new EditableImage(new Bitmap(tmp_path));
                    img.FileName = OpenFileDialog.FileNames[i];
                    img.TmpFileName = tmp_path;
                    img.onLayerChanged += Img_onLayerChange;

                    Images.Add(img);

                    tmp_panel = new Panel();
                    tmp_panel.AutoScroll = true;
                    tmp_panel.Dock = DockStyle.Fill;

                    tmp_pic_box = new PictureBox();
                    tmp_pic_box.Size = new Size(img.Width, img.Height);
                    tmp_pic_box.SizeMode = PictureBoxSizeMode.AutoSize;
                    tmp_pic_box.MouseMove += Pic_box_MouseMove;
                    tmp_pic_box.MouseLeave += Pic_box_MouseLeave;
                    tmp_pic_box.MouseEnter += Pic_box_MouseEnter;
                    tmp_tab_page = new TabPage(Path.GetFileNameWithoutExtension(OpenFileDialog.FileNames[i]));
                    ViewportsTabControl.TabPages.Add(tmp_tab_page);
                    tmp_panel.Controls.Add(tmp_pic_box);
                    PictureBoxes.Add(tmp_pic_box);
                    tmp_tab_page.Controls.Add(tmp_panel);
                    tmp_view_port = new Viewport(img, tmp_pic_box.Handle);
                    tmp_view_port.ChangeBrush(brush);
                    tmp_view_port.onToolChange += Viewport_onToolChange;
                    tmp_view_port.onMoveFinished += Img_onLayerChange;
                    Viewports.Add(tmp_view_port);
                }
                GetActiveImage().Update();

            }
        }
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm create_form = new CreateForm();
            if (create_form.ShowDialog() == DialogResult.OK)
            {
                if (create_form.WidthTextBox.Text != string.Empty && create_form.HeightTextBox.Text != string.Empty)
                {
                    try
                    {
                        Viewport tmp_view_port;
                        ViewportsTabControl.Visible = true;
                        Size size = new Size(int.Parse(create_form.WidthTextBox.Text), int.Parse(create_form.HeightTextBox.Text));
                        EditableImage img = new EditableImage(new Bitmap(size.Width, size.Height,PixelFormat.Format32bppArgb));
                        img.onLayerChanged += Img_onLayerChange;
                        Images.Add(img);
                        Panel tmp_panel = new Panel();
                        tmp_panel.AutoScroll = true;
                        tmp_panel.Dock = DockStyle.Fill;
                        PictureBox tmp_pic_box = new PictureBox();
                        tmp_pic_box.Size = size;
                        tmp_pic_box.SizeMode = PictureBoxSizeMode.Zoom;
                        tmp_pic_box.MouseMove += Pic_box_MouseMove;
                        tmp_pic_box.MouseDown += Pic_box_MouseLeave;
                        PictureBoxes.Add(tmp_pic_box);
                        TabPage tmp_tab_page = new TabPage("New picture");
                        ViewportsTabControl.TabPages.Add(tmp_tab_page);
                        tmp_panel.Controls.Add(tmp_pic_box);
                        tmp_tab_page.Controls.Add(tmp_panel);
                        tmp_view_port = new Viewport(img, tmp_pic_box.Handle);
                        tmp_view_port.ChangeBrush(brush);
                        tmp_view_port.onToolChange += Viewport_onToolChange;
                        tmp_view_port.onMoveFinished += Img_onLayerChange;
                        Viewports.Add(tmp_view_port);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Incorrect parameters!");
                    }
                }
                else MessageBox.Show("Please, enter the size parameters!");
            }
        }

        // save/saveas
        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
            SaveFileDialog.Title = "Save an Image File";
            SaveFileDialog.FilterIndex = 1;
            SaveFileDialog.RestoreDirectory = true;
            SaveFileDialog.CheckPathExists = true;
            SaveFileDialog.FileName = "";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap img;
                    if (SaveFileDialog.FileName != "")
                    {
                        switch (SaveFileDialog.FilterIndex)
                        {
                            case 1:
                                img = GetActiveImage().RenderImage(ImageFormat.Jpeg);
                                img.Save(SaveFileDialog.FileName);
                                break;

                            case 2:
                                img = GetActiveImage().RenderImage(ImageFormat.Png);
                                img.Save(SaveFileDialog.FileName);
                                break;

                            case 3:
                                img = GetActiveImage().RenderImage(ImageFormat.Bmp);
                                img.Save(SaveFileDialog.FileName);
                                break;
                        }
                        GetActiveImage().FileName = SaveFileDialog.FileName;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Saving failed!");
                }
            }
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GetActiveImage().FileName == "")
            {
                saveasToolStripMenuItem_Click(sender, e);
            }
            else
            {
                List<string> ext = new List<string>() { ".jpg", ".bmp", ".png" };
                Bitmap img;
                switch (ext.IndexOf(Path.GetExtension(GetActiveImage().FileName)))
                {
                    case 0:
                        img = GetActiveImage().RenderImage(ImageFormat.Jpeg);
                        img.Save(GetActiveImage().FileName);
                        break;

                    case 1:
                        img = GetActiveImage().RenderImage(ImageFormat.Png);
                        img.Save(GetActiveImage().FileName);
                        break;

                    case 2:
                        img = GetActiveImage().RenderImage(ImageFormat.Bmp);
                        img.Save(GetActiveImage().FileName);
                        break;
                }
            }
        }

        // close/exit
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmp = GetActiveImage().TmpFileName;
            GetActiveViewport().Dispose();
            GetActiveImage().DisposeFile();
            GetActivePictureBox().Dispose();
            Images.RemoveAt(ViewportsTabControl.SelectedIndex);
            Viewports.RemoveAt(ViewportsTabControl.SelectedIndex);
            PictureBoxes.RemoveAt(ViewportsTabControl.SelectedIndex);
            CursorCoordinatesLabel.Text = "";

            ViewportsTabControl.TabPages.Remove(ViewportsTabControl.SelectedTab);
            if (tmp != "")
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(tmp);
            }
            Img_onLayerChange();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //layers new/from Image
        private void NewLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveImage().AddLayer();
        }
        private void layerFromImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
            OpenFileDialog.Title = "Choose file";
            OpenFileDialog.FilterIndex = 1;
            OpenFileDialog.Multiselect = true;
            OpenFileDialog.RestoreDirectory = true;
            OpenFileDialog.CheckFileExists = true;
            OpenFileDialog.CheckPathExists = true;
            GetActiveViewport().ResetTool();
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap tmp;
                foreach (string file in OpenFileDialog.FileNames)
                {
                    tmp = new Bitmap(file);
                    GetActiveImage().AddLayer(tmp, Path.GetFileNameWithoutExtension(file));
                    tmp.Dispose();
                }

            }
        }

        //tools
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ImageTools.Rotate(GetActiveImage(), RotateFlipType.Rotate180FlipNone);
        } //rotate 180
        private void clockwiseToolStripMenuItem_Click(object sender, EventArgs e)//rotate 90clockwise
        {
            ImageTools.Rotate(GetActiveImage(), RotateFlipType.Rotate90FlipNone);
        }
        private void counterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)//rotate 270
        {
            ImageTools.Rotate(GetActiveImage(), RotateFlipType.Rotate270FlipNone);
        }
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)//flip x
        {
            ImageTools.Rotate(GetActiveImage(), RotateFlipType.RotateNoneFlipX);
        }
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)//flip y
        {
            ImageTools.Rotate(GetActiveImage(), RotateFlipType.RotateNoneFlipY);
        }
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)//grayscale
        {
            ImageTools.ToGrayScale(GetActiveImage());
        }
        private void blackWhiteToolStripMenuItem_Click(object sender, EventArgs e)//b&w
        {
            ImageTools.ToBlackWhite(GetActiveImage());
        }
        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)//rgb
        {
            ImageTools.ToRGB(GetActiveImage());
        }
        private void aRGB32bppToolStripMenuItem_Click(object sender, EventArgs e)//argb
        {
            ImageTools.ToARGB(GetActiveImage());
        }

        // redo/undo
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)//redo
        {
            GetActiveImage().Redo();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)//undo
        {
            GetActiveImage().Undo();
        }

        //selection tool button
        private void button_select_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GetActiveViewport().SelectionStart(globalSelectionType);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Controls.Add(SelectionToolsPanel);
                Controls.SetChildIndex(SelectionToolsPanel, 0);
                SelectionToolsPanel.Location = new Point(SelectionToolButton.Location.X + SelectionToolButton.Width, SelectionToolButton.Location.Y + MenuStrip.Height);
                SelectionToolsPanel.Visible = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SelectionToolButton.Image = ElipseSelectionButton.Image;
            SelectionToolsPanel.Visible = false;
            Controls.RemoveAt(0);
            globalSelectionType = SelectionType.Elips;
            button_select_MouseDown(sender, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1));
            SelectionToolButton.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelectionToolButton.Image = RectangleSelectionButton.Image;
            SelectionToolsPanel.Visible = false;
            Controls.RemoveAt(0);
            globalSelectionType = SelectionType.Rectangle;
            button_select_MouseDown(sender, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1));
            SelectionToolButton.Focus();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SelectionToolButton.Image = FreeFormSelectionButton.Image;
            SelectionToolsPanel.Visible = false;
            Controls.RemoveAt(0);
            globalSelectionType = SelectionType.FreeForm;
            button_select_MouseDown(sender, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1));
            SelectionToolButton.Focus();
        }

        //move selection button
        private void button_pointer_Click(object sender, EventArgs e)
        {
            GetActiveViewport().MoveStart();
        }

        // delete/copy/cut/paste
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveViewport().DeleteSelection();
        }

        //selection
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveViewport().SelectAll();
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveViewport().ClearSelection();
        }
        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveViewport().InvertSelection();
        }

        //Image events
        private void Img_onLayerChange()
        {
            LayersListView.BeginUpdate();
            LayersListView.Clear();
            if (Images.Count != 0)
            {
                List<Layer> layers = GetActiveImage().GetLayers();
                ListViewItem nli;
                ImageList imgList = new ImageList();
                if (layers.Count != 0)
                {
                    imgList.ImageSize = layers[0].Thumbnail.Size;
                }
                imgList.ColorDepth = ColorDepth.Depth32Bit;
                LayersListView.SmallImageList = imgList;
                for (int i = layers.Count - 1; i > -1; i--)
                {
                    imgList.Images.Add(layers[i].Thumbnail);
                    nli = new ListViewItem(layers[i].Name, layers.Count - i - 1);
                    nli.Checked = layers[i].Visble;

                    if (i == GetActiveImage().ActiveLayerID)
                    {
                        nli.BackColor = Color.Gray;
                    }
                    LayersListView.ItemChecked -=LayersListView_ItemChecked;
                    LayersListView.Items.Add(nli);
                    LayersListView.ItemChecked += LayersListView_ItemChecked;
                }
            }
            LayersListView.EndUpdate();
        }

        //Viewport events
        private void Viewport_onToolChange()
        {
            ViewportTool tool = GetActiveViewport().CurentTool;
            if (tool == ViewportTool.Move || tool == ViewportTool.MoveSelection)
            {
                MoveToolButton.Focus();
            }
            else if (tool == ViewportTool.Selection)
            {
                SelectionToolButton.Focus();
            }
        }

        //PictureBox events
        private async void Pic_box_MouseEnter(object sender, EventArgs e)
        {
            
        }
        private void Pic_box_MouseLeave(object sender, EventArgs e)
        {
            
        }
        private void Pic_box_MouseMove(object sender, MouseEventArgs e)
        {
            CursorCoordinatesLabel.Text = (1 + e.X).ToString() + ", " + (e.Y + 1).ToString() + "px";
        }

        //Form events
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewportsTabControl.Dispose();

            foreach (EditableImage item in Images)
            {
                item.DisposeFile();
                if (item.TmpFileName != "")
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(item.TmpFileName);
                }
            }

        }

        //TabControl events -> refer to image events
        private void ViewportsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Images.Count != 0)
            {
                GetActiveViewport().Update();
                Img_onLayerChange();
            }
        }

        //panels events
        private void LayersListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            GetActiveImage().ChangeLayerVisibility(LayersListView.Items.Count - e.Item.Index, e.Item.Checked);
        }


        private void LayersListView_SelectedIndexChanged(object sender, EventArgs e)
        {


            GetActiveImage().ActiveLayerID = LayersListView.Items.Count - 1 - LayersListView.SelectedItems[0].Index;
            Img_onLayerChange();

            if (MouseButtons == MouseButtons.Right)
            {
                LayerOptionsContextMenu.Show(MousePosition);
            }

        }

        private void layerOptionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            layerOptions = new LayerOptionsForm(GetActiveImage().ActiveLayer);
            layerOptions.button1.Click += applyLayerOptions_Click;
            layerOptions.Show();
        }

        private void applyLayerOptions_Click(object sender, EventArgs e)
        {
            Img_onLayerChange();
        }

        private void BrushlToolButton_Click(object sender, EventArgs e)
        {
            GetActiveViewport().StartPaint(brush);
        }

        private void BrushSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            brush.size = BrushSizeTrackBar.Value;
        }

        private void chabgeActiveColorButton_Click(object sender, EventArgs e)
        {
            Color tmp = colors[0];
            colors[0] = colors[1];
            colors[1] = tmp;
            updateColorPanel();
        }

        private void mainColorPictureBox_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = colors[0];
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                colors[0] = colorDialog1.Color;
                updateColorPanel();
            }
        }

        private void additionalColorPictureBox_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = colors[1];
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colors[1] = colorDialog1.Color;
                updateColorPanel();
            }
        }

        private void SmoothBrushTrackBar_ValueChanged(object sender, EventArgs e)
        {
            brush.smooth = 100-SmoothBrushTrackBar.Value;
        }

        private void opacityBrushTrackBar_ValueChanged(object sender, EventArgs e)
        {
            brush.opacity = opacityBrushTrackBar.Value;
        }

        private void EarserToolButton_Click(object sender, EventArgs e)
        {
            GetActiveViewport().StartEarse(brush);
        }

        private void BucketToolButton_Click(object sender, EventArgs e)
        {
            GetActiveViewport().StartFill();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ToolsPanel.Visible)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }
    }
}
