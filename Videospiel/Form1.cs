using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        clsCihla [] mobjCihly;

        const int PocetCihel = 65;
        const int mintPrvniCihlyX = 10, mintPrvniCihlyY = 10,mintCihlaMezera = 5;
        const int mintSirkaCihly = 50, mintVyskaCihly = 15;
        public Form1()
        {
            InitializeComponent();
        }

        //--------------------------------
        //nahrání formu do paměti
        //--------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            int lintCihlaX, lintCihlaY;
            //vytvoření grafiky picteruboxu
            mobjGrafika = pbPlatno.CreateGraphics();

            //vytvoření bitmapy A grafiky
            mobjBitmapa = new Bitmap (pbPlatno.Width, pbPlatno.Height); 
            mobjGrafikaVram = Graphics.FromImage(mobjBitmapa);

            //vytvořit kuličku
            mobjKulicka = new clsKulicka(10, 10, 2, 10, mobjGrafikaVram);
            mobjKulicka.StetecKulicky = Brushes.Red;
            //vytvořit cihly
            
            mobjCihly = new clsCihla[PocetCihel];
            lintCihlaX = mintPrvniCihlyX;
            lintCihlaY = mintPrvniCihlyY;
            for (int i = 0; i < PocetCihel; i++)
            {
                mobjCihly[i] = new clsCihla(lintCihlaX, lintCihlaY, mintSirkaCihly, mintVyskaCihly, mobjGrafikaVram);
                //posun v x
                lintCihlaX = lintCihlaX + mintSirkaCihly + mintCihlaMezera;
                //test na další řadu
                if (lintCihlaX + mintSirkaCihly + mintCihlaMezera > pbPlatno.Width)
                {
                    lintCihlaX = mintPrvniCihlyX;
                    lintCihlaY = lintCihlaY + mintVyskaCihly + mintCihlaMezera;
                }
            }
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

            for (int i = 0; i < PocetCihel; i++)
            {
                mobjCihly[i].Vykreslise();
            }
            //kolize

            //vykresli bitmapu na picturebox
            mobjGrafika.DrawImage(mobjBitmapa, 0, 0);
        }
    }
}
