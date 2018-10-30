using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    internal class Shop : Base
    {
        public Shop(string building, int x_at, int y_at, Color bkColor, double rating) : base(building, x_at, y_at, bkColor)
        {
        }

        private double rating;

        // override method to display shape as text
        public override string ToString()
        {
            return "Shop: " + this.buildingName + ", " + this.rating + ", " + this.Position();
        }

        // override method to display shape as graphics
        public override void Display(Graphics g)
        {
            if (g != null)
            {
                Brush br = new SolidBrush(bColor);
                g.FillRectangle(br, x, y, 10, 10);
            }
        }

        public override int x_pos //non abstract property
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public override int y_pos //non abstract property
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public override Color color //non abstract property
        {
            get
            {
                return bColor;
            }
            set
            {
                bColor = value;
            }
        }

        public override string name
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
    }
}