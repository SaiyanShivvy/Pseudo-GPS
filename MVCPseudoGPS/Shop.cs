using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    [Serializable]
    public class Shop : BuildingBase
    {
        public Shop(string name, int x, int y) : base(name, x, y)
        {
        }

        // override method to display shape as text
        public override string ToString()
        {
            return this.buildingName + ": " + this.Position();
        }

        // override method to display shape as graphics
        public override void Display(Graphics g)
        {
        }

        public override int X_pos //non abstract property
        {
            get
            {
                return xpos;
            }
            set
            {
                xpos = value;
            }
        }

        public override int Y_pos //non abstract property
        {
            get
            {
                return ypos;
            }
            set
            {
                ypos = value;
            }
        }

        public override string Name
        {
            get
            {
                return buildingName;
            }
            set
            {
                buildingName = value;
            }
        }

        //public override bool HitTest(Point p)
        //{
        //    //
        //}
    }
}