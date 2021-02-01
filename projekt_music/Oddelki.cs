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
    public partial class Oddelki : Form
    {
        public Oddelki()
        {
            InitializeComponent();
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();
        private void Oddelki_Load(object sender, EventArgs e)
        {
            List<string> oddelki = new List<string>();
            oddelki = bazaa.oddelki();
            foreach (string x in oddelki)
            {
                comboBox1.Items.Add(x);
            }
        }
    }
}
