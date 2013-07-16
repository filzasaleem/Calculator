using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = ((Expression.Abstract)this.textBox1.Text).Evaluate().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = ((Expression.Abstract)this.textBox1.Text).Simplify().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Expression.Abstract v = (Expression.Abstract)this.textBox1.Text.ToString();
            this.textBox1.Text = new Expression.Sine(v).Evaluate().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Expression.Abstract z = (Expression.Abstract)this.textBox1.Text.ToString();
            this.textBox1.Text = z.Derive("x").Simplify().ToString();
        }

    }
}
