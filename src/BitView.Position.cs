using System;
using System.Drawing;

namespace BitView
{
    internal partial class BitView
    {
        private Point GetBitPosition(int offset)
        {
            var y = (int) Math.Floor(((double) offset) / _bitsPerRow);
            var x = offset + _bitsPerRow - (_bitsPerRow * (y + 1));
            return new Point(x, y);
        }

        private PointF GetBitPointF(Point p)
        {
            float x = _rectContent.X + (TotalBitSize * p.X);
            float y = _rectContent.Y + (TotalBitSize * p.Y);
            return new PointF(x, y);
        }

        private long? GetBitOffsetInScreen(Point p)
        {
            if (_data == null || _dataLength == 0)
                return null;

            var x = (p.X - _rectContent.X) / TotalBitSize;
            if (x < 0 || x >= _bitsPerRow)
                return null;

            var y = (p.Y - _rectContent.Y) / TotalBitSize;
            if (y < 0 || y >= _bitRows)
                return null;

            long offset = (_bitsPerRow * y) + x;
            return offset < _endBit - _startBit ? offset : (long?) null;
        }
    }
}
