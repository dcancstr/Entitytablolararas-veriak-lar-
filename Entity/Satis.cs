using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity
{
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        satış_takipEntities db = new satış_takipEntities();
        
        public void listele()
        {
            var urun = (from x in db.tbl_urun
                        select new
                        {
                            x.urunid,
                            x.urunad
                        }).ToList();
            var must = (from y in db.tbl_musteri
                        select new
                        {
                            y.musteriid,
                            y.musteriadsoyad
                        }).ToList();
            dataGridView1.DataSource = (from z in db.tbl_satis
                                        select new
                                        {
                                            z.satisid,
                                            z.satisfiyat,
                                            z.satisadet,
                                            z.satistarih,
                                            z.tbl_urun.urunad,
                                            z.tbl_musteri.musteriadsoyad
                                        }).ToList();
            comboBox1.ValueMember = "urunid";
            comboBox1.DisplayMember = "urunad";
            comboBox1.DataSource = urun;
            comboBox2.ValueMember = "musteriid";
            comboBox2.DisplayMember = "musteriadsoyad";
            comboBox2.DataSource = must;
        }
        private void Satis_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_satis satis = new tbl_satis();
            satis.satisfiyat = int.Parse(textBox2.Text);
            satis.satisadet = int.Parse(textBox5.Text);
            satis.satistarih = Convert.ToDateTime(maskedTextBox1.Text);
            satis.urun = int.Parse(comboBox2.SelectedValue.ToString());
            satis.musteri=int.Parse(comboBox1.SelectedValue.ToString());
            db.tbl_satis.Add(satis);
            db.SaveChanges();
            MessageBox.Show("Satış yaptın primi kaptin:)");
            listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul= db.tbl_satis.Find(id);
            db.tbl_satis.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Satış iptal oldu");
            listele();43t
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_satis.Find(id);
            bul.satisfiyat = decimal.Parse(textBox2.Text);
            bul.satisadet = int.Parse(textBox5.Text);
            bul.satistarih = Convert.ToDateTime(maskedTextBox1.Text);
            bul.urun = int.Parse(comboBox2.SelectedValue.ToString());
            bul.musteri = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Satış güncellendi");
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
