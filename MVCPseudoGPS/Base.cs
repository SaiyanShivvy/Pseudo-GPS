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
        protected string bType;

        // constructor
        public Base(string name, int x_at, int y_at, string type, Color bkColor)
        {
            buildingName = name;
            x = x_at;
            y = y_at;
            bColor = bkColor;
            bType = type;
        }

        public abstract void Display(Graphics g);

        public string Position()  //non abstract method
        {
            return "(" + x.ToString() + "," + y.ToString() + ")";
        }

        public abstract int X_pos //abstract property
        {
            get;
            set;
        }

        public abstract int Y_pos //abstract property
        {
            get;
            set;
        }

        public abstract Color Color //abstract property
        {
            get;
            set;
        }

        public abstract string Name //abstract property
        {
            get;
            set;
        }

        public abstract string Type //abstract property
        {
            get;
            set;
        }
    }
}