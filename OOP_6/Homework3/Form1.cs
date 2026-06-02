using System;
using System.Drawing;
using System.Windows.Forms;

namespace Homework3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            textBox1.PasswordChar = '*';

            // Başlangıçta cesar gizlenir
            textBox2.Visible = false;
            label4.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        // REF kULLANIMI 
        public void Cipher(ref char originalChar, ref int shift)
        {
            if (char.IsLetter(originalChar))
            {
                char offset = char.IsUpper(originalChar) ? 'A' : 'a';
                
                originalChar = (char)((((originalChar + shift - offset) % 26 + 26) % 26) + offset);
            }
            else if (char.IsDigit(originalChar))
            {
                
                int x = int.Parse(originalChar.ToString());
                int result = (2 * x * x * x) - (7 * x) + 6;
                
                int finalDigit = Math.Abs(result) % 10;
                originalChar = finalDigit.ToString()[0];
            }
        }

        // out KULLANIMI
        public void Encipher(string password, int shift, out bool success, out string encryptedMessage)
        {
            char[] buffer = password.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char tempChar = buffer[i];
                int tempShift = shift;

                Cipher(ref tempChar, ref tempShift);
                buffer[i] = tempChar;
            }

            encryptedMessage = new string(buffer);
            success = true;
        }

        // Caesar seçildiğinde kutumuzu görünür yapar veya gizler
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = radioButton2.Checked;
            label4.Visible = radioButton2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;

            string inputPass = textBox1.Text;

            if (string.IsNullOrWhiteSpace(inputPass))
            {
                MessageBox.Show("Lütfen şifre alanını boş bırakmayın.");
                return;
            }

            int shiftAmount = 1;

            if (radioButton1.Checked)
            {
                // ROT2 için gerekli kaydırmaları yapar
                shiftAmount = 2;
            }
            else if (radioButton2.Checked)
            {
                
                if (!int.TryParse(textBox2.Text, out shiftAmount))
                {
                    shiftAmount = 1;
                }
            }

            
            Encipher(inputPass, shiftAmount, out bool isOk, out string cipheredResult);

            if (isOk)
            {
                
                label2.Text = "SUCCESS";
                label2.BackColor = Color.Green;
                label2.ForeColor = Color.White;
                label2.Visible = true;

               
                label3.Text = "CIPHER: " + cipheredResult;
                label3.Visible = true;
            }
        }

        
        private void button1_Click_1(object sender, EventArgs e) => button1_Click(sender, e);
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}