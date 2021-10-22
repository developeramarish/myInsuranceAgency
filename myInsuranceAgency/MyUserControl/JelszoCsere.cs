using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myInsuranceAgency.MyUserControl
{
    public delegate string GIJ();//a szülő form eljárásának eléréséhez
    public partial class JelszoCsere : UserControl
    {
        public event GIJ CustomControlGIJ;//a szülő form eljárásának eléréséhez

        //adatbáziskapcsolat létrehozása objektumorientáltan
        Kapcsolat k = new Kapcsolat();
        String lekerdezes;

        public JelszoCsere()
        {
            InitializeComponent();
        }

        //kiürítő eljárás (ezzel űrítem ki a kitöltött mezőket miután rögzítek egy új felhasználót)
        public void Kiurit()
        {
            textJelJelszo.Clear();
            textUjJelszo.Clear();
            textUjJelszo2.Clear();            
        }

        //jelenlegi jelszó mezőbe írás esemény - kitölti az üzletkötő id-t
        private void textJelJelszo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textID.Text = CustomControlGIJ();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        //módosít gombra kattintás
        private void btnModos_Click(object sender, EventArgs e)
        {
            if (textJelJelszo.Text != "" && textUjJelszo.Text != "" && textUjJelszo2.Text != "")
            {
                //elenőrzöm, hogy a megadott régi jelszó, a bejelentkezett id-hez tartozik-e
                try
                {
                    lekerdezes = "select * from felhasznalok where id = '" + textID.Text + "' and jelszo = '" + Titkosit.SHA5Hash(textJelJelszo.Text) + "'";
                    DataSet ds = k.getData(lekerdezes);
                    //ha van találat a lekérdezésre (helyes a jelenlegi jelszó):
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //ellenőrzöm, hogy a beírt két új jelszó egyezik-e
                        //ha egyezik
                        if (textUjJelszo.Text == textUjJelszo2.Text)
                        {
                            lekerdezes = "UPDATE `felhasznalok` SET `jelszo` = '" + Titkosit.SHA5Hash(textUjJelszo.Text) + "' WHERE `id` = '" + textID.Text + "';";
                            k.setData(lekerdezes);
                            Kiurit();//mezők kiűrítése
                        }
                        //ha nem egyezik meg a két jelszó
                        else MessageBox.Show("A beírt két új jelszó nem egyezik meg!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Hibás jelenlegi jelszó!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
            else MessageBox.Show("Nem töltött ki minden mezőt!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }       
    }
}
