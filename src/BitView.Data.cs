using System;
using System.IO;

namespace BitView
{
    internal partial class BitView
    {
        private Stream _data;
        private long _dataLength;
        private long _dataStartBit;
        private long _dataEndBit;

        public Stream Data
        {
            get => _data;
            set
            {
                _data = value;
                _dataLength = value?.Length ?? 0;
                _verticalScrollCurrentValue = 0;
                _windowBuffer = null;
                _dataStartBit = 0;
                _dataEndBit = _dataLength * 8;

                UpdateSizes();
                UpdateVisibleData();
                UpdateScrollSize();
                Invalidate();

                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public long DataStartBit
        {
            get => _dataStartBit;
            set
            {
                _dataStartBit = value;

                UpdateVisibleData();
                UpdateScrollSize();
                Invalidate();
            }
        }

        public long DataEndBit
        {
            get => _dataEndBit;
            set
            {
                _dataEndBit = value;

                UpdateVisibleData();
                UpdateScrollSize();
                Invalidate();
            }
        }
    }
}
