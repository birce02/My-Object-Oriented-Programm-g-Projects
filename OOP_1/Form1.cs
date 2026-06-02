using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _152120241075_OOP2__Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2, result;
            result = 0;
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            result = num1 + num2;
            label1.Text = result.ToString();
            bool isPositive = result > 0;
                if (isPositive)
                {
                    label1.BackColor = Color.Blue;
                    label1.ForeColor = Color.White;
            }
                else
                {
                    label1.BackColor = Color.Pink;
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double num1, num2, result;
            result = 0;
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            result = num1 * num2;
            label1.Text = result.ToString();
            bool isPositive = result > 0;
            if (isPositive)
            {
                label1.BackColor = Color.Blue;
                label1.ForeColor = Color.White;
            }
            else
            {
                label1.BackColor = Color.Pink;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double num1, num2, result;
            result = 0;
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            result = num1 - num2;
            label1.Text = result.ToString();
            bool isPositive = result > 0;
            if (isPositive)
            {
                label1.BackColor = Color.Blue;
                label1.ForeColor = Color.White;
            }
            else
            {
                label1.BackColor = Color.Pink;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double num1, num2, result;
            result = 0;
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            if(num2==0)
                {
                MessageBox.Show("Cannot divide by zero!");
                return;
            }
            else
            {
                result = num1 / num2;
                label1.Text = result.ToString();
                bool isPositive = result > 0;
                if (isPositive)
                {
                    label1.BackColor = Color.Blue;
                    label1.ForeColor = Color.White;
                }
                else
                {
                    label1.BackColor = Color.Pink;
                }
            }
               
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Black;
        }
    }
}
