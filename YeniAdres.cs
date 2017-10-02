using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdresDefteri
{
    public partial class YeniAdres : Form
    {
        public YeniAdres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adres yeni = new Adres();
            yeni.AdSoyad = textBox1.Text;
            yeni.Telefon = maskedTextBox1.Text;
            yeni.Eposta = textBox3.Text;

            Ortak.tumAdresler.Add(yeni);
            MessageBox.Show("Eklendi");

            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            maskedTextBox1.Text = string.Empty;

            //this.Close(); formu kapatır
        }
    }
}
