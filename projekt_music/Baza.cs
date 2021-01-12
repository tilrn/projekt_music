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
        public void Prijava(string emaill, string passwordd)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT Prijava('" + emaill + "','" + passwordd + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int dela = reader.GetInt32(0);

                    if (dela == 0)
                    {
                        MessageBox.Show("Something went wrong");
                    }
                    else if (dela == 1)
                    {
                        Form1 forma = new Form1();
                        forma.Show();
                        Prijava.Hide();
                    }
                }
                con.Close();
            }
    }

    
}
