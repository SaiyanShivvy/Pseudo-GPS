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

        public void AddView(IBuildingView aView)
        {
            ViewList.Add(aView);
        }

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