using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Göz_Hastalıkları_Polikliniği_Yönetim_Sistemi
{
    public partial class GirişBtn : Form
    {
        public GirişBtn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {      //kullancı adı ve sifre kodlaması
            if(KullancıTb.Text == ""|| SifreTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!!!");

            }
            else
            {
                if(KullancıTb.Text=="Admin"&& SifreTb.Text=="Sifre")
                { //hastalar formuna baglama kodu
                    Hastalar obj = new Hastalar();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("geçersiz Bilgiler");
                }
            }
        }

        private void KAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void giriş_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //cıkış botunu kodlaması messagebox kullandım eger cıkıs yapmak istiyorsan bir message (yes,no)cıkacak
        //no secersek "islem iptal edildi"yazilacak yes secersek programdan cıkacak
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Programdan çıkmak istiyor musunuz?", "çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("çıkış işlemi iptal edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KullancıTb.Text == "" || SifreTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!!!");

            }
            else
            {
                if (KullancıTb.Text == "Admin" && SifreTb.Text == "Sifre")
                {
                    Hastalar obj = new Hastalar();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("geçersiz Bilgiler");
                }
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        // UsePasswordChar fonksiyonu kullandım eger true sifreyi gosterılsın degilse gosterilmesin
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                SifreTb.UseSystemPasswordChar = false;
            }
            else
            {
                SifreTb.UseSystemPasswordChar = true;
            }
        }
    }
}
