﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    internal class Mall : Base
    {
        /// <summary>
        /// defines unique behavouir
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x_at"></param>
        /// <param name="y_at"></param>
        /// <param name="type"></param>
        /// <param name="bkColor"></param>
        /// <param name="capacity"></param>
        public Mall(string name, int x_at, int y_at, string type, Color bkColor, int capacity) : base(name, x_at, y_at, type, bkColor)
        {
            Capacity = capacity;
        }

        // override method to display shape as text
        public override string ToString()
        {
            return this.bType + ", " + this.buildingName + ", " + this.Capacity + ", " + this.Position();
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

        public override int X_pos //non abstract property
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

        public override int Y_pos //non abstract property
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

        public override Color Color //non abstract property
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

        public override string Name //non abstact property
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

        public override string Type // non abstract property
        {
            get
            {
                return bType;
            }
            set
            {
                bType = value;
            }
        }
    }
}