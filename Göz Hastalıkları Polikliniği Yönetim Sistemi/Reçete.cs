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
        public Reçete()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void leble1_Click(object sender, EventArgs e)
        {

        }

        private void HasTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
