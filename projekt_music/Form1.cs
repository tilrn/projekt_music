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
using projekt_music;


namespace projekt_music
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        connection baza = new connection();
        string connect = connection.connect();

        private void Form1_Load(object sender, EventArgs e)
        {
            lol();
        }
       
        public void lol()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connect))
            {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM kraji", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string ime = reader.GetString(1);
                    //comboBox1.Items.Add(ime);
                }
                

                con.Close();   
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Registracija lol = new Registracija();
            lol.Show();
            this.Hide();
        }
    }
}