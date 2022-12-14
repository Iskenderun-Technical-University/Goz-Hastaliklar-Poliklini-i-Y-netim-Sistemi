using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Göz_Hastalıkları_Polikliniği_Yönetim_Sistemi
{
    //randevulistesi veri tabanına baglama kodu
    public partial class Form1 : Form
    {
      
        fonkisyon Con;
        public Form1()
        {
            InitializeComponent();
            Con = new fonkisyon();
            ShowRandevu();
        }
        private void ShowRandevu()
        {
            try
            {
                string Query = "Select * from RandevuTbl";
                RandevuListesi.DataSource = Con.GetData(Query);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //randevu formuna gecmek icin kodu
        private void label8_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
        //tedavi formuna gecmek icin kodu
        private void label10_Click(object sender, EventArgs e)
        {
            Tedavi obj = new Tedavi();
            obj.ShowDialog();
            this.Hide();
        }
        //hastalar formuna gecmek icin kodu
        private void label11_Click(object sender, EventArgs e)
        {
            Hastalar obj = new Hastalar();
            obj.Show();
            this.Hide();
        }
        //recete formuna gecmek icin kodu
        private void label9_Click(object sender, EventArgs e)
        {
            Reçete obj = new Reçete();
            obj.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Textbox'lardan HastalarListeye Row'lar ekledim 
        // Reçete, reçete listesine eklenmek için DataGridView kodladım
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HASTB.Text = RandevuListesi.SelectedRows[0].Cells[1].Value.ToString();

            RantarTB.Text = RandevuListesi.SelectedRows[0].Cells[2].Value.ToString();
            RanZaCm.Text = RandevuListesi.SelectedRows[0].Cells[3].Value.ToString();

            if (HASTB.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(RandevuListesi.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {      //guncelleme botunu kodladım eger butun bilgiler girilirmezse
               //"kaybolan veri"yazılacak deilse randevu guncellenecek ve textbox ,combobox boşaltılacak 
            try
            {
                if (HASTB.Text == "" || RantarTB.Text == "" || RanZaCm.SelectedIndex == -1)
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string Hasta = HASTB.Text;
                    string RandevuTarihi = RantarTB.Text;
                    string RandevuZamani = RanZaCm.SelectedItem.ToString();

                    string Query = "update RandevuTbl  set Hastalar ='{0}',RandTarihi = '{1}',RandZamanı = '{2}'  where Randİd= '{3}'";

                    Query = string.Format(Query, Hasta, RandevuTarihi, RandevuZamani, Key);
                    Con.SetData(Query);
                    ShowRandevu();
                    MessageBox.Show("  Randevu Güncellendi");
                    HASTB.Text = "";
                    RantarTB.Text = "";
                    RanZaCm.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        //kaydet botunu kodladım eger butun bilgiler girilirmezse
        //"kaybolan veri"yazılacak deilse randevu eklenecek ve textbox ,combobox boşaltılacak 
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (HASTB.Text == "" || RantarTB.Text == "" || RanZaCm.SelectedIndex == -1)
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string Hasta = HASTB.Text;
                    string RandevuTarihi = RantarTB.Text;
                    string RandevuZamani = RanZaCm.SelectedItem.ToString();

                    string Query = "insert into RandevuTbl values ('{0}', '{1}', '{2}')";

                    Query = string.Format(Query, Hasta, RandevuTarihi, RandevuZamani, Key);
                    Con.SetData(Query);
                    ShowRandevu();
                    MessageBox.Show(" Randevu Eklendi");
                    HASTB.Text = "";
                    RantarTB.Text = "";
                    RanZaCm.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }




        }
        //silme botunu kodladım eger randevu secilmeze "randevu sec "yazılacak
        // degilse randevu silinecek 
        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (Key == 0)
                    {
                        MessageBox.Show("randevu seç");

                    }
                    else
                    {

                        string Query = " delete from HastalarTbl  where Hasİd = '{0}'";

                        Query = string.Format(Query, Key);
                        Con.SetData(Query);
                        ShowRandevu();
                        MessageBox.Show(" randevu Silindi");
                        HASTB.Text = "";
                        RantarTB.Text = "";
                        RanZaCm.SelectedIndex = -1;

                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        } 
        //cıkış botunu kodlaması messagebox kullandım eger cıkıs yapmak istiyorsan bir message (yes,no)cıkacak
           //no secersek "islem iptal edildi"yazilacak yes secersek programdan cıkacak
        private void label12_Click(object sender, EventArgs e)
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

            private void RanZaCm_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void panel5_Paint(object sender, PaintEventArgs e)
            {

            }
        
    }
}

