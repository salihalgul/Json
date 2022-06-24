using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace JasonOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Kitap> liste=new List<Kitap>();
        JavaScriptSerializer tercuman=new JavaScriptSerializer();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kitap yeni=new Kitap();
            yeni.baslik = textBox1.Text;
            yeni.fiyat = numericUpDown1.Value;
            liste.Add(yeni);
            JsonDosyasinaYaz(liste);
        }

        private void JsonDosyasinaYaz(List<Kitap> liste)
        {
            string jason = tercuman.Serialize(liste);//bu listeyi jasona cevir
            File.WriteAllText("../../kitaplar.jason",jason);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string icerik = File.ReadAllText("../../kitaplar.jason");
            var liste = tercuman.Deserialize<List<Kitap>>(icerik);

            listBox1.DisplayMember = "baslik";

            foreach (Kitap kitap in liste)
            {
                listBox1.Items.Add((kitap));
            }
        }
    }
}
