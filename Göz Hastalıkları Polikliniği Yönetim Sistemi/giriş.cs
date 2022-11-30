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
        {
            if(KullancıTb.Text == ""|| SifreTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!!!");

            }
            else
            {
                if(KullancıTb.Text=="Admin"&& SifreTb.Text=="Sifre")
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

        private void KAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void giriş_Load(object sender, EventArgs e)
        {

        }
    }
}
