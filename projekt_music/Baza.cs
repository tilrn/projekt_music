using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace projekt_music
{
    class Baza
    {
        connection baza = new connection();
        string connect = connection.connect();

        //registracijas
        public void Registracija(string emaill, string passwordd)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT prijava1('" + emaill + "','" + passwordd + "');", con);
                com.ExecuteNonQuery();



                con.Close();
            }
        }
        public bool Prijava(string emaill, string passwordd)
        {
            int dela = 0;
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT Prijava('" + emaill + "','" + passwordd + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    dela = reader.GetInt32(0);
                }
                
                
                if (dela == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                con.Close();
            }
        }
        public bool Izpis(string emaill, string passwordd)
        {
            int dela = 0;
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {

                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT Prijava('" + emaill + "','" + passwordd + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    dela = reader.GetInt32(0);
                }


                if (dela == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                con.Close();
            }
        }
        public List<string> Kraji()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                List<string> kraji = new List<string>();
                NpgsqlCommand com = new NpgsqlCommand("SELECT kraji()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    string ime = reader.GetString(0);
                    kraji.Add(ime);
                    //comboBox1.Items.Add(ime);
                }


                con.Close();
                return kraji;
            }
        }
        public void Dodaj(string ime, string priimek, string datum_roj, string email, string kraj)
        {
            
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                //ERROR:  column "datum_roj" is of type timestamp without time zone but expression is of type character varying
                //LINE 2: VALUES(imee, priimekk, datum_rojj, emaill, (SELECT id FROM kraji...
                // to se ne dela v pg adminu 

                                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT Dodaj('"+ ime +"','"+ priimek +"''"+ datum_roj +"''"+ email +"''"+ kraj +"')", con);
                com.ExecuteNonQuery();
                
                con.Close();
            }
        }
        public List<string> IzpisVsega()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                List<string> Izpis = new List<string>();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM Izpis1()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    string ime = reader.GetString(0);
                    string priimek = reader.GetString(1);
                    string datum_roj = reader.GetString(2);
                    string email = reader.GetString(3);
                    string oddelek = reader.GetString(4);
                    string kraj = reader.GetString(5);

                    Izpis.Add(ime);
                    Izpis.Add(priimek);
                    Izpis.Add(datum_roj);
                    Izpis.Add(email);
                    Izpis.Add(oddelek);
                    Izpis.Add(kraj);
                    //comboBox1.Items.Add(ime);
                }


                con.Close();
                return Izpis;
            }
        }

    }

    
}
