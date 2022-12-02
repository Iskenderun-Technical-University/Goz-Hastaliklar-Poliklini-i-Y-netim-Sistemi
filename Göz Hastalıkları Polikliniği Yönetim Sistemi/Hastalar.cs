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
    public partial class Hastalar : Form
    {
        fonkisyon con;
        public Hastalar()
        {
            InitializeComponent();
            con = new fonkisyon();
            ShowHastalar();
        }
        private void ShowHastalar()
        {
            try
            {
                string Query = "Select * from HastalarTbl";
                HastaListesi.DataSource = con.GetData(Query);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (HASAdTB.Text == "" || HasTelTB.Text == "" || HasAdresTB.Text == "" || HasALTB.Text == "" || CinCB.SelectedIndex == -1)
                {
                    MessageBox.Show("kaybolan veri");

                }
                else
                {
                    String Ad = HASAdTB.Text;
                    String Tel = HasTelTB.Text;
                    String Adres = HasAdresTB.Text;
                    String Cinsiyet = CinCB.SelectedItem.ToString();
                    String Alerji = HasALTB.Text;
                    String Query = "insert into HastalarTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                    Query = String.Format(Query, Ad, Tel, Adres, DtDP.Value.Date);
                    con.SetData(Query);
                    ShowHastalar();
                    MessageBox.Show(" Hasta Eklendi");
                    HASAdTB.Text = "";
                    HasTelTB.Text = "";
                    HasALTB.Text = "";
                    HasAdresTB.Text = "";
                    CinCB.SelectedIndex = -1;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
