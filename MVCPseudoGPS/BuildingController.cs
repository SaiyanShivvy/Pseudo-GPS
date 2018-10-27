using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPseudoGPS
{
    internal class BuildingController
    {
        private ArrayList ViewList;

        // constructor
        public BuildingController()
        {
            ViewList = new ArrayList();
        }

        public void AddView(IView view)
        {
            ViewList.Add(view);
        }

        public void UpdateViews()
        {
            IView[] tViews = (IView[])ViewList.ToArray(typeof(IView));
            foreach (IView v in tViews)
            {
                v.RefreshView();
            }
        }
    }
}