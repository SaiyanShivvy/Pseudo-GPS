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

        public override int X_pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Y_pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Display(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}