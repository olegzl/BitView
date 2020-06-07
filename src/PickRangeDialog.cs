using System;
using System.Windows.Forms;

namespace BitView
{
    public partial class PickRangeDialog : Form
    {
        public PickRangeDialog(long start, long end, long maxValue)
        {
            InitializeComponent();

            Start = start;
            End = end;
            MaxValue = maxValue;

            textBoxStart.Text = start.ToString();
            textBoxEnd.Text = end.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (!long.TryParse(textBoxStart.Text, out var start))
            {
                errorProvider.SetError(textBoxStart, "Invalid value");
                return;
            }

            if (!long.TryParse(textBoxEnd.Text, out var end))
            {
                errorProvider.SetError(textBoxEnd, "Invalid value");
                return;
            }

            if (start < 0)
            {
                errorProvider.SetError(textBoxStart, "Must be 0 or greater");
                return;
            }

            if (start >= end)
            {
                errorProvider.SetError(textBoxEnd, "End bit must be greater than start bit");
                return;
            }

            if (end > MaxValue)
            {
                errorProvider.SetError(textBoxEnd, $"Must be {MaxValue} or less");
                return;
            }

            Start = start;
            End = end;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        public long Start { get; private set; }
        public long End { get; private set; }
        private long MaxValue { get; set; }
    }
}
