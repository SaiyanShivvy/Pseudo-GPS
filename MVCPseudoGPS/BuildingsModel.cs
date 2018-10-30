using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MVCPseudoGPS
{
    public class BuildingsModel
    {
        private ArrayList buildingList;
        private BuildingsController theController;

        public BuildingsModel(BuildingsController aController)
        {
            buildingList = new ArrayList();
            theController = aController;
        }

        public ArrayList BuildingList
        {
            get
            {
                return buildingList;
            }
        }

        public void AddBuilding(Base aBuilding)
        {
            buildingList.Add(aBuilding);
            UpdateViews();
        }

        public void UpdateBuilding(Base aBuilding)
        {
            UpdateViews();
        }

        public void DeleteBuilding(Base aBuilding)
        {
            buildingList.Remove(aBuilding);
            UpdateViews();
        }

        /// <summary>method: UpdateViews
        /// refresh all views
        /// </summary>
        public void UpdateViews()
        {
            theController.UpdateViews();
        }
    }
}