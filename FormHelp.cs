using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DevCalc.NET
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        public string HelpText
        {
            get { return textBox1.Text; }
            set
            {
                textBox1.Text = value;
                textBox1.SelectionLength = 0;
                textBox1.SelectionStart = 0;
            }
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
        }
    }
}