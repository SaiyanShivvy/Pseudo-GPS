using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    public class BuildingsController
    {
        private ArrayList ViewList;

        // constructor
        public BuildingsController()
        {
            ViewList = new ArrayList();
        }

        /// <summary>
        /// addes a view to the ViewList array
        /// </summary>
        /// <param name="aView"></param>
        public void AddView(IBuildingView aView)
        {
            ViewList.Add(aView);
        }

        /// <summary>
        /// updates all views that exist in theViews array
        /// </summary>
        public void UpdateViews()
        {
            IBuildingView[] theViews = (IBuildingView[])ViewList.ToArray(typeof(IBuildingView));
            foreach (IBuildingView v in theViews)
            {
                v.RefreshView();
            }
        }
    }
}