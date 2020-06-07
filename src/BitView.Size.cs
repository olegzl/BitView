using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BitView
{
    internal partial class BitView
    {
        private int _bitsPerRow = 16;
        private int _bitRows = 16;

        private Rectangle _rectContent;
        private Rectangle _rectBitsData;

        private void UpdateVisibleData()
        {
            Debug.WriteLine("UpdateVisibleData()");

            if (_data == null || _dataLength == 0)
                return;

            var startBit = (_verticalScrollCurrentValue * _bitsPerRow) + _dataStartBit;
            var endBit = Math.Min(_dataEndBit, startBit + (_bitsPerRow * _bitRows));

            var notify = startBit != _startBit
                         || endBit != _endBit;

            Debug.Assert(_startBit <= _endBit);

            _startBit = startBit;
            _endBit = endBit;

            Debug.WriteLine($"Visible data: {_startBit}-{_endBit} ({_endBit - _startBit})");

            if (notify)
            {
                VisibleDataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void UpdateSizes()
        {
            Debug.WriteLine("UpdateRectFrame()");

            // calculate border size
            var borderWidth = _borderStyle == BorderStyle.None
                ? 0
                : SystemInformation.Border3DSize.Width;

            var borderHeight = _borderStyle == BorderStyle.None
                ? 0
                : SystemInformation.Border3DSize.Height;

            _rectContent = ClientRectangle;
            _rectContent.X += borderWidth;
            _rectContent.Y += borderHeight;
            _rectContent.Width -= 2 * borderHeight;
            _rectContent.Height -= 2 * borderWidth;

            _rectContent.Width -= _verticalScroll.Width;
            _verticalScroll.Left = _rectContent.X + _rectContent.Width;
            _verticalScroll.Top = _rectContent.Y;
            _verticalScroll.Height = _rectContent.Height;

            _rectBitsData = _rectContent;

            _gridSize = Math.Max(1, BitSize / 4);

            var totalBitWidth = _bitSize + (_drawGrid ? _gridSize : 0);

            var fixedWidth = _fixedWidth;
            if (fixedWidth && _bitsPerRow * totalBitWidth > _rectContent.Width)
                fixedWidth = false;

            if (!fixedWidth)
            {
                var bitsPerRow = Math.Max(0,
                    (int) Math.Floor(Math.Floor((double) _rectContent.Width / totalBitWidth)));

                var changed = _bitsPerRow != bitsPerRow;

                _bitsPerRow = bitsPerRow;

                if (changed)
                    BitsPerRowChanged?.Invoke(this, EventArgs.Empty);
            }

            _rectBitsData.Width = _bitsPerRow * totalBitWidth;

            _bitRows = Math.Max(0, (int) Math.Ceiling((double) _rectBitsData.Height / totalBitWidth));
        }

        private void UpdateScrollSize()
        {
            Debug.WriteLine("UpdateScrollSize()");

            if (_data != null && _dataLength > 0 && _bitRows != 0)
            {
                _verticalScrollMaxValue = Math.Max(
                    (int) Math.Ceiling(((double) (_dataEndBit - _dataStartBit) / _bitsPerRow) - _bitRows + 1),
                    0);

                _verticalScrollCurrentValue = Math.Min(
                    _bitsPerRow != 0 ? _startBit / _bitsPerRow : 0,
                    _verticalScrollMaxValue);
            }
            else
            {
                _verticalScrollMaxValue = 0;
                _verticalScrollCurrentValue = 0;
            }

            if (_verticalScrollMaxValue > 0)
            {
                if (_verticalScrollCurrentValue > _verticalScrollMaxValue)
                {
                    _verticalScrollCurrentValue = _verticalScrollMaxValue;
                }

                _verticalScroll.Minimum = 0;
                _verticalScroll.Maximum = (int) _verticalScrollMaxValue;
                _verticalScroll.Value = (int) _verticalScrollCurrentValue;
                _verticalScroll.Enabled = true;
            }
            else
            {
                _verticalScroll.Enabled = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            UpdateSizes();
            UpdateScrollSize();

            base.OnResize(e);
        }

        private int TotalBitSize => _bitSize + (_drawGrid ? _gridSize : 0);
    }
}
