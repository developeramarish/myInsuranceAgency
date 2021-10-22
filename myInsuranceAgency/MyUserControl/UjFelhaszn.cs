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
    public partial class UjFelhaszn : UserControl
    {
        //adatbáziskapcsolat létrehozása objektumorientáltan
        Kapcsolat k = new Kapcsolat();
        String lekerdezes;

        public UjFelhaszn()
        {
            InitializeComponent();
            //ezzel akadályozom meg, hogy a felhasználó beleírjon a comboBoxba
            comboBoxAdmin.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //kiürítő eljárás (ezzel űrítem ki a kitöltött mezőket miután rögzítek egy új felhasználót)
        public void Kiurit()
        {
            textFNev.Clear();
            textJelszo.Clear();
            textJelszo2.Clear();
            //visszaállítom a comboBox kiválasztást
            comboBoxAdmin.SelectedIndex = -1;
        }

        //ha a rögzít gombra kattintok
        private void btnRogzit_Click(object sender, EventArgs e)
        {
            //ellenőrzöm, hogy ki vannak-e töltve a mezők
            if (textFNev.Text != "" && textJelszo.Text != "" && textJelszo2.Text != "" && comboBoxAdmin.Text != "")
            {
                //ellenőrzöm, hogy már van-e ilyen nevű felhasználó
                bool vane = k.NevEll(textFNev.Text);
                if (vane == false)
                {
                    //ellenőrzöm, hogy a két beírt jelszó egyezik-e
                    if (textJelszo.Text == textJelszo2.Text)
                    {
                        try
                        {
                            //ha állítunk be adminisztrátori jogosultságot
                            if (comboBoxAdmin.Text == "van")
                            {
                                lekerdezes = "insert into felhasznalok (fnev,jelszo,admin) values ('" + textFNev.Text + "','" + Titkosit.SHA5Hash(textJelszo.Text) + "', 1)";
                            }
                            //ha nem
                            else
                            {
                                lekerdezes = "insert into felhasznalok (fnev,jelszo,admin) values ('" + textFNev.Text + "','" + Titkosit.SHA5Hash(textJelszo.Text) + "', 0)";
                            }
                            k.setData(lekerdezes);
                            Kiurit();//Kiürítem a mezőket
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
                //ha már van ilyen nevű felhasználó
                else MessageBox.Show("Már van ilyen nevű felhasználó!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //ha nincs kitöltve minden mező
            else MessageBox.Show("Nem töltött ki minden mezőt!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
