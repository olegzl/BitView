using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BitView
{
    public partial class Main : Form
    {
        private const int MaxBitSize = 16;

        public Main()
        {
            InitializeComponent();

            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item != toolStripButtonOpen)
                    item.Enabled = false;
            }

            bitView.BitsPerRowChanged += (o, e) =>
            {
                if (toolStripTextBoxWidth.Enabled)
                    toolStripTextBoxWidth.Text = bitView.BitsPerRow.ToString();
            };

            bitView.PointedBitChanged += (o, e) =>
            {
                statusStripStatus.Text = bitView.PointedBit != null
                    ? $"Bit {bitView.PointedBit}"
                    : string.Empty;
            };

            bitView.DataChanged += (o, e) =>
                toolStripTextBoxWidth.Text = bitView.BitsPerRow.ToString();

            toolStripButton1Color.Image = GetColorImage(bitView.Bit1Color);
            toolStripButton0Color.Image = GetColorImage(bitView.Bit0Color);
        }

        private static Color? GetBitColor(Color currentColor)
        {
            using var colorDialog = new ColorDialog
            {
                Color = currentColor
            };

            return colorDialog.ShowDialog() == DialogResult.OK
                ? (Color?) colorDialog.Color
                : null;
        }

        private static Image GetColorImage(Color color)
        {
            const int size = 16;

            var borderColor = SystemColors.ActiveBorder;

            var image = new Bitmap(size, size);
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                        image.SetPixel(i, j, borderColor);
                    else
                        image.SetPixel(i, j, color);
                }
            }

            return image;
        }

        private void SetBitsWidth()
        {
            if (!int.TryParse(toolStripTextBoxWidth.Text, out var width))
                return;

            bitView.BitsPerRow = width;
            bitView.FixedWidth = true;
            toolStripButtonFitWidth.Checked = false;
        }

        private void OpenFile(string path)
        {
            bitView.Data = File.OpenRead(path);

            foreach (ToolStripItem item in toolStrip.Items)
                item.Enabled = true;

            Text = @$"BitView - {path}";
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                OpenFile(openFileDialog.FileName);
        }

        private void toolStripButtonDecrease_Click(object sender, EventArgs e)
        {
            if (bitView.BitSize > 1)
            {
                bitView.BitSize--;
                toolStripButtonIncrease.Enabled = true;
            }

            if (bitView.BitSize == 1)
                toolStripButtonDecrease.Enabled = false;
        }

        private void toolStripButtonIncrease_Click(object sender, EventArgs e)
        {
            if (bitView.BitSize < MaxBitSize)
            {
                bitView.BitSize++;
                toolStripButtonDecrease.Enabled = true;
            }

            if (bitView.BitSize == MaxBitSize)
                toolStripButtonIncrease.Enabled = false;
        }

        private void toolStripButtonSetWidth_Click(object sender, EventArgs e)
        {
            SetBitsWidth();
        }

        private void toolStripButtonRev8_Click(object sender, EventArgs e)
        {
            bitView.Rev8 = toolStripButtonRev8.Checked;
        }

        private void toolStripButton1Color_Click(object sender, EventArgs e)
        {
            var color = GetBitColor(bitView.Bit1Color);
            if (color == null)
                return;

            bitView.Bit1Color = color.Value;
            var oldImage = toolStripButton1Color.Image;
            toolStripButton1Color.Image = GetColorImage(color.Value);
            oldImage?.Dispose();
        }

        private void toolStripButton0color_Click(object sender, EventArgs e)
        {
            var color = GetBitColor(bitView.Bit0Color);
            if (color == null)
                return;

            bitView.Bit0Color = color.Value;
            var oldImage = toolStripButton0Color.Image;
            toolStripButton0Color.Image = GetColorImage(color.Value);
            oldImage?.Dispose();
        }

        private void toolStripButtonFitWidth_Click(object sender, EventArgs e)
        {
            toolStripButtonFitWidth.Checked = true;
            bitView.FixedWidth = false;
        }

        private void toolStripTextBoxWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                SetBitsWidth();
        }

        private void toolStripButtonPickRange_Click(object sender, EventArgs e)
        {
            using var pickRangeDialog = new PickRangeDialog(
                bitView.DataStartBit, bitView.DataEndBit, bitView.Data.Length * 8);

            if (pickRangeDialog.ShowDialog() != DialogResult.OK)
                return;

            bitView.DataStartBit = pickRangeDialog.Start;
            bitView.DataEndBit = pickRangeDialog.End;

            if (bitView.DataStartBit == bitView.DataEndBit)
                toolStripButtonShiftLeft.Enabled = false;

            if (bitView.DataStartBit == 0)
                toolStripButtonShiftRight.Enabled = false;
        }

        private void toolStripButtonShiftLeft_Click(object sender, EventArgs e)
        {
            bitView.DataStartBit--;

            if (bitView.DataStartBit == 0)
                toolStripButtonShiftLeft.Enabled = false;
            
            toolStripButtonShiftRight.Enabled = true;
        }

        private void toolStripButtonShiftRight_Click(object sender, EventArgs e)
        {
            bitView.DataStartBit++;

            if (bitView.DataStartBit == bitView.DataEndBit - 1)
                toolStripButtonShiftRight.Enabled = false;

            toolStripButtonShiftLeft.Enabled = true;
        }

        private void toolStripButtonShowGrid_Click(object sender, EventArgs e)
        {
            toolStripButtonShowGrid.Checked = !toolStripButtonShowGrid.Checked;
            bitView.DrawGrid = toolStripButtonShowGrid.Checked;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && File.Exists(files[0]))
                OpenFile(files[0]);
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
