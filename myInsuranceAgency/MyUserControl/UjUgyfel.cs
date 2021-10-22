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
    public delegate string GI();//a szülő form eljárásának eléréséhez
    public partial class UjUgyfel : UserControl
    {
        public event GI CustomControlGI;//a szülő form eljárásának eléréséhez

        //adatbáziskapcsolat létrehozása objektumorientáltan
        Kapcsolat k = new Kapcsolat();
        String lekerdezes;

        //kiürítő eljárás (ezzel űrítem ki a kitöltött mezőket miután rögzítek egy új felhasználót)
        public void Kiurit()
        {
            textNev.Clear();
            maskedTel.Clear();
            textMail.Clear();
            textCim.Clear();
            richTextInfo.Clear();
            //törlöm a lisboxból a termékeket
            lBoxMeglTermekek.Items.Clear();
        }

        public UjUgyfel()
        {
            InitializeComponent();            
        }

        //ha beleírok a név mezőbe, kitölti az üzletkötő id-t a bejelentkezett alapján
        //azért ide tettem, mert a load-on hibára futott
        private void textNev_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textID.Text = CustomControlGI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //amikor betöltődik a form
        private void UjUgyfel_Load(object sender, EventArgs e)
        {
            //feltöltöm a termékek listáját, amiből hozzá tudom majd adni az ügyfél meglévő termékei közé a termékeket
            lekerdezes = "select termeknev from termekek";
            try
            {
                lBoxTermek.Items.Clear();//kiürítem az elemeket ha esetleg lenne bent valami
                DataSet ds = k.getData(lekerdezes);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lBoxTermek.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //ha a plusz jelre kattintok (termék hozzáadás)
        private void btnHozzaad_Click(object sender, EventArgs e)
        {
            //ha van kiválasztott termék
            if (lBoxTermek.GetItemText(lBoxTermek.SelectedItem) != "")
            {
                //leellenőrzöm, hogy a hozzáadni kívánt termék már szerepel-e a meglévő termékek között (duplikáció elkerülése)
                //alapértelmezett, hogy nincs egyezés
                bool vane = false;
                //először eltárolom a meglévő termékek listbox elemeit egy listában
                List<string> lista = new List<string>();
                for (int i = 0; i < this.lBoxMeglTermekek.Items.Count; i++)
                {
                    lista.Add(Convert.ToString(this.lBoxMeglTermekek.Items[i]));
                }
                //keresem az egyezést a mezőm szövege és a lista elemei között
                foreach (string item in lista)
                {
                    //ha van, akkor figyelmeztető üzenet + igazra vált a változóm értéke
                    if (lBoxTermek.GetItemText(lBoxTermek.SelectedItem) == item)
                    {
                        MessageBox.Show("Már van ilyen elem!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vane = true;
                    }
                }
                //ha nincs egyezés, hozzáadom a meglévő termékekhez az elemet
                if (vane == false)
                {
                    lBoxMeglTermekek.Items.Add(lBoxTermek.GetItemText(lBoxTermek.SelectedItem));
                }
            }
            //ha nincs kiválasztott termék
            else MessageBox.Show("Nincs kiválasztott termék!", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //ha a mínusz gombra kattintok (meglévő termék törlése)
        private void btnElvesz_Click(object sender, EventArgs e)
        {
            //törlöm a lisboxból a kiválasztott terméket
            lBoxMeglTermekek.Items.Remove(lBoxMeglTermekek.SelectedItem);
        }

        //rögzít gombra kattintás
        private void btnRogzit_Click(object sender, EventArgs e)
        {
            //elhelyezem a meglévő termék listbox elemeket egy stringben köztük vesszővel
            string mtermekek = string.Join(",", lBoxMeglTermekek.Items.OfType<object>());            
            if (textNev.Text != "" && maskedTel.Text != "" && textMail.Text != "" && textCim.Text != "" && richTextInfo.Text != "")
            {
                try
                {
                    lekerdezes = "insert into ugyfelek (nev,tel,email,cim,uzletkoto_id,meglevo_termekek,info) values ('" + textNev.Text + "','" + maskedTel.Text + "', '" + textMail.Text + "', '" + textCim.Text + "', '" + textID.Text + "','" + mtermekek + "', '" + richTextInfo.Text + "')";
                    k.setData(lekerdezes);
                    Kiurit();//Kiürítem a mezőket
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
