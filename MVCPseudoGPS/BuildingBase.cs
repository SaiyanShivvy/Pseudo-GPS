using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    public abstract class BuildingBase
    {
        protected string buildingName;
        protected int xpos;
        protected int ypos;

        private bool highlight;

        public BuildingBase(string name, int x, int y)
        {
            buildingName = name;
            xpos = x;
            ypos = y;
        }

        public abstract void Display(Graphics g);

        public bool Highlight
        {
            get
            {
                return highlight;
            }
            set
            {
                highlight = value;
            }
        }

        public string Position()  //non abstract method
        {
            return "(" + xpos.ToString() + "," + ypos.ToString() + ")";
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

        public abstract string Name //abstract property
        {
            get;
            set;
        }

        // virtual method
        public virtual bool HitTest(Point p)
        {
            Point pt = new Point(xpos, ypos);
            Size size = new Size(100, 100);
            //default behaviour
            return new Rectangle(pt, size).Contains(p);
        }
    }
}