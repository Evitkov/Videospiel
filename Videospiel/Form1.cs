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
        clsPlosina mobjPlosina;
        //integery které budu používat
        const int PocetCihel = 65;
        const int mintPrvniCihlyX = 10, mintPrvniCihlyY = 10,mintCihlaMezera = 5;
        const int mintSirkaCihly = 50, mintVyskaCihly = 15;
        const int mintSirkaPlosiny = 120;
        const int mintPosunPlosiny = 10;
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
            mobjKulicka = new clsKulicka(200, 200, 2, 10, mobjGrafikaVram);
            mobjKulicka.StetecKulicky = Brushes.Red;
            mobjPlosina = new clsPlosina(350, 380, mintSirkaPlosiny, 10, mobjGrafikaVram);
            mobjPlosina.StetecPlosina = Brushes.Blue;
            mobjPlosina.mintSouradnicePlosiny = 350;
            int mintVyskaKulicky = mobjKulicka.mintVyskaKulicky;
            
            //vytvoření pole cihel
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
            tmrRedraw.Interval = 1;
            tmrRedraw.Enabled = true;
        }
        //-------------------------------------------
        //ovládání plošiny a její omezení na platno
        //-------------------------------------------
        public void PosunPlosiny(object sender, KeyEventArgs e)
        {
            bool lblPlosinaNaObrazovce = true;
            //je plošina celá na plátně
            if (mobjPlosina.mintSouradnicePlosiny<0 || mobjPlosina.mintSouradnicePlosiny + mintSirkaPlosiny > pbPlatno.Width) 
            {
                lblPlosinaNaObrazovce = false;
            }
            //plošina je celá na plátně
                if (lblPlosinaNaObrazovce==true)
                {
                    switch (e.KeyCode)
                    {
                      case Keys.A:
                         mobjPlosina.mintSouradnicePlosiny = mobjPlosina.mintSouradnicePlosiny - mintPosunPlosiny;
                      break;
                      case Keys.D:
                         mobjPlosina.mintSouradnicePlosiny = mobjPlosina.mintSouradnicePlosiny + mintPosunPlosiny;
                      break;
                     }
                }
                //plošina narazila na levý bok
            if (mobjPlosina.mintSouradnicePlosiny < 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        mobjPlosina.mintSouradnicePlosiny = mobjPlosina.mintSouradnicePlosiny;
                        break;
                    case Keys.D:
                        mobjPlosina.mintSouradnicePlosiny = mobjPlosina.mintSouradnicePlosiny + mintPosunPlosiny;
                        break;
                }
            }
            //plošina narazila na pravý bok
            if (mobjPlosina.mintSouradnicePlosiny + mintSirkaPlosiny > pbPlatno.Width)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        mobjPlosina.mintSouradnicePlosiny = mobjPlosina.mintSouradnicePlosiny - mintPosunPlosiny;
                        break;
                    case Keys.D:
                        mobjPlosina.mintSouradnicePlosiny = mobjPlosina.mintSouradnicePlosiny;
                        break;
                }
            }
        }
        //--------------------------------
        //Proměnná - jsou cihly vidět
        //--------------------------------
        public bool blVisible
        {
            get
            {
                return blVisible;
            }
            set
            {
                blVisible = value;
            }
        }
        

        //--------------------------------
        //překreslení obrazu
        //--------------------------------
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            bool lblAnyIsVisible = false;
            //vymazat
            mobjGrafikaVram.Clear(Color.White);
            //nakresli kolečko
            mobjKulicka.Vykreslise();
            mobjPlosina.Vykreslise();

            for (int i = 0; i < PocetCihel; i++)
            {
                //test kolize s kuličkou
                if (true ==TestKolizeCihlaKulicka(mobjKulicka.rectObrys, mobjCihly[i].rectObrys))
                {
                    mobjCihly[i].blVisible = false;

                    //zmena pohybu kulicky
                    mobjKulicka.ZmenPohybY();
                }
                if (true == TestKolizeCihlaKulicka(mobjKulicka.rectObrys, mobjPlosina.rectObrys))
                {

                    //zmena pohybu kulicky
                    mobjKulicka.ZmenPohybY();
                }

                //vykreslení cihly
                mobjCihly[i].Vykreslise();
                
                if (mobjCihly[i].blVisible == true)
                {
                    lblAnyIsVisible = true;
                }
            }
            if (lblAnyIsVisible == false)
            {
                tmrRedraw.Enabled = false;
                //ukončení hry
                MessageBox.Show("Vyhrál jsi");
                //restartování programu
                System.Windows.Forms.Application.Restart();
            }

            //posun kuličky
            mobjKulicka.Posunse();

            //vykresli bitmapu na picturebox
            mobjGrafika.DrawImage(mobjBitmapa, 0, 0);

            
        }
        //--------------------------------
        //Test na Kolize Cihly a Kulicky
        //--------------------------------
        private bool TestKolizeCihlaKulicka(Rectangle objRectKulicka, Rectangle objRectCihla)
                    {
            Rectangle lobjPrekryv;
            lobjPrekryv = Rectangle.Intersect(objRectKulicka,objRectCihla);
            //test zda existuje překryvný obdelník
            if(lobjPrekryv.Width == 0 && lobjPrekryv.Height ==0 )
            return false;
            return true;
        }
        //--------------------------------
        //Test na Kolize Plosiny a Kulicky
        //--------------------------------
        private bool TestKolizePlosinaKulicka(Rectangle objRectKulicka, Rectangle objRectPlosina)
        {
            Rectangle lobjPrekryv;
            lobjPrekryv = Rectangle.Intersect(objRectKulicka, objRectPlosina);
            //test zda existuje překryvný obdelník
            if (lobjPrekryv.Width == 0 && lobjPrekryv.Height == 0)
                return false;
            return true;
        }
    }
}
