using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCPseudoGPS
{
    public partial class ViewForm2 : Form, IBuildingView
    {
        private BuildingsModel myModel;

        private bool dragging;
        private Base topBuilding; //  variable for selected building
        private Base editBuilding; // variable for building to edit

        // set method for myModel
        public BuildingsModel MyModel
        {
            set
            {
                myModel = value;
            }
        }

        public ViewForm2()
        {
            InitializeComponent();
        }

        /// <summary>method: clearPanel
        /// clear all shapes from display on panel
        /// </summary>
        private void clearPanel()
        {
            pnlDraw.CreateGraphics().Clear(pnlDraw.BackColor);
        }

        /// <summary>method: reDisplay
        /// redraws all the shapes in the model
        /// </summary>
        public void reDisplay()
        {
            ArrayList theBuildingList = myModel.BuildingList;
            Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
            Graphics g = this.pnlDraw.CreateGraphics();
            foreach (Base b in theBuildings)
            {
                b.Display(g);
            }
        }

        public void RefreshView()
        {
            // clear panel
            clearPanel();
            // create arrayList from model and convert to array of shapes
            ArrayList theBuildingList = myModel.BuildingList;
            Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
            Graphics g = this.pnlDraw.CreateGraphics();
            // draw all shapes in array
            foreach (Base b in theBuildings)
            {
                b.Display(g);
            }
        }
    }
}