using System;
using System.Windows.Forms;

namespace Prelab02calisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            if (checkBox1 != null) checkBox1.Checked = true;
        }

        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                button1.Text = "Generate and Calculate";
            else
                button1.Text = "Generate";
        }

        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox1.Text = "10";
                textBox1.ReadOnly = true; 
            }
            else
            {
                textBox1.Text = ""; 
                textBox1.ReadOnly = false; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;

            
            if (checkBox2.Checked)
            {
                textBox1.Text = "10";
                n = 10;
            }
            else
            {
                
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a value for N.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                
                if (!int.TryParse(textBox1.Text, out n) || n <= 0)
                {
                    MessageBox.Show("Lütfen pozitif bir tam sayı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
            }

            
            listBox1.Items.Clear();

            
            int[] dizi = new int[2];
            dizi[0] = 1;
            dizi[1] = 1;

            
            if (n > 2)
            {
                Array.Resize(ref dizi, n);

                
                for (int i = 2; i < n; i++)
                {
                    dizi[i] = dizi[i - 1] + dizi[i - 2];
                }
            }
            else if (n < 2)
            {
                
                Array.Resize(ref dizi, n);
            }

            int toplam = 0;

            
            for (int i = 0; i < n; i++)
            {
                listBox1.Items.Add(dizi[i]);
                toplam += dizi[i];
            }

            
            if (checkBox1.Checked)
            {
                double ortalama = (double)toplam / n;
                label1.Text = "AVERAGE: " + ortalama.ToString("0.##");
            }
            else
            {
                label1.Text = "AVERAGE: -";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}