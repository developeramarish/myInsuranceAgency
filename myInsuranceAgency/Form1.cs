using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myInsuranceAgency
{
    public partial class F : Form
    {
        //adatbáziskapcsolat létrehozása objektumorientáltan
        Kapcsolat k = new Kapcsolat();
        String lekerdezes;

        public F()
        {
            InitializeComponent();
        }

        //ha az x ikonra kattintok
        private void exitLogin_Click(object sender, EventArgs e)
        {
            //kilépés az alkalmazásból
            Application.Exit();
        }

        //ha a belépés gombra kattintok
        private void btnBejelentk_Click(object sender, EventArgs e)
        {
            try
            {
                lekerdezes = "select * from felhasznalok where fnev = '" + textFelhNev.Text + "' and jelszo = '" + Titkosit.SHA5Hash(textJelszo.Text) + "'";
                DataSet ds = k.getData(lekerdezes);
                //ha van találat a lekérdezésre:
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Titkosit.SHA5Hash(textJelszo.Text) == ds.Tables[0].Rows[0][2].ToString())//a rows-ból a 0 a sor indexe az 2 a cella indexe a soron belül
                    {
                        string id = ds.Tables[0].Rows[0][0].ToString();
                        Menu mn = new Menu(id);//átadom a felhasználó id-t meghíváskor
                        //mutatom a menüt
                        mn.Show();
                        //elrejtem a bejelentkezést
                        this.Hide();
                    }
                }
                else MessageBox.Show("Hibás felhasználónév, vagy jelszó!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
