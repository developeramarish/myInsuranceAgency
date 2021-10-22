using System;
using System.Collections.Generic;
using System.Data;//be kellett emelni
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//be kellett emelni
//hozzá kellett adni a MySqlData bővítményt (projektre kattintok, add reference, extensions, MySqlData)
using MySql.Data.MySqlClient;

namespace myInsuranceAgency
{
    class Kapcsolat
    {
        protected MySqlConnection GetMySqlConnection()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "data source=127.0.0.1;username=root;password=; database=agentura;";
            return con;
        }

        //olvasás az adatbázisból
        public DataSet getData(String lekerdezes)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection con = GetMySqlConnection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = lekerdezes;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban!  " + e.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ds;
            }
        }

        //adatbázisba írás
        public void setData(String lekerdezes)
        {
            try
            {
                MySqlConnection con = GetMySqlConnection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = lekerdezes;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sikeres adatfeldolgozás!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Hiba az adatbázis kapcsolatban!  " + e.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //ellenőrző függvény, mellyel ellenőrizni tudjuk, hogy felhasználó felvitelkor létezik-e már az adott felhasználó
        public bool NevEll(string fNev)
        {
            //hamis az alapértelmezett
            bool vane = false;
            List<string> nevLista = new List<string>();
            Kapcsolat k = new Kapcsolat();
            string lekerdezes = "select fnev from felhasznalok";

            try
            {
                DataSet ds = k.getData(lekerdezes);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    nevLista.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            foreach (string item in nevLista)
            {
                if (item == fNev)
                {
                    vane = true;
                }
            }
            return vane;
        }
    }
}
