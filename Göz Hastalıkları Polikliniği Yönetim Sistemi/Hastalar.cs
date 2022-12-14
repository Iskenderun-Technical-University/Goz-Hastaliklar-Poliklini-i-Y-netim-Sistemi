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
    //hastalarlistesi veri tabanına baglama kodu
    public partial class Hastalar : Form
    { 
       
        fonkisyon Con;
        public Hastalar()
        {
            InitializeComponent();
            Con = new fonkisyon();
            ShowHastalar();
        }
        private void ShowHastalar()
        {  
            try
            {
                string Query = "Select * from HastalarTbl";
                HastaListesi.DataSource = Con.GetData(Query);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //guncelleme botunu kodladım eger butun bilgiler girilirmezse
        //"kaybolan veri"yazılacak deilse randevu guncellenecek ve textbox ,combobox boşaltılacak 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (HASAdTB.Text == "" || HasTelTB.Text == "" || HasAdresTB.Text == "" || HasALTB.Text == "" || HasYasTB.Text == "" || CinCB.SelectedIndex == -1)
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string Ad = HASAdTB.Text;
                    string Tel = HasTelTB.Text;
                    string Adres = HasAdresTB.Text;
                    string Cinsiyet = CinCB.SelectedItem.ToString();
                    string Alerji = HasALTB.Text;
                    string Yas = HasYasTB.Text;
                    string Query = "update HastalarTbl  set HasAdı ='{0}',HasTel = '{1}',HasAdres = '{2}',HasYas = '{3}',HasCinsiyeti = '{4}',HasAlerji = '{5}'  where Hasİd= '{6}'";

                    Query = string.Format(Query, Ad, Tel, Adres, Yas, Cinsiyet, Alerji, Key);
                    Con.SetData(Query);
                    ShowHastalar();
                    MessageBox.Show(" Hasta Güncellendi");
                    HASAdTB.Text = "";
                    HasTelTB.Text = "";
                    HasALTB.Text = "";
                    HasAdresTB.Text = "";
                    HasYasTB.Text = "";
                    CinCB.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        //kaydet botunu kodladım eger butun bilgiler girilirmezse
        //"kaybolan veri"yazılacak deilse randevu eklenecek ve textbox ,combobox boşaltılacak 
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (HASAdTB.Text == "" || HasTelTB.Text == "" || HasAdresTB.Text == "" || HasALTB.Text == "" ||HasYasTB.Text==""|| CinCB.SelectedIndex == -1)
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string Ad = HASAdTB.Text;
                   string Tel = HasTelTB.Text;
                    string Adres = HasAdresTB.Text;
                    string Cinsiyet = CinCB.SelectedItem.ToString();
                    string Alerji = HasALTB.Text;
                    string Yas = HasYasTB.Text;
                    string Query = "insert into HastalarTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                  
                   Query = string.Format(Query, Ad, Tel, Adres, Yas,Cinsiyet,Alerji);
                    Con.SetData(Query);
                    ShowHastalar();
                    MessageBox.Show(" Hasta Eklendi");
                    HASAdTB.Text = "";
                    HasTelTB.Text = "";
                    HasALTB.Text = "";
                    HasAdresTB.Text = "";
                    HasYasTB.Text = "";
                    CinCB.SelectedIndex = -1;

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
                if ( Key == 0 )
                {
                    MessageBox.Show("hastayı seç");

                }
                else
                {
                    
                    string Query = " delete from HastalarTbl  where Hasİd = '{0}'";

                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowHastalar();
                    MessageBox.Show(" Hasta Silindi");
                    HASAdTB.Text = "";
                    HasTelTB.Text = "";
                    HasALTB.Text = "";
                    HasAdresTB.Text = "";
                    HasYasTB.Text = "";
                    CinCB.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox6_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        //Textbox'lardan HastalarListeye Row'lar ekledim 
        // Reçete, reçete listesine eklenmek için DataGridView kodladım
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HASAdTB.Text = HastaListesi.SelectedRows[0].Cells[1].Value.ToString();
           
            HasTelTB.Text = HastaListesi.SelectedRows[0].Cells[2].Value.ToString();
            HasAdresTB.Text = HastaListesi.SelectedRows[0].Cells[3].Value.ToString();
            HasYasTB.Text = HastaListesi.SelectedRows[0].Cells[4].Value.ToString();
            CinCB.Text = HastaListesi.SelectedRows[0].Cells[5].Value.ToString();
            HasALTB.Text = HastaListesi.SelectedRows[0].Cells[6].Value.ToString();
            if (HASAdTB.Text == "")
            {
                Key = 0;
            }
            else
            {
               Key=Convert.ToInt32(HastaListesi.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //recete formuna gecmek icin kodu
        private void label9_Click(object sender, EventArgs e)
        {
            Reçete obj = new Reçete();
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

        private void HASAdTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void HasTelTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
