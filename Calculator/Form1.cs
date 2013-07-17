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

        private void Evaluate_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = ((Expression.Abstract)this.textBox1.Text).Evaluate().ToString();
        }

        private void Simplify_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = ((Expression.Abstract)this.textBox1.Text).Simplify().ToString();
        }

        private void Sine_Click(object sender, EventArgs e)
        {
            Expression.Abstract v = (Expression.Abstract)this.textBox1.Text.ToString();
            this.textBox1.Text = new Expression.Sine(v).Evaluate().ToString();
        }

        private void Derive_Click(object sender, EventArgs e)
        {
            Expression.Abstract z = (Expression.Abstract)this.textBox1.Text.ToString();
            this.textBox1.Text = z.Derive("x").Simplify().ToString();
        }

        private void Cosine_Click(object sender, EventArgs e)
        {
            Expression.Abstract v = (Expression.Abstract)this.textBox1.Text.ToString();
            this.textBox1.Text = new Expression.Cosine(v).Evaluate().ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
