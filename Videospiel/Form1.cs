using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Videospiel
{
    
    public partial class Form1 : Form
    {
        //bitmapa do které kreslím
        Bitmap mobjBitmapa;
        Graphics mobjGrafikaVram;
        //grafika na okně z pictureboxu
        Graphics mobjGrafika;

        //kulicka
        clsKulicka mobjKulicka;
        //souřadnice kuličky
        
        public Form1()
        {
            InitializeComponent();
        }

        //--------------------------------
        //nahrání formu do paměti
        //--------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            //vytvoření grafiky picteruboxu
            mobjGrafika = pbPlatno.CreateGraphics();

            //vytvoření bitmapy A grafiky
            mobjBitmapa = new Bitmap (pbPlatno.Width, pbPlatno.Height); 
            mobjGrafikaVram = Graphics.FromImage(mobjBitmapa);

            //vytvořit kuličku
            mobjKulicka = new clsKulicka(10, 10, 2, 10, mobjGrafikaVram);

            //nastavení timeru
            tmrRedraw.Interval = 10;
            tmrRedraw.Enabled = true;
        }
        //--------------------------------
        //překreslení obrazu
        //--------------------------------
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //vymazat
            mobjGrafikaVram.Clear(Color.White);
            //nakresli kolečko
            mobjKulicka.Vykreslise();

            //posun kuličky
            mobjKulicka.Posunse();

            //kolize
           
            //vykresli bitmapu na picturebox
            mobjGrafika.DrawImage(mobjBitmapa, 0, 0);
        }
    }
}
