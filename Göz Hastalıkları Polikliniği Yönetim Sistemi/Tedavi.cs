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
    //tedevilistesi veri tabanına baglama kodu
    public partial class Tedavi : Form
    {
        fonkisyon Con;
        public Tedavi()
        {
            InitializeComponent();
            Con = new fonkisyon();
            ShowTedavi();
        }
        private void ShowTedavi()
        {
            try
            {
                string Query = "Select * from TedaviTbl";
                TedaviListesi.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //tedavi formuna gecmek icin kodu
        private void label10_Click(object sender, EventArgs e)
        {
            Tedavi obj = new Tedavi();
            obj.Show();
            this.Hide();
        }
        //randevu formuna gecmek icin kodu
        private void label8_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
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
        //Textbox'lardan HastalarListeye Row'lar ekledim 
        // Reçete, reçete listesine eklenmek için DataGridView kodladım
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HasAdTB.Text= TedaviListesi.SelectedRows[0].Cells[1].Value.ToString();
            TedAdTB.Text = TedaviListesi.SelectedRows[0].Cells[2].Value.ToString();

            TedFiyatTB.Text = TedaviListesi.SelectedRows[0].Cells[3].Value.ToString();
            
            if (HasAdTB.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TedaviListesi.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        //kaydet botunu kodladım eger butun bilgiler girilirmezse
        //"kaybolan veri"yazılacak deilse randevu eklenecek ve textbox ,combobox boşaltılacak 
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (HasAdTB.Text==""|| TedAdTB.Text == "" || TedFiyatTB.Text == "" )
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string HastaAdı = HasAdTB.Text;
                     string TedaviAdı = TedAdTB.Text;
                    string TedaviFiyatı = TedFiyatTB.Text;
                    
                    string Query = "insert into  TedaviTbl values('{0}', '{1}','{2}')";

                    Query = string.Format(Query,HastaAdı, TedaviAdı , TedaviFiyatı);
                    Con.SetData(Query);
                    ShowTedavi();
                    MessageBox.Show(" Tedavi  Eklendi");
                    HasAdTB.Text = "";
                    TedAdTB.Text = "";
                    TedFiyatTB.Text = "";
                    

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        //guncelleme botunu kodladım eger butun bilgiler girilirmezse
        //"kaybolan veri"yazılacak deilse randevu guncellenecek ve textbox ,combobox boşaltılacak 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (HasAdTB.Text == ""||TedAdTB.Text == "" || TedFiyatTB.Text == "" )
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string HastaAdı = HasAdTB.Text;
                    string TedaviAdı = TedAdTB.Text;
                    string TedaviFiyatı = TedFiyatTB.Text;

                    string Query = "update  TedaviTbl set HastaAdı='{0}', TedaviAdı ='{1}',TedaviFiyati = '{2}' where Tedaviİd = '{3}'";

                    Query = string.Format(Query, HastaAdı,TedaviAdı, TedaviFiyatı, Key);
                    Con.SetData(Query);
                    ShowTedavi();
                    MessageBox.Show(" Tedavi Güncellendi");
                    HasAdTB.Text = "";
                    TedAdTB.Text = "";
                    TedFiyatTB.Text = "";
                    

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
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("tedaviyi seç");

                }
                else
                {

                    string Query = " delete from TedaviTbl  where Tedaviİd = '{0}'";

                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowTedavi();
                    MessageBox.Show(" Tedavi Silindi");
                    HasAdTB.Text = "";
                    TedAdTB.Text = "";
                    TedFiyatTB.Text = "";
                   

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HasTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
