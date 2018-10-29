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
    public partial class ViewForm1 : Form, IView
    {
        private BuildingModel bM;
        private bool dragging;
        private BuildingBase selBuilding;
        private BuildingBase editBuilding;

        // var's for max values
        private int max_X = 425;

        private int max_Y = 325;

        //
        private Point lastPosition = new Point(0, 0);

        private Point currentPosition = new Point(0, 0);

        internal BuildingModel BModel
        {
            set
            {
                bM = value;
            }
        }

        public ViewForm1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BuildingBase abuilding;

                int X = Convert.ToInt32(txtX.Text);
                int Y = Convert.ToInt32(txtY.Text);

                abuilding = new Shop("Test", X, Y);
                bM.AddBuilding(abuilding);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "\r\n" + ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshView()
        {
            lstBuildings.Items.Clear();
            ArrayList theBuildingList = bM.BuildingList;
            BuildingBase[] theBuildings = (BuildingBase[])theBuildingList.ToArray(typeof(BuildingBase));
            foreach (BuildingBase b in theBuildings)
            {
                lstBuildings.Items.Add(b);
            }
        }
    }
}