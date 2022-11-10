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
    public partial class Müşteri : Form
    {
        public Müşteri()
        {
            InitializeComponent();
        }
        satış_takipEntities db = new satış_takipEntities();
        private void Müşteri_Load(object sender, EventArgs e)
        {
            listele();
        }
        public void listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_musteri
                                        select new
                                        {
                                            x.musteriid,
                                            x.musteriadsoyad,
                                            x.telno,
                                            x.tc,
                                            x.adres,
                                            x.meslek,
                                            x.sehir
                                        }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_musteri musteri=new tbl_musteri();
            musteri.musteriadsoyad = textBox2.Text;
            musteri.telno = maskedTextBox1.Text;
            musteri.tc = maskedTextBox2.Text;
            musteri.adres = richTextBox1.Text;
            musteri.meslek = textBox3.Text;
            musteri.sehir = textBox4.Text;
            db.tbl_musteri.Add(musteri);
            db.SaveChanges();
            MessageBox.Show("Müşteri eklenmiştir");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_musteri.Find(id);
            db.tbl_musteri.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Müşteri Silinmiştir");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_musteri.Find(id); 
            bul.musteriadsoyad = textBox2.Text;
            bul.telno = maskedTextBox1.Text;
            bul.tc = maskedTextBox2.Text;
            bul.adres = richTextBox1.Text;
            bul.meslek = textBox3.Text;
            bul.sehir = textBox4.Text;
            db.SaveChanges();
            MessageBox.Show("Müşteri güncellenmiştir");
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
