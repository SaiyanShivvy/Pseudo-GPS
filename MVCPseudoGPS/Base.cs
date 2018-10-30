using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    public abstract class Base
    {
        protected string buildingName;
        protected int x;
        protected int y;
        protected Color bColor;

        // constructor
        public Base(string building, int x_at, int y_at, Color bkColor)
        {
            buildingName = building;
            x = x_at;
            y = y_at;
            bColor = bkColor;
        }

        public abstract void Display(Graphics g);

        public string Position()  //non abstract method
        {
            return "(" + x.ToString() + "," + y.ToString() + ")";
        }

        public abstract int x_pos //abstract property
        {
            get;
            set;
        }

        public abstract int y_pos //abstract property
        {
            get;
            set;
        }

        public abstract Color color //abstract property
        {
            get;
            set;
        }

        public abstract string name //abstract property
        {
            get;
            set;
        }
    }
}