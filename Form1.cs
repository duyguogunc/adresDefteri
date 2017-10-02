using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdresDefteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yeniAdresEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new YeniAdres().Show();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            foreach (Adres a in Ortak.tumAdresler)
            {
                listBox1.Items.Add(a.AdSoyad);
                listBox2.Items.Add(a.Eposta);
                listBox3.Items.Add(a.Telefon);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ad Soyad seçilirse karşısındaki bilgiler de seçilsin
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            listBox3.SelectedIndex = listBox1.SelectedIndex;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("adres.txt")) //dosya varsa
                File.Delete("adres.txt"); //dosyayı sil

            foreach (Adres a in Ortak.tumAdresler) //tüm adresleri tek tek dolaş
            {
                //Append : sondan ekleme
                //adresin tüm bilgilerini tek bir stringde birleştir
                string satir = a.AdSoyad + "," + a.Eposta + "," + a.Telefon + Environment.NewLine;
                File.AppendAllText("adres.txt", satir);
            }
        }

        private void kayıttanOkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Dosyayı satır satır oku
            // 2. gelen satırları (string) -> Adres
            // 3. adresleri ortak listeye aktar

            //string[] satirlar = new string[]{ "Emir Civaş,emir@wissen.com,(216)-123-45-67", "Caner Mollaoğlu,caner@wissen.com,(507)-789-45-65"}
            string[] satirlar = File.ReadAllLines("adres.txt");

            Ortak.tumAdresler.Clear(); //ortak listeyi temizle
            foreach (string satir in satirlar)
            {
                //comma seperated : *.csv

                //new string[] { "Emir Civaş", "emir@wissen.com","(216)-123-45-67"}
                string[] bolumlenmis = satir.Split(',');

                Adres a = new Adres(); //artık gerçekten bir adres var.
                a.AdSoyad = bolumlenmis[0];
                a.Eposta = bolumlenmis[1];
                a.Telefon = bolumlenmis[2];
                
                Ortak.tumAdresler.Add(a);
            }
        }
    }
}
