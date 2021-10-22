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
    public delegate void FB();//ez ahhoz kell, hogy a user controlból elérjem a Menu.cs eljárását
    public partial class FelhasznModosit : UserControl
    {
        public event FB CustomControlFB;//ez ahhoz kell, hogy a user controlból elérjem a Menu.cs eljárását
        public FelhasznModosit()
        {
            InitializeComponent();
        }

        //adatbáziskapcsolat létrehozása objektumorientáltan
        Kapcsolat k = new Kapcsolat();
        String lekerdezes;

        //a jelszó titkosításához létrehozok egy objektumpédányt
        Titkosit t = new Titkosit();

        //amikor betöltődik
        private void FelhasznModosit_Load(object sender, EventArgs e)
        {
            AdatBetolt();
        }

        //eljárás a legördülő menü felhasználónevekkel történő feltöltésére
        public void AdatBetolt()
        {
            try
            {
                lekerdezes = "select * from felhasznalok";
                DataSet ds = k.getData(lekerdezes);
                //feltöltöm adatokkal a felhasználó legördülőt (a három sor mindegyike kell!)
                comboBoxFelhaszn.DataSource = ds.Tables[0];
                comboBoxFelhaszn.DisplayMember = "fnev";
                comboBoxFelhaszn.ValueMember = "fnev";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //ha a legördülőből kiválasztom a módosítani kívánt felhasználót
        private void comboBoxFelhaszn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //betöltöm a mezőkbe a felhasználónevet és a jogosultságot
            //először lekérdezem, az kiválasztott felhasználónévhez tartozó adatokat
            lekerdezes = "select fnev, admin from felhasznalok where fnev ='" + comboBoxFelhaszn.Text + "'";
            DataSet ds = k.getData(lekerdezes);
            //ha van találat a lekérdezésre:
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    //felhasználónév mező kitöltése
                    textFelhasznNev.Text = ds.Tables[0].Rows[0][0].ToString();
                    //adminisztrátori jogosultság kitöltése
                    if (ds.Tables[0].Rows[0][1].ToString() == "True")//ha van akkor igaz
                    {
                        comboBoxAdmin.Text = "van";
                    }
                    else comboBoxAdmin.Text = "nincs";//ha nem igaz, akkor nincs

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //ha a jelszómodosítás módosít gombjára kattintok
        private void btnJelszoMod_Click(object sender, EventArgs e)
        {
            //ha nem üresek a jelszók, vagy nem üres karakterek (space)
            if (!String.IsNullOrEmpty(textJelszo.Text) && !String.IsNullOrWhiteSpace(textJelszo.Text) && !String.IsNullOrEmpty(textJelszo2.Text) && !String.IsNullOrWhiteSpace(textJelszo2.Text))
            {
                //ellenőrzöm, hogy a két beírt jelszó egyezik-e
                if (textJelszo.Text == textJelszo2.Text)
                {
                    try
                    {
                        lekerdezes = "UPDATE `felhasznalok` SET `jelszo` = '" + t.LeTitkosit(textJelszo.Text) + "' WHERE `fnev` = '" + comboBoxFelhaszn.Text + "';";
                        k.setData(lekerdezes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //ha nem egyezik meg a két jelszó
                else
                {
                    MessageBox.Show("A két beírt jelszó nem egyezik meg!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Kérjük töltse ki mindkét jelszó mezőt!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //ha a felhasználónév/jogosultság módosít gombjára kattintok
        private void btnFelhasznMod_Click(object sender, EventArgs e)
        {
            //ha nem üresek a jelszók, vagy nem üres karakterek (space)
            if (!String.IsNullOrEmpty(textFelhasznNev.Text) && !String.IsNullOrWhiteSpace(textFelhasznNev.Text) && !String.IsNullOrEmpty(comboBoxAdmin.Text) && !String.IsNullOrWhiteSpace(comboBoxAdmin.Text))
            {
                //ha változtatok a felhasználónéven (le kell, hogy ellenőrizzem, hogy van-e már ilyen nevű felhasználó)
                if (comboBoxFelhaszn.Text != textFelhasznNev.Text)
                {
                    //ellenőrzöm, hogy már van-e ilyen nevű felhasználó
                    bool vane = k.NevEll(textFelhasznNev.Text);
                    if (vane == false)
                    {
                        adatModosit();
                    }
                    //ha már van ilyen nevű felhasználó
                    else MessageBox.Show("Már van ilyen nevű felhasználó!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //ha nem változtatok felhasználónevet
                //(ilyenkor nem kell a felhasználónév ellenőrzés, mert nem engedné a jogosultság módosítást, mert találna azonos felhasználót)
                else
                {
                    adatModosit();
                }                
            }            
            else
            {
                MessageBox.Show("Kérjük töltsön ki minden mezőt!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //felhasználónév + jogosultság módosító eljárás
        public void adatModosit()
        {
            try
            {
                int adminVane = 0;//alapértelmezett, hogy nincs adminisztrátori jogosultság
                //ha van
                if (comboBoxAdmin.Text == "van")
                {
                    adminVane = 1;
                }
                lekerdezes = "UPDATE `felhasznalok` SET `fnev` = '" + textFelhasznNev.Text + "', `admin` = '" + adminVane + "' WHERE `fnev` = '" + comboBoxFelhaszn.Text + "';";
                k.setData(lekerdezes);
                AdatBetolt();//frissítem az oldal tartalmát
                //itt hívom meg az bejelentkezett felhasználó adatainak frissítéséhez a Menu.cs FelhasznBeall eljárását:
                CustomControlFB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             
        }

        //ha a törlés gombra kattintok
        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan törölni szeretné a felhasználót?", "Figyelmeztetés", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    lekerdezes = "delete from felhasznalok where fnev ='" + comboBoxFelhaszn.Text + "'";
                    k.setData(lekerdezes);
                    AdatBetolt();//frissítem az oldal tartalmát
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
