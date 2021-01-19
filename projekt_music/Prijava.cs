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
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Baza bazaa = new Baza();
            string email = textBox1.Text;
            string password = textBox2.Text;
            bool dela = bazaa.Prijava(email, password);
            if(dela == true)
            {
                Main lol1 = new Main();
                lol1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Prijava neuspešna");

            }


            
        }
    }
}
