using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    public class TrainStation : BuildingBase
    {
        public TrainStation(string name, int x, int y) : base(name, x, y)
        {
        }

        public override int X_pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Y_pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Display(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}