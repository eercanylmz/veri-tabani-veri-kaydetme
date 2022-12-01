using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace veri_tabanı_veri_kaydetme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bağlan = new SqlConnection("Data Source=ERCANMONSTER\\ERCANSERVER;Initial catalog=KAYITLAR;Integrated Security=True");
        private void verilerigoster()
        {
            bağlan.Open();
            SqlCommand komutt = new SqlCommand("SELECT * FROM gelenler", bağlan);
            SqlDataReader oku = komutt.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text=oku["AdSoyad"].ToString();
                ekle.SubItems.Add(oku["Firma"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                listView1.Items.Add(ekle);
            }
            bağlan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bağlan.Open();
            SqlCommand komut = new SqlCommand("Insert into GELENLER (AdSoyad,Firma,Telefon) Values ('" + textBox1.Text.ToString() + " ' ,'" + textBox2.Text.ToString()+"' ,'" + textBox3.Text.ToString() + "' )", bağlan); ;
            komut.ExecuteNonQuery();
            bağlan.Close();
            verilerigoster();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
