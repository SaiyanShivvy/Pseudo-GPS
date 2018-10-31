using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MVCPseudoGPS
{
    /// <summary>
    /// BuildingModel class
    /// </summary>
    public class BuildingsModel
    {
        private ArrayList buildingList;
        private BuildingsController theController;

        // constuctor
        public BuildingsModel(BuildingsController aController)
        {
            buildingList = new ArrayList();
            theController = aController;
        }

        // set up the arraylist
        public ArrayList BuildingList
        {
            get
            {
                return buildingList;
            }
        }

        /// <summary>
        /// method to add a building to the arraylist and update views
        /// </summary>
        /// <param name="aBuilding"></param>
        public void AddBuilding(Base aBuilding)
        {
            buildingList.Add(aBuilding);
            UpdateViews();
        }

        /// <summary>
        /// method to update a building and update views.
        /// </summary>
        /// <param name="aBuilding"></param>
        public void UpdateBuilding(Base aBuilding)
        {
            UpdateViews();
        }

        /// <summary>
        /// method to delete buildings and update views
        /// </summary>
        /// <param name="aBuilding"></param>
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