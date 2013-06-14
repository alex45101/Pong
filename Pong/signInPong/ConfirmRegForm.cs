using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace signInPong
{
    public partial class ConfirmRegForm : Form
    {
        private Guid real;
        public ConfirmRegForm(Guid trueCode)
        {
            real = trueCode;
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Guid g = new Guid();
            try
            {
                g = new Guid(guidTxtBox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid ID!");
                guidTxtBox.Text = "";
                return;
            }
            if (g != real)
            {
                MessageBox.Show("Invalid ID!");
                guidTxtBox.Text = "";
                return;
            }
            else
            {
                Close();
            }
        }

        private void ConfirmRegForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (guidTxtBox.Text.ToLower() != real.ToString().ToLower())
            {
                e.Cancel = true;
            }
        }

    }
}
