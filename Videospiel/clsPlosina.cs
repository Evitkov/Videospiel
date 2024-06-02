using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videospiel
{
    internal class clsPlosina
    {
        //kreslící plátno
        Graphics mobjPlatno;
        //souřadnice kuličky
        int mintPlosinaX, mintPlosinaY;
        int mintPlosinaSirka, mintPlosinaVyska;
        Brush mobjBrush;
        public clsPlosina(int intPlosinaX, int intPlosinaY, int intPlosinaSirka, int intPlosinaVyska, Graphics objPlatno)
        {
            mintPlosinaX = intPlosinaX;
            mintPlosinaY = intPlosinaY;
            mintPlosinaSirka = intPlosinaSirka;
            mintPlosinaVyska = intPlosinaVyska;

            mobjBrush = Brushes.Blue;

            mobjPlatno = objPlatno;
         
        }
        public int mintSouradnicePlosiny
        {
            get
            {
                return mintPlosinaX;
            }
            set
            {
                mintPlosinaX = value;
            }
        }
        public Brush StetecPlosina
        {
            get
            {
                return mobjBrush;
            }
            set
            {
                mobjBrush = value;
            }
        }
        public Rectangle rectObrys
        {
            get
            {
                Rectangle lobjObrys;
                lobjObrys = new Rectangle(mintPlosinaX, mintPlosinaY, mintPlosinaSirka, mintPlosinaVyska);
                return lobjObrys;
            }

        }
        public void Vykreslise()
        {
            
            mobjPlatno.FillRectangle(mobjBrush, mintPlosinaX, mintPlosinaY, mintPlosinaSirka, mintPlosinaVyska);

        }
    }
}
