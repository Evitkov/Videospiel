using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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

            if ((mintKulickaY + mintPolomer) > mobjPlatno.VisibleClipBounds.Height)
                mintPosunY = mintPosunY * (-1);
            if ((mintKulickaX + mintPolomer) > mobjPlatno.VisibleClipBounds.Width)
                mintPosunX = mintPosunX * (-1);
            if (mintKulickaY < 0)
                mintPosunY = mintPosunY * (-1);
            if (mintKulickaX < 0)
                mintPosunX = mintPosunX * (-1);


        }
        public void ZmenPohybY()
        {
            mintPosunY = mintPosunY * (-1);
        }
        public void KonecHry()
        {
            if (mintKulickaY == mintpbPlatnoHeight - 10)
            {
                
                Form2 form2 = new Form2();
                
                form2.Show();
            }
        }
    }
}
