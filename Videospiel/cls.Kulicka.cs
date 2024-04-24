﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        //
        //konstruktor
        //
        public clsKulicka (int intKulickaX,int intKulickaY, int intPosun, int intPolomer, Graphics objPlatno)
        {
            mintKulickaX = intKulickaX;
            mintKulickaY =  intKulickaY;
            mintPosunX = mintPosunY = intPosun;
            mintPolomer = intPolomer;
            mobjPlatno = objPlatno;
        }
        //
        //vykreslení
        //
        public void Vykreslise()
        {
            mobjPlatno.FillEllipse(Brushes.Red, mintKulickaX, mintKulickaY, mintPolomer, mintPolomer);
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
    }
}