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
    public partial class Reçete : Form
    {
        fonkisyon Con;
        public Reçete()
        {
            InitializeComponent();
            Con = new fonkisyon();
            ShowReçete();
        }
        private void ShowReçete()
        {
            try
            {
                string Query = "Select * from ReçeteTbl";
                ReçeteLİstesi.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {
            Hastalar obj = new Hastalar();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

            Tedavi obj = new Tedavi();
            obj.ShowDialog();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Reçete obj = new Reçete();
            obj.Show();
            this.Hide();
        }
        // Reçete güncellenmesi için buttonu kodladım...
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (HasTB.Text == "" || TedTB.Text == "" || İlTB.Text == "" || MikTB.Text == "" || FiyatTb.Text == "")
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string Hasta = HasTB.Text;
                    string Tedavi = TedTB.Text;
                    string İlaç = İlTB.Text;
                    string Miktar = MikTB.Text;
                    string Fiyat = FiyatTb.Text;

                    string Query = "update ReçeteTbl  set Hasta ='{0}',Tedavi = '{1}',İlaç = '{2}',Miktar = '{3}',Fiyat='{4}' where Reçİd= '{5}'";

                    Query = string.Format(Query, Hasta, Tedavi, İlaç, Miktar,Fiyat, Key);
                    Con.SetData(Query);
                    ShowReçete();
                    MessageBox.Show(" Reçete Güncellendi");
                    HasTB.Text = "";
                    TedTB.Text = "";
                    İlTB.Text = "";
                    MikTB.Text = "";
                    FiyatTb.Text = "";


                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void leble1_Click(object sender, EventArgs e)
        {

        }

        private void HasTB_TextChanged(object sender, EventArgs e)
        {

        }
        // Reçete, reçete listesine eklenmek için DataGridView kodladım
        int Key = 0;
        private void ReçeteLİstesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HasTB.Text = ReçeteLİstesi.SelectedRows[0].Cells[1].Value.ToString();

            TedTB.Text = ReçeteLİstesi.SelectedRows[0].Cells[2].Value.ToString();
            İlTB.Text = ReçeteLİstesi.SelectedRows[0].Cells[3].Value.ToString();
            MikTB.Text = ReçeteLİstesi.SelectedRows[0].Cells[4].Value.ToString();
           FiyatTb.Text = ReçeteLİstesi.SelectedRows[0].Cells[5].Value.ToString();
            if (HasTB.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ReçeteLİstesi.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        // Reçete kaydetilsin diye  buttonu kodladım...
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (HasTB.Text == "" || TedTB.Text == "" || İlTB.Text == "" || MikTB.Text == "" || FiyatTb.Text == "")
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string Hasta = HasTB.Text;
                    string Tedavi = TedTB.Text;
                    string İlaç = İlTB.Text;                 
                    string Miktar = MikTB.Text;
                    string Fiyat = FiyatTb.Text;
                    string Query = "insert into ReçeteTbl values('{0}', '{1}', '{2}', '{3}','{4}')";

                    Query = string.Format(Query, Hasta,Tedavi, İlaç, Miktar,Fiyat);
                    Con.SetData(Query);
                    ShowReçete();
                    MessageBox.Show(" Reçete Eklendi");
                    HasTB.Text = "";
                    TedTB.Text = "";
                    İlTB.Text = "";
                    MikTB.Text = "";
                    FiyatTb.Text = "";
                    

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        // Reçete, reçete listesinden silinmesi için buttonu kodladım...
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("hastayı seç");

                }
                else
                {

                    string Query = " delete from ReçeteTbl  where Reçİd = '{0}'";

                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowReçete();
                    MessageBox.Show(" Hasta Silindi");
                    HasTB.Text = "";
                    TedTB.Text = "";
                    İlTB.Text = "";
                    MikTB.Text = "";
                    Fiyat.Text = "";
                   

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void Fiyat_Click(object sender, EventArgs e)
        {

        }
    }
}
