using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BitView
{
    internal partial class BitView
    {
        private long _startBit;
        private long _endBit;

        private int _bitSize = 2;
        private bool _rev8;

        private byte[] _windowBuffer;
        private long _windowBufferOffset;

        private Color _bit1Color = Color.Blue;
        private Color _bit0Color = Color.White;

        private bool _fixedWidth;

        private bool _drawGrid;

        private int _gridSize;

        private Color _gridColorLight = Color.Gray;
        private Color _gridColorBold = Color.Black;

        private BorderStyle _borderStyle = BorderStyle.None;

        protected override void OnPaint(PaintEventArgs e)
        {
            Debug.WriteLine($"OnPaint({e.ClipRectangle})");

            if (_data != null)
            {
                UpdateVisibleData();
                DrawBits(e.Graphics, e.ClipRectangle);
            }

            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Debug.WriteLine($"OnPaintBackground({e.ClipRectangle})");

            using (Brush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, e.ClipRectangle);

            switch (_borderStyle)
            {
                case BorderStyle.Fixed3D:
                    ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.Sunken);
                    break;
                case BorderStyle.FixedSingle:
                    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
                    break;
            }
        }

        private void DrawBits(Graphics g, Rectangle drawArea)
        {
            var windowLength = (int) (_endBit - _startBit) / 8;
            if ((_startBit - _endBit) % 8 != 0)
            {
                ++windowLength;
            }

            if (_windowBuffer == null
                || _windowBuffer.Length != windowLength
                || _windowBufferOffset != _startBit)
            {
                _windowBuffer = new byte[windowLength];
                _windowBufferOffset = _startBit;
                _data.Position = _startBit / 8;
                _ = _data.Read(_windowBuffer, 0, windowLength);
            }

            var skip = (int) _startBit % 8;
            for (int @byte = 0, bit = skip; @byte < windowLength;)
            {
                var bitPosition = GetBitPosition((@byte * 8) + bit - skip);
                var bitPoint = GetBitPointF(bitPosition);

                // calculate the "worse case" (max) byte drawing area
                var bitArea = new Rectangle(
                    (int) Math.Floor(bitPoint.X),
                    (int) Math.Floor(bitPoint.Y), _bitSize, _bitSize);

                // check if the current byte should be drawn
                if (drawArea.IntersectsWith(bitArea))
                {
                    int b = _windowBuffer[@byte];
                    b >>= _rev8
                        ? bit
                        : 7 - bit;
                    b &= 1;

                    var bitColor = b == 0 ? _bit0Color : _bit1Color;

                    using Brush brush = new SolidBrush(bitColor);
                    g.FillRectangle(brush, bitPoint.X, bitPoint.Y, _bitSize, _bitSize);
                }

                if (++bit <= 7)
                    continue;

                bit = 0;
                ++@byte;
            }

            if (!_drawGrid)
                return;
            using var lightPen = new Pen(_gridColorLight, _gridSize);
            using var boldPen = new Pen(_gridColorBold, _gridSize);

            for (var i = 1; i <= _bitsPerRow; ++i)
            {
                var bitPoint = GetBitPointF(new Point(i, 0));
                bitPoint.X -= (float) _gridSize / 2;
                var brush = i % 8 == 0 ? boldPen : lightPen;
                g.DrawLine(brush, bitPoint.X, bitPoint.Y, bitPoint.X, bitPoint.Y + _rectBitsData.Height);
            }

            for (var i = 1; i <= _bitRows; ++i)
            {
                var bitPoint = GetBitPointF(new Point(0, i));
                bitPoint.Y -= (float) _gridSize / 2;
                var brush = i % 8 == 0 ? boldPen : lightPen;
                g.DrawLine(brush, bitPoint.X, bitPoint.Y, bitPoint.X + _rectBitsData.Width, bitPoint.Y);
            }
        }

        [DefaultValue(typeof(BorderStyle), "None"), Category("Bits")]
        public new BorderStyle BorderStyle
        {
            get => _borderStyle;
            set
            {
                if (_borderStyle == value)
                    return;

                _borderStyle = value;

                UpdateSizes();
                Invalidate();
            }
        }

        [DefaultValue(typeof(int), "4"), Category("Bits")]
        public int BitSize
        {
            get => _bitSize;
            set
            {
                if (value <= 0)
                    throw new ArgumentException();

                _bitSize = value;

                UpdateSizes();
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Blue"), Category("Bits")]
        public Color Bit1Color
        {
            get => _bit1Color;
            set
            {
                _bit1Color = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White"), Category("Bits")]
        public Color Bit0Color
        {
            get => _bit0Color;
            set
            {
                _bit0Color = value;
                Invalidate();
            }
        }

        [DefaultValue(false), Category("Bits")]
        public bool FixedWidth
        {
            get => _fixedWidth;
            set
            {
                if (_fixedWidth == value)
                    return;

                _fixedWidth = value;

                UpdateSizes();
                Invalidate();
            }
        }

        [DefaultValue(16), Category("Bits")]
        public int BitsPerRow
        {
            get => _bitsPerRow;
            set
            {
                if (_bitsPerRow == value)
                    return;

                _bitsPerRow = value;

                UpdateSizes();
                Invalidate();

                BitsPerRowChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [DefaultValue(false), Category("Bits")]
        public bool Rev8
        {
            get => _rev8;
            set
            {
                _rev8 = value;
                Invalidate();
            }
        }

        [DefaultValue(false), Category("Bits")]
        public bool DrawGrid
        {
            get => _drawGrid;
            set
            {
                if (_drawGrid == value)
                    return;

                _drawGrid = value;

                UpdateSizes();
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Gray"), Category("Bits")]
        public Color GridColorLight
        {
            get => _gridColorLight;
            set
            {
                _gridColorLight = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Black"), Category("Bits")]
        public Color GridColorBold
        {
            get => _gridColorBold;
            set
            {
                _gridColorBold = value;
                Invalidate();
            }
        }
    }
}
