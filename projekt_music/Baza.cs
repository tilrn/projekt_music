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
                    con.Close();
                    return true;
                    
                }
                else
                {
                    con.Close();
                    return false;
                    
                }
                    
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
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
                
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

                NpgsqlCommand com = new NpgsqlCommand("SELECT Dodaj2('"+ ime +"','"+ priimek +"','"+ datum_roj +"','"+ email +"','"+ kraj +"')", con);
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
        public List<string> VsiZaposleni()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                List<string> vsizaposleni = new List<string>();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisZaposlenih1()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    string ime = reader.GetString(0);
                    
                    vsizaposleni.Add(ime);
                   
                }


                con.Close();
                return vsizaposleni;
            }
        }
        public List<string> VsiZaposleniPriimek(string ime)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                List<string> vsizaposleni = new List<string>();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM izpisZaposlenihPriimek('" + ime + "' )", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    string priimek = reader.GetString(0);

                    vsizaposleni.Add(priimek);

                }


                con.Close();
                return vsizaposleni;
            }
        }
        public List<string> usersIzpis()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                List<string> userlist = new List<string>();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM usersIzpis1()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    string user = reader.GetString(0);

                    userlist.Add(user);

                }


                con.Close();
                return userlist;
            }
        }
        public string usersIzpisOboje(string ime)
        {
            string geslo = "";
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  usersIzpisOboje1('"+ ime +"')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {

                    geslo = reader.GetString(0);

                    

                }


                con.Close();
                return geslo;
            }
        }
        public void adminUser(string ime)
        {
            
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT dodajAdmin('" + ime + "')", con);
                com.ExecuteNonQuery();



                con.Close();
                
            }
        }
    }

    
}
