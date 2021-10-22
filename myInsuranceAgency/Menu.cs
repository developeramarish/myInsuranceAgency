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
    public partial class Menu : Form
    {
        string id;//ebben tárolom el majd az id-t amivel be vagyunk jelentkezve
        //adatbáziskapcsolat létrehozása objektumorientáltan
        Kapcsolat k = new Kapcsolat();
        String lekerdezes;
        public Menu(string azon)//megkapom a bejelentkezett felhasználó nevét
        {
            InitializeComponent();
            id = azon;//bejelentkezett felhasználó id-jének eltárolása
            FelhasznBeall();//meghívom az eljárást
            //ez ahhoz kell, hogy a user controlból elérjem a Menu.cs eljárását
            felhasznModosit1.CustomControlFB += new MyUserControl.FB(FelhasznBeall);
            //ezzel érem el a user controlból a Menu.cs GetId eljárását
            ujUgyfel1.CustomControlGI += new MyUserControl.GI(GetId);
            jelszoCsere1.CustomControlGIJ += new MyUserControl.GIJ(GetId);
            ugyfelKeres1.CustomControlGIK += new MyUserControl.GIK(GetId);
        }

        //az eljárás funciói:
        //bejelentkezett felhasználó nevének kiíratása
        //admin jogosultság ellenőrzése
        //menüpontok admin jogosultság szerint jelennek meg
        //meghívhatom bejelentkezéskor és felhasználó módosítás után is
        public void FelhasznBeall()
        {
             
            lekerdezes = "select fnev, admin from felhasznalok where id ='" + id + "'";
            DataSet ds = k.getData(lekerdezes);
            //ha van találat a lekérdezésre:
            if (ds.Tables[0].Rows.Count > 0)
            {
                labelUser.Text = ds.Tables[0].Rows[0][0].ToString();
                //ha nincs admin jogosultság
                if (ds.Tables[0].Rows[0][1].ToString() == "False")//ha van akkor igaz
                {
                    pUjFel.Visible = false;
                    labelUjFelh.Visible = false;
                    pFelMod.Visible = false;
                    labelFMod.Visible = false;
                }
                //ha van admin jogosultság
                else
                {
                    pUjFel.Visible = true;
                    labelUjFelh.Visible = true;
                    pFelMod.Visible = true;
                    labelFMod.Visible = true;
                }
            }
        }

        //meghívásával visszaadja a bejelentkezett felhasználó id-jét
        public string GetId()
        {
            return id;
        }

        //a menü betöltődésekor
        private void Menu_Load(object sender, EventArgs e)
        {
            ujFelhaszn1.Visible = false;//betöldőtéskor nem látszik a felület (majd csak akkor, ha a menüpontra kattintok)
            felhasznModosit1.Visible = false;
            ujUgyfel1.Visible = false;
            jelszoCsere1.Visible = false;
            ugyfelKeres1.Visible = false;
        }

        //ha az x ikonra kattintok
        private void exitMenu_Click(object sender, EventArgs e)
        {
            //kilépés az alkalmazásból
            Application.Exit();
        }

        //ügyfél keresés képre kattintás
        private void pUgyfelKeres_Click(object sender, EventArgs e)
        {
            ugyfelKeres1.Visible = true;
            ugyfelKeres1.BringToFront();
            ugyfelKeres1.KeresVisszaAllit();//visszaállítom a user controlt kezdő állapotba
        }
        //ügyfél keresés feliratra kattintás
        private void labelUgyfelKeres_Click(object sender, EventArgs e)
        {
            ugyfelKeres1.Visible = true;
            ugyfelKeres1.BringToFront();
            ugyfelKeres1.KeresVisszaAllit();//visszaállítom a user controlt kezdő állapotba
        }

        //ügyfél rögzítés képre kattintás
        private void pUgyfelRogzit_Click(object sender, EventArgs e)
        {
            ujUgyfel1.Visible = true;//láthatóvá teszi a felületet
            ujUgyfel1.BringToFront();//előre hozza
        }

        //ügyfél rögzítés feliratra kattintás
        private void labelUgyfelRogzit_Click(object sender, EventArgs e)
        {
            ujUgyfel1.Visible = true;//láthatóvá teszi a felületet
            ujUgyfel1.BringToFront();//előre hozza
        }

        //jelszócsere feliratra kattintás
        private void labelJelszoCsere_Click(object sender, EventArgs e)
        {
            jelszoCsere1.Visible = true;
            jelszoCsere1.BringToFront();
        }

        //jelszócsere képre kattintás
        private void pJelszoCsere_Click(object sender, EventArgs e)
        {
            jelszoCsere1.Visible = true;
            jelszoCsere1.BringToFront();
        }

        //kijelenkezés képre kattintok
        private void pBoxKijel_Click(object sender, EventArgs e)
        {
            F f1 = new F();
            //menü elrejtése
            this.Hide();
            //bejelentkezés oldal mutatása:
            f1.Show();
        }

        //kijelentkezés feliratra kattintok
        private void labelKijel_Click(object sender, EventArgs e)
        {
            F f1 = new F();
            //menü elrejtése
            this.Hide();
            //bejelentkezés oldal mutatása:
            f1.Show();
        }

        //új felhasználó felirat
        private void labelUjFelh_Click(object sender, EventArgs e)
        {
            ujFelhaszn1.Visible = true;//láthatóvá teszi a felületet
            ujFelhaszn1.BringToFront();//előre hozza
        }

        //új felhasználó kép 
        private void pUjFel_Click(object sender, EventArgs e)
        {
            ujFelhaszn1.Visible = true;//láthatóvá teszi a felületet
            ujFelhaszn1.BringToFront();//előre hozza
        }

        //felhasználó módosítás kép
        private void labelFMod_Click(object sender, EventArgs e)
        {
            felhasznModosit1.Visible = true;//láthatóvá teszi a felületet
            felhasznModosit1.BringToFront();//előre hozza
            felhasznModosit1.AdatBetolt();//frissítem az oldalt, mert betöltődés óta lehet, hogy vittem fel új felhasználót
        }

        //felhasználó módosítás felirat
        private void pFelMod_Click(object sender, EventArgs e)
        {
            felhasznModosit1.Visible = true;//láthatóvá teszi a felületet
            felhasznModosit1.BringToFront();//előre hozza
            felhasznModosit1.AdatBetolt();//frissítem az oldalt, mert betöltődés óta lehet, hogy vittem fel új felhasználót
        }

        //egérföléhúzás
        private void labelUgyfelKeres_MouseHover(object sender, EventArgs e)
        {
            labelUgyfelKeres.ForeColor = Color.Silver;
        }
        //egér már nincs fölötte
        private void labelUgyfelKeres_MouseLeave(object sender, EventArgs e)
        {
            labelUgyfelKeres.ForeColor = Color.White;
        }

        private void pUgyfelKeres_MouseHover(object sender, EventArgs e)
        {
            labelUgyfelKeres.ForeColor = Color.Silver;
        }

        private void pUgyfelKeres_MouseLeave(object sender, EventArgs e)
        {
            labelUgyfelKeres.ForeColor = Color.White;
        }

        private void labelUgyfelRogzit_MouseHover(object sender, EventArgs e)
        {
            labelUgyfelRogzit.ForeColor = Color.Silver;
        }

        private void labelUgyfelRogzit_MouseLeave(object sender, EventArgs e)
        {
            labelUgyfelRogzit.ForeColor = Color.White;
        }

        private void pUgyfelRogzit_MouseHover(object sender, EventArgs e)
        {
            labelUgyfelRogzit.ForeColor = Color.Silver;
        }

        private void pUgyfelRogzit_MouseLeave(object sender, EventArgs e)
        {
            labelUgyfelRogzit.ForeColor = Color.White;
        }

        private void labelJelszoCsere_MouseHover(object sender, EventArgs e)
        {
            labelJelszoCsere.ForeColor = Color.Silver;
        }

        private void labelJelszoCsere_MouseLeave(object sender, EventArgs e)
        {
            labelJelszoCsere.ForeColor = Color.White;
        }

        private void pJelszoCsere_MouseHover(object sender, EventArgs e)
        {
            labelJelszoCsere.ForeColor = Color.Silver;
        }

        private void pJelszoCsere_MouseLeave(object sender, EventArgs e)
        {
            labelJelszoCsere.ForeColor = Color.White;
        }

        private void labelUjFelh_MouseHover(object sender, EventArgs e)
        {
            labelUjFelh.ForeColor = Color.Silver;
        }

        private void labelUjFelh_MouseLeave(object sender, EventArgs e)
        {
            labelUjFelh.ForeColor = Color.White;
        }

        private void pUjFel_MouseHover(object sender, EventArgs e)
        {
            labelUjFelh.ForeColor = Color.Silver;
        }

        private void pUjFel_MouseLeave(object sender, EventArgs e)
        {
            labelUjFelh.ForeColor = Color.White;
        }

        private void labelFMod_MouseHover(object sender, EventArgs e)
        {
            labelFMod.ForeColor = Color.Silver;
        }

        private void labelFMod_MouseLeave(object sender, EventArgs e)
        {
            labelFMod.ForeColor = Color.White;
        }

        private void pFelMod_MouseHover(object sender, EventArgs e)
        {
            labelFMod.ForeColor = Color.Silver;
        }

        private void pFelMod_MouseLeave(object sender, EventArgs e)
        {
            labelFMod.ForeColor = Color.White;
        }

        private void labelKijel_MouseHover(object sender, EventArgs e)
        {
            labelKijel.ForeColor = Color.Silver;
        }

        private void labelKijel_MouseLeave(object sender, EventArgs e)
        {
            labelKijel.ForeColor = Color.White;
        }

        private void pBoxKijel_MouseHover(object sender, EventArgs e)
        {
            labelKijel.ForeColor = Color.Silver;
        }

        private void pBoxKijel_MouseLeave(object sender, EventArgs e)
        {
            labelKijel.ForeColor = Color.White;
        }
    }
}
