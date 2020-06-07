using System.Windows.Forms;

namespace BitView
{
    partial class Main
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShiftLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPickRange = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShiftRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1Color = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton0Color = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRev8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecrease = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonIncrease = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxWidth = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSetWidth = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFitWidth = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bitView = new BitView();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripSeparator2,
            this.toolStripButtonShiftLeft,
            this.toolStripButtonPickRange,
            this.toolStripButtonShiftRight,
            this.toolStripSeparator1,
            this.toolStripButton1Color,
            this.toolStripButton0Color,
            this.toolStripButtonShowGrid,
            this.toolStripButtonRev8,
            this.toolStripButtonDecrease,
            this.toolStripButtonIncrease,
            this.toolStripTextBoxWidth,
            this.toolStripButtonSetWidth,
            this.toolStripButtonFitWidth});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(442, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::BitView.Properties.Resources.Open;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonShiftLeft
            // 
            this.toolStripButtonShiftLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShiftLeft.Image = global::BitView.Properties.Resources.ShiftLeft;
            this.toolStripButtonShiftLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShiftLeft.Name = "toolStripButtonShiftLeft";
            this.toolStripButtonShiftLeft.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShiftLeft.Text = "Shift left";
            this.toolStripButtonShiftLeft.Click += new System.EventHandler(this.toolStripButtonShiftLeft_Click);
            // 
            // toolStripButtonPickRange
            // 
            this.toolStripButtonPickRange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPickRange.Image = global::BitView.Properties.Resources.PickRange;
            this.toolStripButtonPickRange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPickRange.Name = "toolStripButtonPickRange";
            this.toolStripButtonPickRange.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPickRange.Text = "Pick range";
            this.toolStripButtonPickRange.Click += new System.EventHandler(this.toolStripButtonPickRange_Click);
            // 
            // toolStripButtonShiftRight
            // 
            this.toolStripButtonShiftRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShiftRight.Image = global::BitView.Properties.Resources.ShiftRight;
            this.toolStripButtonShiftRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShiftRight.Name = "toolStripButtonShiftRight";
            this.toolStripButtonShiftRight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShiftRight.Text = "Shift right";
            this.toolStripButtonShiftRight.Click += new System.EventHandler(this.toolStripButtonShiftRight_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1Color
            // 
            this.toolStripButton1Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1Color.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1Color.Image")));
            this.toolStripButton1Color.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1Color.Name = "toolStripButton1Color";
            this.toolStripButton1Color.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1Color.Text = "Bit 1 color";
            this.toolStripButton1Color.Click += new System.EventHandler(this.toolStripButton1Color_Click);
            // 
            // toolStripButton0Color
            // 
            this.toolStripButton0Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton0Color.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton0Color.Image")));
            this.toolStripButton0Color.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton0Color.Name = "toolStripButton0Color";
            this.toolStripButton0Color.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton0Color.Text = "Bit 0 color";
            this.toolStripButton0Color.Click += new System.EventHandler(this.toolStripButton0color_Click);
            // 
            // toolStripButtonShowGrid
            // 
            this.toolStripButtonShowGrid.Checked = true;
            this.toolStripButtonShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowGrid.Image = global::BitView.Properties.Resources.ShowGrid;
            this.toolStripButtonShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowGrid.Name = "toolStripButtonShowGrid";
            this.toolStripButtonShowGrid.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowGrid.Text = "Show grid";
            this.toolStripButtonShowGrid.Click += new System.EventHandler(this.toolStripButtonShowGrid_Click);
            // 
            // toolStripButtonRev8
            // 
            this.toolStripButtonRev8.CheckOnClick = true;
            this.toolStripButtonRev8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRev8.Image = global::BitView.Properties.Resources.Rev8;
            this.toolStripButtonRev8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRev8.Name = "toolStripButtonRev8";
            this.toolStripButtonRev8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRev8.Text = "Rev8";
            this.toolStripButtonRev8.Click += new System.EventHandler(this.toolStripButtonRev8_Click);
            // 
            // toolStripButtonDecrease
            // 
            this.toolStripButtonDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecrease.Image = global::BitView.Properties.Resources.Decrease;
            this.toolStripButtonDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecrease.Name = "toolStripButtonDecrease";
            this.toolStripButtonDecrease.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDecrease.Text = "Decrease bit size";
            this.toolStripButtonDecrease.Click += new System.EventHandler(this.toolStripButtonDecrease_Click);
            // 
            // toolStripButtonIncrease
            // 
            this.toolStripButtonIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncrease.Image = global::BitView.Properties.Resources.Increase;
            this.toolStripButtonIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncrease.Name = "toolStripButtonIncrease";
            this.toolStripButtonIncrease.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonIncrease.Text = "Increase bit size";
            this.toolStripButtonIncrease.Click += new System.EventHandler(this.toolStripButtonIncrease_Click);
            // 
            // toolStripTextBoxWidth
            // 
            this.toolStripTextBoxWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxWidth.Name = "toolStripTextBoxWidth";
            this.toolStripTextBoxWidth.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxWidth_KeyPress);
            // 
            // toolStripButtonSetWidth
            // 
            this.toolStripButtonSetWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSetWidth.Image = global::BitView.Properties.Resources.Go;
            this.toolStripButtonSetWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetWidth.Name = "toolStripButtonSetWidth";
            this.toolStripButtonSetWidth.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSetWidth.Text = "Set bits per row";
            this.toolStripButtonSetWidth.Click += new System.EventHandler(this.toolStripButtonSetWidth_Click);
            // 
            // toolStripButtonFitWidth
            // 
            this.toolStripButtonFitWidth.Checked = true;
            this.toolStripButtonFitWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFitWidth.Image = global::BitView.Properties.Resources.FitSize;
            this.toolStripButtonFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFitWidth.Name = "toolStripButtonFitWidth";
            this.toolStripButtonFitWidth.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFitWidth.Text = "Set bits per row to auto scale";
            this.toolStripButtonFitWidth.Click += new System.EventHandler(this.toolStripButtonFitWidth_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 251);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(442, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // statusStripStatus
            // 
            this.statusStripStatus.AutoSize = false;
            this.statusStripStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.statusStripStatus.Name = "statusStripStatus";
            this.statusStripStatus.Size = new System.Drawing.Size(200, 17);
            this.statusStripStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bitView
            // 
            this.bitView.BackColor = System.Drawing.SystemColors.Control;
            this.bitView.BitSize = 10;
            this.bitView.BitsPerRow = 35;
            this.bitView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bitView.Data = null;
            this.bitView.DataEndBit = ((long)(0));
            this.bitView.DataStartBit = ((long)(0));
            this.bitView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bitView.DrawGrid = true;
            this.bitView.Location = new System.Drawing.Point(0, 25);
            this.bitView.Name = "bitView";
            this.bitView.Size = new System.Drawing.Size(442, 226);
            this.bitView.TabIndex = 1;
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 273);
            this.Controls.Add(this.bitView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "BitView";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private BitView bitView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncrease;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecrease;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxWidth;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetWidth;
        private System.Windows.Forms.ToolStripButton toolStripButtonRev8;
        private System.Windows.Forms.ToolStripButton toolStripButton1Color;
        private System.Windows.Forms.ToolStripButton toolStripButton0Color;
        private System.Windows.Forms.ToolStripButton toolStripButtonFitWidth;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusStripStatus;
        private ToolStripButton toolStripButtonPickRange;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButtonShiftLeft;
        private ToolStripButton toolStripButtonShiftRight;
        private ToolStripButton toolStripButtonShowGrid;
    }
}

