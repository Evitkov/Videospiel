using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Videospiel
{
    internal class clsKulicka
    {
        //kreslící plátno
        Graphics mobjPlatno;
        //souřadnice kuličky
        int mintKulickaX, mintKulickaY;
        int mintPosunX, mintPosunY;
        int mintPolomer;
        int mintpbPlatnoHeight;
        Brush mobjBrush;
        bool blKonecVideohry;



        //
        //konstruktor
        //
        public clsKulicka (int intKulickaX,int intKulickaY, int intPosun, int intPolomer, Graphics objPlatno)
        {
            mintKulickaX = intKulickaX;
            mintKulickaY =  intKulickaY;
            mintPosunX = mintPosunY = intPosun;
            mintPolomer = intPolomer;

            mobjBrush = Brushes.Red;
            mobjPlatno = objPlatno;
            mintpbPlatnoHeight = 742;
            blKonecVideohry = false;

        }
        public Brush StetecKulicky
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
                lobjObrys = new Rectangle(mintKulickaX, mintKulickaY, mintPolomer, mintPolomer);
                return lobjObrys;
            }

        }
        public bool blKonec
        {
            get
            {
                return blKonecVideohry;
            }
            set
            {
                blKonecVideohry = value;
            }
        }
        //
        //vykreslení
        //
        public void Vykreslise()
        {
            mobjPlatno.FillEllipse(mobjBrush, mintKulickaX, mintKulickaY, mintPolomer, mintPolomer);
        }
        //
        //posun se a kolize
        //
        public void Posunse ()
        {
            mintKulickaX = mintKulickaX + mintPosunX;
            mintKulickaY = mintKulickaY + mintPosunY;

            if ((mintKulickaY + mintPolomer) == mobjPlatno.VisibleClipBounds.Height)
            {

                MessageBox.Show("Game Over");
                mintKulickaX = 200;
                mintKulickaY = 200;
                mobjPlatno.Clear(Color.White);
                System.Windows.Forms.Application.Restart();
            }
            if ((mintKulickaX + mintPolomer) > mobjPlatno.VisibleClipBounds.Width)
                mintPosunX = mintPosunX * (-1);
            if (mintKulickaY < 0)
                mintPosunY = mintPosunY * (-1);
            if (mintKulickaX < 0)
                mintPosunX = mintPosunX * (-1);


        }
        public void Konechry()
        {
            if ((mintKulickaY + mintPolomer) == mobjPlatno.VisibleClipBounds.Height)
            {

                MessageBox.Show("Game Over");
                mintKulickaX = 200;
                mintKulickaY = 200;
                
                mobjPlatno.Clear(Color.White);
                blKonecVideohry = true;
            }
         }
        public void ZmenPohybY()
        {
            mintPosunY = mintPosunY * (-1);
        }
        public int mintVyskaKulicky
        {
            get
            {
                return mintKulickaY;
            }
            set
            {
                mintKulickaY = value;
            }
        }
    }
}
