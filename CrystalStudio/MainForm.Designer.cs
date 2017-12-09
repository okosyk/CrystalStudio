namespace Image_Editor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ARGB32bppModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RGBModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayscaleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureRotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.R180toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RClockwise90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RCounterclockwise90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerFromImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.LayerOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SInvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.CursorCoordinatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SelectionToolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.RectangleSelectionButton = new System.Windows.Forms.Button();
            this.ElipseSelectionButton = new System.Windows.Forms.Button();
            this.FreeFormSelectionButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InformationLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.BrushSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SmoothBrushTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.opacityBrushTrackBar = new System.Windows.Forms.TrackBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ImageInfoTabControl = new System.Windows.Forms.TabControl();
            this.LayersTab = new System.Windows.Forms.TabPage();
            this.LayersListView = new System.Windows.Forms.ListView();
            this.LayerOptionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.layerOptionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chabgeActiveColorButton = new System.Windows.Forms.Button();
            this.mainColorPictureBox = new System.Windows.Forms.PictureBox();
            this.additionalColorPictureBox = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ToolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MoveToolButton = new System.Windows.Forms.Button();
            this.BrushlToolButton = new System.Windows.Forms.Button();
            this.EarserToolButton = new System.Windows.Forms.Button();
            this.SelectionToolButton = new System.Windows.Forms.Button();
            this.BucketToolButton = new System.Windows.Forms.Button();
            this.ViewportsTabControl = new System.Windows.Forms.TabControl();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SelectionToolsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.InformationLayoutPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrushSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothBrushTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBrushTrackBar)).BeginInit();
            this.ImageInfoTabControl.SuspendLayout();
            this.LayersTab.SuspendLayout();
            this.LayerOptionsContextMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalColorPictureBox)).BeginInit();
            this.ToolsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ImageToolStripMenuItem,
            this.LayersToolStripMenuItem,
            this.SelectionToolStripMenuItem,
            this.WindowToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(904, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.CreateToolStripMenuItem.Text = "Create";
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.SaveAsToolStripMenuItem.Text = "Save as";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.CloseToolStripMenuItem.Text = "Close";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.RedoToolStripMenuItem,
            this.toolStripSeparator3,
            this.DeleteToolStripMenuItem,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.UndoToolStripMenuItem.Text = "Undo";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // RedoToolStripMenuItem
            // 
            this.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem";
            this.RedoToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.RedoToolStripMenuItem.Text = "Redo";
            this.RedoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(104, 6);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.CutToolStripMenuItem.Text = "Cut";
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.CopyToolStripMenuItem.Text = "Copy";
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.PasteToolStripMenuItem.Text = "Paste";
            // 
            // ImageToolStripMenuItem
            // 
            this.ImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModeToolStripMenuItem,
            this.PictureRotationToolStripMenuItem});
            this.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem";
            this.ImageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ImageToolStripMenuItem.Text = "Image";
            // 
            // ModeToolStripMenuItem
            // 
            this.ModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ARGB32bppModeToolStripMenuItem,
            this.RGBModeToolStripMenuItem,
            this.GrayscaleModeToolStripMenuItem});
            this.ModeToolStripMenuItem.Name = "ModeToolStripMenuItem";
            this.ModeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ModeToolStripMenuItem.Text = "Mode";
            // 
            // ARGB32bppModeToolStripMenuItem
            // 
            this.ARGB32bppModeToolStripMenuItem.Name = "ARGB32bppModeToolStripMenuItem";
            this.ARGB32bppModeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ARGB32bppModeToolStripMenuItem.Text = "ARGB(32bpp)";
            // 
            // RGBModeToolStripMenuItem
            // 
            this.RGBModeToolStripMenuItem.Name = "RGBModeToolStripMenuItem";
            this.RGBModeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.RGBModeToolStripMenuItem.Text = "RGB(24bpp)";
            // 
            // GrayscaleModeToolStripMenuItem
            // 
            this.GrayscaleModeToolStripMenuItem.Name = "GrayscaleModeToolStripMenuItem";
            this.GrayscaleModeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.GrayscaleModeToolStripMenuItem.Text = "Grayscale(16bpp/8bpp)";
            this.GrayscaleModeToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // PictureRotationToolStripMenuItem
            // 
            this.PictureRotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.R180toolStripMenuItem,
            this.RClockwise90ToolStripMenuItem,
            this.RCounterclockwise90ToolStripMenuItem,
            this.toolStripSeparator2,
            this.FHorizontalToolStripMenuItem,
            this.FVerticalToolStripMenuItem});
            this.PictureRotationToolStripMenuItem.Name = "PictureRotationToolStripMenuItem";
            this.PictureRotationToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.PictureRotationToolStripMenuItem.Text = "Picture rotation";
            // 
            // R180toolStripMenuItem
            // 
            this.R180toolStripMenuItem.Name = "R180toolStripMenuItem";
            this.R180toolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.R180toolStripMenuItem.Text = "180";
            this.R180toolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // RClockwise90ToolStripMenuItem
            // 
            this.RClockwise90ToolStripMenuItem.Name = "RClockwise90ToolStripMenuItem";
            this.RClockwise90ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.RClockwise90ToolStripMenuItem.Text = "90 clockwise";
            this.RClockwise90ToolStripMenuItem.Click += new System.EventHandler(this.clockwiseToolStripMenuItem_Click);
            // 
            // RCounterclockwise90ToolStripMenuItem
            // 
            this.RCounterclockwise90ToolStripMenuItem.Name = "RCounterclockwise90ToolStripMenuItem";
            this.RCounterclockwise90ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.RCounterclockwise90ToolStripMenuItem.Text = "90 counterclockwise";
            this.RCounterclockwise90ToolStripMenuItem.Click += new System.EventHandler(this.counterclockwiseToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // FHorizontalToolStripMenuItem
            // 
            this.FHorizontalToolStripMenuItem.Name = "FHorizontalToolStripMenuItem";
            this.FHorizontalToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.FHorizontalToolStripMenuItem.Text = "Flip horizontal";
            this.FHorizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // FVerticalToolStripMenuItem
            // 
            this.FVerticalToolStripMenuItem.Name = "FVerticalToolStripMenuItem";
            this.FVerticalToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.FVerticalToolStripMenuItem.Text = "Flip vertical";
            this.FVerticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // LayersToolStripMenuItem
            // 
            this.LayersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewLayerToolStripMenuItem,
            this.layerFromImageToolStripMenuItem,
            this.toolStripSeparator4,
            this.LayerOptionsToolStripMenuItem});
            this.LayersToolStripMenuItem.Name = "LayersToolStripMenuItem";
            this.LayersToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.LayersToolStripMenuItem.Text = "Layers";
            // 
            // NewLayerToolStripMenuItem
            // 
            this.NewLayerToolStripMenuItem.Name = "NewLayerToolStripMenuItem";
            this.NewLayerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.NewLayerToolStripMenuItem.Text = "New layer";
            this.NewLayerToolStripMenuItem.Click += new System.EventHandler(this.NewLayerToolStripMenuItem_Click);
            // 
            // layerFromImageToolStripMenuItem
            // 
            this.layerFromImageToolStripMenuItem.Name = "layerFromImageToolStripMenuItem";
            this.layerFromImageToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.layerFromImageToolStripMenuItem.Text = "Layer from image";
            this.layerFromImageToolStripMenuItem.Click += new System.EventHandler(this.layerFromImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
            // 
            // LayerOptionsToolStripMenuItem
            // 
            this.LayerOptionsToolStripMenuItem.Name = "LayerOptionsToolStripMenuItem";
            this.LayerOptionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.LayerOptionsToolStripMenuItem.Text = "Layer options";
            // 
            // SelectionToolStripMenuItem
            // 
            this.SelectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SAllToolStripMenuItem,
            this.SInvertToolStripMenuItem,
            this.SClearToolStripMenuItem});
            this.SelectionToolStripMenuItem.Name = "SelectionToolStripMenuItem";
            this.SelectionToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.SelectionToolStripMenuItem.Text = "Selection";
            // 
            // SAllToolStripMenuItem
            // 
            this.SAllToolStripMenuItem.Name = "SAllToolStripMenuItem";
            this.SAllToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.SAllToolStripMenuItem.Text = "All";
            this.SAllToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // SInvertToolStripMenuItem
            // 
            this.SInvertToolStripMenuItem.Name = "SInvertToolStripMenuItem";
            this.SInvertToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.SInvertToolStripMenuItem.Text = "Invert";
            this.SInvertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // SClearToolStripMenuItem
            // 
            this.SClearToolStripMenuItem.Name = "SClearToolStripMenuItem";
            this.SClearToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.SClearToolStripMenuItem.Text = "Clear";
            this.SClearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.WindowToolStripMenuItem.Text = "Window";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProgramToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutProgramToolStripMenuItem
            // 
            this.AboutProgramToolStripMenuItem.Name = "AboutProgramToolStripMenuItem";
            this.AboutProgramToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.AboutProgramToolStripMenuItem.Text = "About program";
            this.AboutProgramToolStripMenuItem.Click += new System.EventHandler(this.AboutProgramToolStripMenuItem_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CursorCoordinatesLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 411);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(904, 22);
            this.StatusStrip.TabIndex = 6;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // CursorCoordinatesLabel
            // 
            this.CursorCoordinatesLabel.Name = "CursorCoordinatesLabel";
            this.CursorCoordinatesLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // SelectionToolsPanel
            // 
            this.SelectionToolsPanel.AutoSize = true;
            this.SelectionToolsPanel.Controls.Add(this.RectangleSelectionButton);
            this.SelectionToolsPanel.Controls.Add(this.ElipseSelectionButton);
            this.SelectionToolsPanel.Controls.Add(this.FreeFormSelectionButton);
            this.SelectionToolsPanel.Location = new System.Drawing.Point(580, 411);
            this.SelectionToolsPanel.Name = "SelectionToolsPanel";
            this.SelectionToolsPanel.Size = new System.Drawing.Size(132, 44);
            this.SelectionToolsPanel.TabIndex = 11;
            this.SelectionToolsPanel.Visible = false;
            // 
            // RectangleSelectionButton
            // 
            this.RectangleSelectionButton.AutoSize = true;
            this.RectangleSelectionButton.Image = ((System.Drawing.Image)(resources.GetObject("RectangleSelectionButton.Image")));
            this.RectangleSelectionButton.Location = new System.Drawing.Point(3, 3);
            this.RectangleSelectionButton.Name = "RectangleSelectionButton";
            this.RectangleSelectionButton.Size = new System.Drawing.Size(38, 38);
            this.RectangleSelectionButton.TabIndex = 2;
            this.RectangleSelectionButton.UseVisualStyleBackColor = true;
            this.RectangleSelectionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ElipseSelectionButton
            // 
            this.ElipseSelectionButton.AutoSize = true;
            this.ElipseSelectionButton.Image = global::Image_Editor.Properties.Resources.zoom;
            this.ElipseSelectionButton.Location = new System.Drawing.Point(47, 3);
            this.ElipseSelectionButton.Name = "ElipseSelectionButton";
            this.ElipseSelectionButton.Size = new System.Drawing.Size(38, 38);
            this.ElipseSelectionButton.TabIndex = 3;
            this.ElipseSelectionButton.UseVisualStyleBackColor = true;
            this.ElipseSelectionButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // FreeFormSelectionButton
            // 
            this.FreeFormSelectionButton.AutoSize = true;
            this.FreeFormSelectionButton.Image = ((System.Drawing.Image)(resources.GetObject("FreeFormSelectionButton.Image")));
            this.FreeFormSelectionButton.Location = new System.Drawing.Point(91, 3);
            this.FreeFormSelectionButton.Name = "FreeFormSelectionButton";
            this.FreeFormSelectionButton.Size = new System.Drawing.Size(38, 38);
            this.FreeFormSelectionButton.TabIndex = 4;
            this.FreeFormSelectionButton.UseVisualStyleBackColor = true;
            this.FreeFormSelectionButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InformationLayoutPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(718, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 387);
            this.panel1.TabIndex = 12;
            // 
            // InformationLayoutPanel
            // 
            this.InformationLayoutPanel.Controls.Add(this.tabControl1);
            this.InformationLayoutPanel.Controls.Add(this.ImageInfoTabControl);
            this.InformationLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InformationLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.InformationLayoutPanel.Name = "InformationLayoutPanel";
            this.InformationLayoutPanel.Size = new System.Drawing.Size(186, 387);
            this.InformationLayoutPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(179, 209);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.BrushSizeTrackBar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SmoothBrushTrackBar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.opacityBrushTrackBar);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(171, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Brush options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Size";
            // 
            // BrushSizeTrackBar
            // 
            this.BrushSizeTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.BrushSizeTrackBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.BrushSizeTrackBar.Location = new System.Drawing.Point(58, 8);
            this.BrushSizeTrackBar.Maximum = 300;
            this.BrushSizeTrackBar.Minimum = 1;
            this.BrushSizeTrackBar.Name = "BrushSizeTrackBar";
            this.BrushSizeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.BrushSizeTrackBar.TabIndex = 7;
            this.BrushSizeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BrushSizeTrackBar.Value = 1;
            this.BrushSizeTrackBar.ValueChanged += new System.EventHandler(this.BrushSizeTrackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Smooth";
            // 
            // SmoothBrushTrackBar
            // 
            this.SmoothBrushTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.SmoothBrushTrackBar.Location = new System.Drawing.Point(58, 51);
            this.SmoothBrushTrackBar.Maximum = 100;
            this.SmoothBrushTrackBar.Name = "SmoothBrushTrackBar";
            this.SmoothBrushTrackBar.Size = new System.Drawing.Size(104, 45);
            this.SmoothBrushTrackBar.TabIndex = 9;
            this.SmoothBrushTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SmoothBrushTrackBar.ValueChanged += new System.EventHandler(this.SmoothBrushTrackBar_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Opacity";
            // 
            // opacityBrushTrackBar
            // 
            this.opacityBrushTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.opacityBrushTrackBar.Location = new System.Drawing.Point(58, 94);
            this.opacityBrushTrackBar.Maximum = 255;
            this.opacityBrushTrackBar.Name = "opacityBrushTrackBar";
            this.opacityBrushTrackBar.Size = new System.Drawing.Size(104, 45);
            this.opacityBrushTrackBar.TabIndex = 11;
            this.opacityBrushTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.opacityBrushTrackBar.Value = 255;
            this.opacityBrushTrackBar.ValueChanged += new System.EventHandler(this.opacityBrushTrackBar_ValueChanged);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(165, 177);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // ImageInfoTabControl
            // 
            this.ImageInfoTabControl.Controls.Add(this.LayersTab);
            this.ImageInfoTabControl.Location = new System.Drawing.Point(3, 218);
            this.ImageInfoTabControl.Name = "ImageInfoTabControl";
            this.ImageInfoTabControl.SelectedIndex = 0;
            this.ImageInfoTabControl.Size = new System.Drawing.Size(179, 187);
            this.ImageInfoTabControl.TabIndex = 0;
            // 
            // LayersTab
            // 
            this.LayersTab.Controls.Add(this.LayersListView);
            this.LayersTab.Location = new System.Drawing.Point(4, 22);
            this.LayersTab.Name = "LayersTab";
            this.LayersTab.Padding = new System.Windows.Forms.Padding(3);
            this.LayersTab.Size = new System.Drawing.Size(171, 161);
            this.LayersTab.TabIndex = 0;
            this.LayersTab.Text = "Layers";
            this.LayersTab.UseVisualStyleBackColor = true;
            // 
            // LayersListView
            // 
            this.LayersListView.AllowDrop = true;
            this.LayersListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LayersListView.CheckBoxes = true;
            this.LayersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayersListView.LabelEdit = true;
            this.LayersListView.Location = new System.Drawing.Point(3, 3);
            this.LayersListView.MultiSelect = false;
            this.LayersListView.Name = "LayersListView";
            this.LayersListView.Size = new System.Drawing.Size(165, 155);
            this.LayersListView.TabIndex = 1;
            this.LayersListView.UseCompatibleStateImageBehavior = false;
            this.LayersListView.View = System.Windows.Forms.View.SmallIcon;
            this.LayersListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LayersListView_ItemChecked);
            this.LayersListView.SelectedIndexChanged += new System.EventHandler(this.LayersListView_SelectedIndexChanged);
            // 
            // LayerOptionsContextMenu
            // 
            this.LayerOptionsContextMenu.AccessibleName = "options_context_strip";
            this.LayerOptionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layerOptionsToolStripMenuItem1});
            this.LayerOptionsContextMenu.Name = "LayerOptionsContextMenu";
            this.LayerOptionsContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.LayerOptionsContextMenu.Size = new System.Drawing.Size(146, 26);
            this.LayerOptionsContextMenu.Text = "Layer options";
            // 
            // layerOptionsToolStripMenuItem1
            // 
            this.layerOptionsToolStripMenuItem1.Name = "layerOptionsToolStripMenuItem1";
            this.layerOptionsToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.layerOptionsToolStripMenuItem1.Text = "Layer options";
            this.layerOptionsToolStripMenuItem1.Click += new System.EventHandler(this.layerOptionsToolStripMenuItem1_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.ToolsPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(54, 387);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chabgeActiveColorButton);
            this.panel3.Controls.Add(this.mainColorPictureBox);
            this.panel3.Controls.Add(this.additionalColorPictureBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 304);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(54, 51);
            this.panel3.TabIndex = 15;
            // 
            // chabgeActiveColorButton
            // 
            this.chabgeActiveColorButton.Location = new System.Drawing.Point(2, 35);
            this.chabgeActiveColorButton.Name = "chabgeActiveColorButton";
            this.chabgeActiveColorButton.Size = new System.Drawing.Size(15, 15);
            this.chabgeActiveColorButton.TabIndex = 1;
            this.chabgeActiveColorButton.Text = "button1";
            this.chabgeActiveColorButton.UseVisualStyleBackColor = true;
            this.chabgeActiveColorButton.Click += new System.EventHandler(this.chabgeActiveColorButton_Click);
            // 
            // mainColorPictureBox
            // 
            this.mainColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainColorPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mainColorPictureBox.Name = "mainColorPictureBox";
            this.mainColorPictureBox.Size = new System.Drawing.Size(40, 40);
            this.mainColorPictureBox.TabIndex = 0;
            this.mainColorPictureBox.TabStop = false;
            this.mainColorPictureBox.Click += new System.EventHandler(this.mainColorPictureBox_Click);
            // 
            // additionalColorPictureBox
            // 
            this.additionalColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.additionalColorPictureBox.Location = new System.Drawing.Point(9, 8);
            this.additionalColorPictureBox.Name = "additionalColorPictureBox";
            this.additionalColorPictureBox.Size = new System.Drawing.Size(40, 40);
            this.additionalColorPictureBox.TabIndex = 0;
            this.additionalColorPictureBox.TabStop = false;
            this.additionalColorPictureBox.Click += new System.EventHandler(this.additionalColorPictureBox_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 355);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(54, 32);
            this.panel4.TabIndex = 14;
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Controls.Add(this.MoveToolButton);
            this.ToolsPanel.Controls.Add(this.BrushlToolButton);
            this.ToolsPanel.Controls.Add(this.EarserToolButton);
            this.ToolsPanel.Controls.Add(this.SelectionToolButton);
            this.ToolsPanel.Controls.Add(this.BucketToolButton);
            this.ToolsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ToolsPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(54, 231);
            this.ToolsPanel.TabIndex = 11;
            // 
            // MoveToolButton
            // 
            this.MoveToolButton.AutoSize = true;
            this.MoveToolButton.Image = ((System.Drawing.Image)(resources.GetObject("MoveToolButton.Image")));
            this.MoveToolButton.Location = new System.Drawing.Point(3, 3);
            this.MoveToolButton.Name = "MoveToolButton";
            this.MoveToolButton.Size = new System.Drawing.Size(38, 38);
            this.MoveToolButton.TabIndex = 0;
            this.MoveToolButton.UseVisualStyleBackColor = true;
            this.MoveToolButton.Click += new System.EventHandler(this.button_pointer_Click);
            // 
            // BrushlToolButton
            // 
            this.BrushlToolButton.AutoSize = true;
            this.BrushlToolButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushlToolButton.Image")));
            this.BrushlToolButton.Location = new System.Drawing.Point(3, 47);
            this.BrushlToolButton.Name = "BrushlToolButton";
            this.BrushlToolButton.Size = new System.Drawing.Size(38, 38);
            this.BrushlToolButton.TabIndex = 2;
            this.BrushlToolButton.UseVisualStyleBackColor = true;
            this.BrushlToolButton.Click += new System.EventHandler(this.BrushlToolButton_Click);
            // 
            // EarserToolButton
            // 
            this.EarserToolButton.AutoSize = true;
            this.EarserToolButton.Image = ((System.Drawing.Image)(resources.GetObject("EarserToolButton.Image")));
            this.EarserToolButton.Location = new System.Drawing.Point(3, 91);
            this.EarserToolButton.Name = "EarserToolButton";
            this.EarserToolButton.Size = new System.Drawing.Size(38, 38);
            this.EarserToolButton.TabIndex = 4;
            this.EarserToolButton.UseVisualStyleBackColor = true;
            this.EarserToolButton.Click += new System.EventHandler(this.EarserToolButton_Click);
            // 
            // SelectionToolButton
            // 
            this.SelectionToolButton.AutoSize = true;
            this.SelectionToolButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectionToolButton.Image")));
            this.SelectionToolButton.Location = new System.Drawing.Point(3, 135);
            this.SelectionToolButton.Name = "SelectionToolButton";
            this.SelectionToolButton.Size = new System.Drawing.Size(38, 38);
            this.SelectionToolButton.TabIndex = 1;
            this.SelectionToolButton.UseVisualStyleBackColor = true;
            this.SelectionToolButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_select_MouseDown);
            // 
            // BucketToolButton
            // 
            this.BucketToolButton.AutoSize = true;
            this.BucketToolButton.Image = ((System.Drawing.Image)(resources.GetObject("BucketToolButton.Image")));
            this.BucketToolButton.Location = new System.Drawing.Point(3, 179);
            this.BucketToolButton.Name = "BucketToolButton";
            this.BucketToolButton.Size = new System.Drawing.Size(38, 38);
            this.BucketToolButton.TabIndex = 3;
            this.BucketToolButton.UseVisualStyleBackColor = true;
            this.BucketToolButton.Click += new System.EventHandler(this.BucketToolButton_Click);
            // 
            // ViewportsTabControl
            // 
            this.ViewportsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewportsTabControl.Location = new System.Drawing.Point(54, 24);
            this.ViewportsTabControl.Name = "ViewportsTabControl";
            this.ViewportsTabControl.SelectedIndex = 0;
            this.ViewportsTabControl.Size = new System.Drawing.Size(664, 387);
            this.ViewportsTabControl.TabIndex = 15;
            this.ViewportsTabControl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 433);
            this.Controls.Add(this.ViewportsTabControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SelectionToolsPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Image Editor";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.SelectionToolsPanel.ResumeLayout(false);
            this.SelectionToolsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.InformationLayoutPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrushSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothBrushTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBrushTrackBar)).EndInit();
            this.ImageInfoTabControl.ResumeLayout(false);
            this.LayersTab.ResumeLayout(false);
            this.LayerOptionsContextMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalColorPictureBox)).EndInit();
            this.ToolsPanel.ResumeLayout(false);
            this.ToolsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RGBModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GrayscaleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PictureRotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem R180toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RClockwise90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RCounterclockwise90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LayerOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem FHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ARGB32bppModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel CursorCoordinatesLabel;
        private System.Windows.Forms.FlowLayoutPanel SelectionToolsPanel;
        private System.Windows.Forms.Button RectangleSelectionButton;
        private System.Windows.Forms.Button ElipseSelectionButton;
        private System.Windows.Forms.Button FreeFormSelectionButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SInvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel InformationLayoutPanel;
        private System.Windows.Forms.TabControl ImageInfoTabControl;
        private System.Windows.Forms.TabPage LayersTab;
        private System.Windows.Forms.ListView LayersListView;
        private System.Windows.Forms.ToolStripMenuItem layerFromImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip LayerOptionsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem layerOptionsToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar BrushSizeTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar SmoothBrushTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar opacityBrushTrackBar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel ToolsPanel;
        private System.Windows.Forms.Button MoveToolButton;
        private System.Windows.Forms.Button BrushlToolButton;
        private System.Windows.Forms.Button EarserToolButton;
        private System.Windows.Forms.Button SelectionToolButton;
        private System.Windows.Forms.Button BucketToolButton;
        public System.Windows.Forms.TabControl ViewportsTabControl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button chabgeActiveColorButton;
        private System.Windows.Forms.PictureBox mainColorPictureBox;
        private System.Windows.Forms.PictureBox additionalColorPictureBox;
        private System.Windows.Forms.Panel panel4;
    }
}

