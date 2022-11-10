using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity
{
    public partial class ürün : Form
    {
        public ürün()
        {
            InitializeComponent();
        }
        satış_takipEntities db = new satış_takipEntities();

        public void listele()
        {
             var goster = (from x in db.tbl_urun
                                        select new
                                        {
                                            x.urunid,
                                            x.urunad,
                                            x.marka,
                                            x.urunfiyat,
                                            x.urunstok,
                                            x.tbl_kategori.kategoriad,
                                        }).ToList();
            comboBox1.ValueMember = "kategoriid";
            comboBox1.DisplayMember = "kategoriad";
            comboBox1.DataSource = goster;
            dataGridView1.DataSource = goster;

        }

        private void ürün_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_urun urun = new tbl_urun();
            urun.urunad = textBox2.Text;
            urun.marka = textBox4.Text;
            urun.urunfiyat = int.Parse(textBox5.Text);
            urun.urunstok = int.Parse(textBox6.Text);
            urun.kategori = int.Parse(comboBox1.Text);
        }
    }
}
