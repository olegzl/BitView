using System;
using System.Windows.Forms;

namespace BitView
{
    internal partial class BitView : UserControl
    {
        public event EventHandler DataChanged;
        public event EventHandler VisibleDataChanged;
        public event EventHandler BitsPerRowChanged;
        public event EventHandler PointedBitChanged;

        public BitView()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            _verticalScroll = new VScrollBar
            {
                LargeChange = 1
            };

            _verticalScroll.Scroll += OnVerticalScroll;

            Controls.Add(_verticalScroll);
        }
    }
}
