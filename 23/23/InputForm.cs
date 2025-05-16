using System;
using System.Windows.Forms;

namespace QueueVisualization
{
    public partial class InputForm : Form
    {
        public event EventHandler<InputValueEventArgs> DataEntered;

        public InputForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (numericUpDown.Value != null)
            {
                int value = (int)numericUpDown.Value;
                DataEntered?.Invoke(this, new InputValueEventArgs(value));
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class InputValueEventArgs : EventArgs
    {
        public int Value { get; }

        public InputValueEventArgs(int value)
        {
            Value = value;
        }
    }
}