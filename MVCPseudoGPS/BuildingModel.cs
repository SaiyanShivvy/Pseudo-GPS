using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    public class BuildingModel
    {
        private ArrayList buildings;
        private BuildingController tController;

        public BuildingModel(BuildingController aController)
        {
            buildings = new ArrayList();
            tController = aController;
        }

        public ArrayList BuildingList
        {
            get
            {
                return buildings;
            }
        }

        public void AddBuilding()
    }
}