using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BitView
{
	internal partial class BitView
	{
	    private readonly VScrollBar _verticalScroll;
        private long _verticalScrollMaxValue;
        private long _verticalScrollCurrentValue;

        private void OnVerticalScroll(object sender, ScrollEventArgs e)
        {
            switch (e.Type) {
                case ScrollEventType.Last:
                    break;
                case ScrollEventType.EndScroll:
                    break;
                case ScrollEventType.SmallIncrement:
                    ScrollLines(1);
                    break;
                case ScrollEventType.SmallDecrement:
                    ScrollLines(-1);
                    break;
                case ScrollEventType.LargeIncrement:
                    ScrollLines(_bitRows);
                    break;
                case ScrollEventType.LargeDecrement:
                    ScrollLines(-_bitRows);
                    break;
                case ScrollEventType.ThumbPosition:
                case ScrollEventType.ThumbTrack:
                    ScrollToLine(e.NewValue);
                    break;
                case ScrollEventType.First:
                    break;
                default:
                    break;
            }

            e.NewValue = (int)_verticalScrollCurrentValue;
        }

        private void ScrollLines(long lines)
        {
            long line;
            if (lines > 0) {
                line = Math.Min(_verticalScrollMaxValue, _verticalScrollCurrentValue + lines);
            }
            else if (lines < 0) {
                line = Math.Max(0, _verticalScrollCurrentValue + lines);
            }
            else {
                return;
            }

            ScrollToLine(line);
        }

        private void ScrollToLine(long value)
        {
            Debug.WriteLine($"ScrollToLine({value})");

            value = Math.Max(0, value);
            value = Math.Min(value, _verticalScrollMaxValue);

            _verticalScrollCurrentValue = value;

            UpdateVisibleData();
            UpdateScrollSize();
            Invalidate();
        }
	}
}
