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

        private void label10_Click(object sender, EventArgs e)
        {
            Tedavi obj = new Tedavi();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Hastalar obj = new Hastalar();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Reçete obj = new Reçete();
            obj.Show();
            this.Hide();

        }
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            TedAdTB.Text = TedaviListesi.SelectedRows[0].Cells[1].Value.ToString();

            TedFiyatTB.Text = TedaviListesi.SelectedRows[0].Cells[2].Value.ToString();
            
            if (TedAdTB.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TedaviListesi.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (TedAdTB.Text == "" || TedFiyatTB.Text == "" )
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string TedaviAdı = TedAdTB.Text;
                    string TedaviFiyatı = TedFiyatTB.Text;
                    
                    string Query = "insert into  TedaviTbl values('{0}', '{1}')";

                    Query = string.Format(Query, TedaviAdı , TedaviFiyatı);
                    Con.SetData(Query);
                    ShowTedavi();
                    MessageBox.Show(" Tedavi  Eklendi");
                    TedAdTB.Text = "";
                    TedFiyatTB.Text = "";
                    

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TedAdTB.Text == "" || TedFiyatTB.Text == "" )
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    string TedaviAdı = TedAdTB.Text;
                    string TedaviFiyatı = TedFiyatTB.Text;

                    string Query = "update  TedaviTbl set TedaviAdı ='{0}',TedaviFiyati = '{1}', where Tedaviİd = '{2}'";

                    Query = string.Format(Query, TedaviAdı, TedaviFiyatı, Key);
                    Con.SetData(Query);
                    ShowTedavi();
                    MessageBox.Show(" Tedavi Güncellendi");
                    TedAdTB.Text = "";
                    TedFiyatTB.Text = "";
                    

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
