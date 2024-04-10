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

        //souřadnice kuličky
        int mintKulickaX, mintKulickaY;

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
            //nastavení kuličkyy
            mintKulickaX = mintKulickaY = 10;
            //nastavení timeru
            tmrRedraw.Interval = 500;
            tmrRedraw.Enabled = true;
        }
        //--------------------------------
        //překreslení obrazu
        //--------------------------------
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {

            //nakresli kolečko
            mobjGrafikaVram.FillEllipse(Brushes.Red, mintKulickaX, mintKulickaY, 10, 10);
            
            //posun kuličky
            mintKulickaX = mintKulickaX + 5;
            mintKulickaY = mintKulickaY + 5;
            //vykresli bitmapu na picturebox
            mobjGrafika.DrawImage(mobjBitmapa, 0, 0);
        }
    }
}
