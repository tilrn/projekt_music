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
        public pregled()
        {
            InitializeComponent();
        }

        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("ime:       priimek:     datum_roj:     email:     oddelek:     kraj:     ");
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
            
        }
    }
}
