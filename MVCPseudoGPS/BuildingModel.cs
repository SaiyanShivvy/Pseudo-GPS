using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    internal class BuildingModel
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

        public void AddBuilding(BuildingBase aBuilding)
        {
            buildings.Add(aBuilding);
            UpdateViews();
        }

        public void UpdateBuilding(BuildingBase aBuilding)
        {
            UpdateViews();
        }

        public void DeleteBuilding(BuildingBase aBuilding)
        {
            buildings.Remove(aBuilding);
            UpdateViews();
        }

        public void UpdateViews()
        {
            tController.UpdateViews();
        }
    }
}