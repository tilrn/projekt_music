using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace projekt_music
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Baza bazaa = new Baza();
            string email = textBox3.Text;
            string password = textBox4.Text;
            bazaa.Registracija(email, password);

            Form1 lol1 = new Form1();
            lol1.Show();
            this.Hide();

        }
    }
}
