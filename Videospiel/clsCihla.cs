﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videospiel
{
    internal class clsCihla
    {
        Graphics mobjPlatno;
        //souřadnice kuličky
        int mintCihlaX, mintCihlaY;
        int mintCihlaSirka, mintCihlaVyska;
        Brush mobjBrush;
        //zda je vidět
        bool mblIsVisible;

        //--------------------------------
        //konstruktor
        //--------------------------------
        public clsCihla(int intCihlaX, int intCihlaY, int intCihlaSirka, int intCihlaVyska, Graphics objPlatno)
        {
            mintCihlaX = intCihlaX;
            mintCihlaY = intCihlaY;
            mintCihlaSirka = intCihlaSirka;
            mintCihlaVyska = intCihlaVyska;

            mobjBrush = Brushes.Red;

            mobjPlatno = objPlatno;
            mblIsVisible = true;
        }
        //--------------------------------
        //zviditelnění proměnné StetecCihly
        //--------------------------------
        public Brush StetecCihly
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
        //-------------------------------
        //Vracím obrysový objekt
        //-------------------------------
        public Rectangle rectObrys
        {
            get
            {
                Rectangle lobjObrys;
                lobjObrys = new Rectangle(mintCihlaX, mintCihlaY, mintCihlaSirka, mintCihlaVyska);
                if(mblIsVisible==false)
                {
                    lobjObrys = new Rectangle(0,0,0,0);
                }
                return lobjObrys;
            }

        }
        //----------------------------------
        //nastavení viditelnosti cihly
        //---------------------------------
        public bool blVisible
        {
            
            set
            {
                mblIsVisible = value;
            }
            get
            {
                return mblIsVisible;
            }
        }
        //-------------------------------
        //vykreslení
        //--------------------------
        public void Vykreslise()
        {
            if (mblIsVisible == false) return;
             mobjPlatno.FillRectangle(mobjBrush, mintCihlaX, mintCihlaY, mintCihlaSirka, mintCihlaVyska); 
     
        }
        
    }
}
