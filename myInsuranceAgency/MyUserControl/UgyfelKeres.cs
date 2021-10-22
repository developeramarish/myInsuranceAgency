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
    public delegate string GIK();//a szülő form eljárásának eléréséhez
    public partial class UgyfelKeres : UserControl
    {
        public event GIK CustomControlGIK;//a szülő form eljárásának eléréséhez

        static string[] elemek;//ebben fogom majd beolvasni az adatbázisból a meglévő termékeket, mivel itt deklaráltam, nem kell méretet megadni

        public UgyfelKeres()
        {
            InitializeComponent();
        }

        //létrehozok egy lista típusú objektumpéldányt az UgyfelAdat osztályomból
        List<UgyfelAdat> adat = new List<UgyfelAdat>();
        string ugyfelAzon;//ebben fogom később tárolni a listboxban kiválasztott ügyfél id-jét
        string uzletkotoID;//ebben fogom tárolni a bejelentkezett üzletkötő id-jét

        //adatbáziskapcsolat létrehozása objektumorientáltan
        Kapcsolat k = new Kapcsolat();
        String lekerdezes;

        private void UgyfelKeres_Load(object sender, EventArgs e)
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

        //ha belekattintok a keresés mezőbe
        private void textKeres_Click(object sender, EventArgs e)
        {
            try
            {
                uzletkotoID = CustomControlGIK();//kitöltetem az üzletkötő ID mezőt
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textKeres.ResetText();//eltűnik a keresés felirat
        }
        //ha beleírok a kereső mezőbe
        private void textKeres_TextChanged(object sender, EventArgs e)
        {
            try
            {
                VisszaAllit();//ha újra kezdem a keresést kitörli a többi mezőt
                listBoxUgyfelek.Items.Clear();//kitörli a korábbi elemeket
                //ha nincs admin jogosultság (csak a bejelentkezett felhasználó ügyfelei)
                if (AdminJogEll() == "False")
                {
                    lekerdezes = "select ugyfelazon, nev from ugyfelek where uzletkoto_id ='" + uzletkotoID + "' and nev like '" + textKeres.Text + "%' order by nev";
                }  
                //ha van admin jogosultság (az összes üzletkötő ügyfele)
                else
                {
                    lekerdezes = "select ugyfelazon, nev from ugyfelek where nev like '" + textKeres.Text + "%' order by nev";
                }                
                UgyfelLista(lekerdezes);//meghívom az eljárást és átadom neki a lekérdezést paraméterként
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //ha ezt a függvényt meghívom, akkor visszaadja stringben, hogy van-e admin jogosultsága a bejelentkezett felhasználónak
        private string AdminJogEll()
        {
            lekerdezes = "select admin from felhasznalok where id ='" + uzletkotoID + "'";
            DataSet ds = k.getData(lekerdezes);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        private void UgyfelLista(string lekerdezes)
        {
            try
            {
                adat.Clear();
                listBoxUgyfelek.Items.Clear();//kitörlöm a nem egyező találatokat
                DataSet ds = k.getData(lekerdezes);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //fent hoztam létre a listát
                    //hozzáadom az id-t mint értéket, és a nevet amit majd meg fogok jeleníteni
                    adat.Add(new UgyfelAdat() { Id = ds.Tables[0].Rows[i][0].ToString(), Nev = ds.Tables[0].Rows[i][1].ToString() });                    
                }
                listBoxUgyfelek.DisplayMember = "Nev";//a név fog megjelenni
                foreach (UgyfelAdat item in adat)
                {
                    listBoxUgyfelek.Items.Add(item);//csak a név fog megjelenni mert az a DisplayMember, de viszi magával a másik adattagot is
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //ha kiválasztok egy ügyfelet a listbox-ból (mezők kitöltése)       
        private void listBoxUgyfelek_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textNev.Text = listBoxUgyfelek.GetItemText(listBoxUgyfelek.SelectedItem);//ügyfél nevének megszerzése és beleírása a név mezőbe
                ugyfelAzon = (listBoxUgyfelek.SelectedItem as UgyfelAdat).Id;//a kiválasztott névhez tartozó id (fent deklaráltam a változót)
                lekerdezes = "select tel, email, cim, uzletkoto_id, meglevo_termekek, info from ugyfelek where ugyfelazon ='" + ugyfelAzon + "'";
                DataSet ds = k.getData(lekerdezes);
                //ha van találat a lekérdezésre:
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //kitöltöm az adott ügyfél id-hez tartozó mezőket
                    maskedTel.Text = ds.Tables[0].Rows[0][0].ToString();
                    textMail.Text = ds.Tables[0].Rows[0][1].ToString();
                    textCim.Text = ds.Tables[0].Rows[0][2].ToString();
                    //az üzletkötő id-t is az adatbázisból töltöm ki, mert ha adminként vagyok bejelentkezve, akkor látom a többi üzletkötő ügyfelét is
                    textID.Text = ds.Tables[0].Rows[0][3].ToString();
                    //kitörlöm a listbox tartalmát, mert előtte már kattinthattam másik névre is
                    lBoxMeglTermekek.Items.Clear();
                    //ha van meglévő termék (hogy ne rakjon be üres sort a listbox-ba)
                    if (ds.Tables[0].Rows[0][4].ToString() != "")
                    {
                        //az elemek tömböt fent deklaráltuk, hogy ne kelljen előre megadni a méretet
                        //a beolvasott meglévő termékeket a vesszőknél feldaraboltuk
                        elemek = ds.Tables[0].Rows[0][4].ToString().Split(',');                        
                        //az elemek tömb tartalmát egyesével belehelyezem a listboxba
                        foreach (string item in elemek)
                        {
                            lBoxMeglTermekek.Items.Add(item);
                        }
                    }                    
                    richTextInfo.Text = ds.Tables[0].Rows[0][5].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }       

        //visszaállítom a user control keresés mezőjét kezdő állapotba
        public void KeresVisszaAllit()
        {
            textKeres.Text = "Keresés...";
        }

        //visszaállítom a user control mezőit kezdő állapotba
        public void VisszaAllit()
        {
            textNev.ResetText();
            maskedTel.ResetText();
            textMail.ResetText();
            textCim.ResetText();
            textID.ResetText();
            lBoxMeglTermekek.Items.Clear();
            richTextInfo.ResetText();
        }

        //ha a plusz jelre kattintok
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

        //ha a mínusz jelre kattintok
        private void btnElvesz_Click(object sender, EventArgs e)
        {
            //törlöm a lisboxból a kiválasztott terméket
            lBoxMeglTermekek.Items.Remove(lBoxMeglTermekek.SelectedItem);
        }

        //ha a törlés gombra kattintok
        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan törölni szeretné az ügyfelet?", "Figyelmeztetés", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    lekerdezes = "delete from ugyfelek where ugyfelazon ='" + ugyfelAzon + "'";
                    k.setData(lekerdezes);
                    KeresVisszaAllit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt!  " + ex.Message, "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //ha a módosítás gombra kattintok
        private void btnModosit_Click(object sender, EventArgs e)
        {
            //elhelyezem a meglévő termék listbox elemeket egy stringbe köztük vesszővel
            string mtermekek = string.Join(",", lBoxMeglTermekek.Items.OfType<object>());
            lekerdezes = "UPDATE `ugyfelek` SET `nev` = '" + textNev.Text + "',  `tel` = '" + maskedTel.Text + "',  `email` = '" + textMail.Text + "',  `cim` = '" + textCim.Text + "',  `meglevo_termekek` = '" + mtermekek + "', `info` = '" + richTextInfo.Text + "' WHERE `ugyfelazon` = '" + ugyfelAzon + "';";
            k.setData(lekerdezes);
            KeresVisszaAllit();
        }
    }
}
