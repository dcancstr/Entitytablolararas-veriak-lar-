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
    public partial class kategori : Form
    {
        public kategori()
        {
            InitializeComponent();
        }
        satış_takipEntities db=new satış_takipEntities();

        public void listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_kategori
                                        select new
                                        {
                                            x.kategoriid,
                                            x.kategoriad
                                        }).ToList();
        }
        private void kategori_Load(object sender, EventArgs e)
        {
          listele();    


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_kategori ekle = new tbl_kategori();
            ekle.kategoriad = textBox2.Text;
            db.tbl_kategori.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Kategori eklenmiştir");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_kategori.Find(id);
            db.tbl_kategori.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Kategori silinmiştir.");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_kategori.Find(id);
            bul.kategoriad=textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellenmiştir");
            listele();
        }
    }
}
