using System;
using System.Windows.Forms;

namespace BitView
{
    internal partial class BitView
    {
        private long? _lastBitOffset;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var position = PointToClient(MousePosition);
            var bitOffset = GetBitOffsetInScreen(position);

            if (bitOffset != _lastBitOffset)
            {
                _lastBitOffset = bitOffset;

                PointedBitChanged?.Invoke(this, EventArgs.Empty);
            }

            base.OnMouseMove(e);
        }

        public long? PointedBit => _lastBitOffset + _startBit - _dataStartBit;
    }
}
