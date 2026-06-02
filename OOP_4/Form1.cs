using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InClass_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCity.Items.Add("Ankara");
            cmbCity.Items.Add("Eskişehir");
        }

        
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDistrict.Items.Clear(); 

            if (cmbCity.SelectedItem != null)
            {
                string secilenIl = cmbCity.SelectedItem.ToString();

                if (secilenIl == "Ankara")
                {
                    cmbDistrict.Items.AddRange(new string[] { "Çankaya", "Keçiören", "Yenimahalle", "Polatlı", "Mamak", "Altındağ", "Pursaklar" });
                }
                else if (secilenIl == "Eskişehir")
                {
                    cmbDistrict.Items.AddRange(new string[] { "Odunpazarı", "Tepebaşı", "Sivrihisar", "İnönü", "Beylikova", "Çifteler" });
                }

               
                if (cmbDistrict.Items.Count > 0)
                    cmbDistrict.SelectedIndex = 0;
            }
        }

        
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            
            string isimSoyisim = txtNameSurname.Text.Trim();
            string telefon = txtPhone.Text.Trim();

            
            if (isimSoyisim.Length < 3)
            {
                MessageBox.Show("Lütfen isim olarak en az 3 karakter giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (telefon.Length < 10)
            {
                MessageBox.Show("Lütfen geçerli bir Telefon Numarası giriniz (En az 10 haneli olmalıdır).", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (lstModels.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Ayakkabı Modelini seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCity.SelectedItem == null || cmbDistrict.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Adresi eksiksiz doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string secilenModel = lstModels.SelectedItem.ToString();

            
            List<string> secilenNumaralarListesi = new List<string>();
            FindCheckedBoxes(this, secilenNumaralarListesi);

            string secilenNumaralar = string.Join(", ", secilenNumaralarListesi);

            
            if (string.IsNullOrEmpty(secilenNumaralar))
            {
                MessageBox.Show("Lütfen en az bir ayakkabı numarası seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string il = cmbCity.SelectedItem.ToString();
            string ilce = cmbDistrict.SelectedItem.ToString();

            
            string tarih = DateTime.Now.ToString("dd.MM.yyyy");

            
            string siparisOzeti = $"{isimSoyisim} | {telefon} | {secilenModel} | Sizes: {secilenNumaralar} | {il}/{ilce} | {tarih}";

            lstOrders.Items.Add(siparisOzeti);
        }
        private void FindCheckedBoxes(Control parent, List<string> list)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is CheckBox chk && chk.Checked)
                {
                    list.Add(chk.Text);
                }
                else if (c.HasChildren)
                {
                    FindCheckedBoxes(c, list); 
                }
            }
        }
    }
}