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
    public partial class pregled : Form
    {
        string maill;
        string nacinn;
        public pregled(string mail, string nacin)
        {
            maill = mail;
            nacinn = nacin;
            InitializeComponent();
        }
        public void Doda()
        {
            listBox1.Items.Add("ime:       priimek:     datum_roj:     email:     oddelek:     kraj:     ");
        }

        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Doda();
            List<string> Izpis = new List<string>();
            Izpis = bazaa.IzpisVsega();
            foreach (string x in Izpis)
            {
                listBox1.Items.Add(x);
                //NEDELA SE CIST
            }
        }

        private void pregled_Load(object sender, EventArgs e)
        {
            Doda();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main lol1 = new Main(maill, nacinn);
            lol1.Show();
            this.Hide();
        }
    }
}
