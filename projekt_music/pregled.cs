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
        

        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void pregled_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("ime:       priimek:     datum_roj:     email:     oddelek:     kraj:     ");                   
            List<string> Izpis = new List<string>();
            Izpis = bazaa.IzpisVsega();
            foreach (string x in Izpis)
            {
                listBox1.Items.Add(x);
                //NEDELA SE CIST
            }


            /*
             CREATE OR REPLACE FUNCTION Izpis1()
RETURNS TABLE (ime varchar, priimek varchar, datum_roj timestamp, email varchar, ime_oddelka varchar, ime_kraja varchar) AS
$$
DECLARE

BEGIN
RETURN QUERY
SELECT z.ime, z.priimek, z.datum_roj,z.email,o.ime_oddelka,k.ime_kraja
FROM zaposleni z INNER JOIN oddelki o ON z.oddelek_id = o.id
INNER JOIN kraji k ON k.id = z.kraj_id;

END;
$$ LANGUAGE 'plpgsql';

            nevem zaka ne dela
            
            
            
            
             
             
              */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main lol1 = new Main(maill, nacinn);
            lol1.Show();
            this.Hide();
        }
    }
}
