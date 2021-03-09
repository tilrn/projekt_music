using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_music
{
    public partial class Kraji : Form
    {
        string maill;
        string nacinn;
        public Kraji(string mail, string nacin)
        {
            InitializeComponent();
            maill = mail;
            nacinn = nacin;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main lol1 = new Main(maill, nacinn);
            lol1.Show();
            this.Hide();

        }
    }
}
