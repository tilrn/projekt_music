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
        public void DodajZkraju(string ime, string priimek, string datum_roj, string email, string imek,int postna)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                //ERROR:  column "datum_roj" is of type timestamp without time zone but expression is of type character varying
                //LINE 2: VALUES(imee, priimekk, datum_rojj, emaill, (SELECT id FROM kraji...
                // to se ne dela v pg adminu 

                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT DodajZkraju('" + ime + "','" + priimek + "','" + datum_roj + "','" + email + "','" + imek + "','"+ postna +"')", con);
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

                    string vse = reader.GetString(0)+"  "+ reader.GetString(1) +"  "+ reader.GetString(2)+"  "+ reader.GetString(3)+"  "+ reader.GetString(4)+"  "+ reader.GetString(5);
                    
                    
                    
                    
                    Izpis.Add(vse);
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
        public void deleteUser(string ime)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT izbrisiUserja('" + ime + "')", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public void UpdateUser(string imestaro, string geslostaro, string imenovo, string geslonovo)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT updateUser('" + imestaro + "','" + geslostaro+"','"+imenovo+"', '"+geslonovo+"')", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public bool Admin(string ime)
        {
            bool dela = false;
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  admin('"+ime+"')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {

                    dela = reader.GetBoolean(0);


                }
                if(dela == true)
                {
                    con.Close();
                    return true;
                }
                else if (dela == false)
                {
                    con.Close();
                    return false;
                }

                return false;
                

            }


        }
        public List<string> oddelki()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();
                List<string> oddelki = new List<string>();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM oddelki()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    string ime = reader.GetString(0);

                    oddelki.Add(ime);

                }


                con.Close();
                return oddelki;
            }
        }
        
        public string izpisGmaila(string ime,string priimek)
        {
            string gmail = "";
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  gmailUserja('" + ime + "', '"+priimek+"')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {

                    gmail = reader.GetString(0);



                }


                con.Close();
                return gmail;
            }
        }
        public string izpisKraja(string ime, string priimek)
        {
            string kraj = "";
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  krajIzpis('" + ime + "', '" + priimek + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {

                    kraj = reader.GetString(0);



                }


                con.Close();
                return kraj;
            }
        }
        public void DELETE(string ime, string priimek)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  IzbrisUporabnika('" + ime + "', '" + priimek + "')", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public void UpdateUporabnik(string krajj, string imee, string priimekk, string email, string staroIme, string starpriimek)
        {

            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM  updateUporabnika('" + krajj + "', '" + imee + "','" + priimekk + "', '" + email + "''" + staroIme + "', '" + starpriimek + "')", con);
                com.ExecuteNonQuery();



                con.Close();

            }
        }
        public int izpisPostne(string krajIme)
        {
            int postna = 0;
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT vrniPostnoSt('" + krajIme + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {

                    postna = Convert.ToInt32(reader.GetString(0));



                }


                con.Close();
                return postna;
            }
        }

    }

    
}
