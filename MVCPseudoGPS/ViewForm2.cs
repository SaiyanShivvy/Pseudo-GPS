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
        private Base selectBuilding;
        private Base editBuilding;
        private bool dragging;

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
            edit();
        }

        private void edit()
        {
            //if (selectBuilding != null)
            //{
            //    MessageBox.Show("Building is Selected", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    editBuilding = selectBuilding;

            //    txtName.Text = selectBuilding.Name;
            //    txtX.Text = selectBuilding.X_pos.ToString();
            //    txtY.Text = selectBuilding.Y_pos.ToString();
            //    switch (selectBuilding.Type)
            //    {
            //        case "Shop":
            //            rbShop.Checked = true;
            //            rbMall.Checked = false;
            //            rbTrainStation.Checked = false;
            //            Shop sp = (MVCPseudoGPS.Shop)selectBuilding;
            //            txtValue.Text = sp.Rating.ToString();
            //            break;

            //        case "Mall":
            //            rbShop.Checked = false;
            //            rbMall.Checked = true;
            //            rbTrainStation.Checked = false;
            //            Mall ml = (MVCPseudoGPS.Mall)selectBuilding;
            //            txtValue.Text = ml.Capacity.ToString();
            //            break;

            //        case "Train Station":
            //            rbShop.Checked = false;
            //            rbMall.Checked = false;
            //            rbTrainStation.Checked = true;
            //            TrainStation ts = (MVCPseudoGPS.TrainStation)selectBuilding;
            //            txtValue.Text = ts.Line;
            //            break;
            //    }
            //}
            //myModel.UpdateViews();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int nX, nY;
            string nName;

            Base selectedBuilding = (MVCPseudoGPS.Base)editBuilding;
            if (selectedBuilding.Type == "Shop")
            {
                double nRating = Convert.ToDouble(txtValue.Text);
                Shop sB = (MVCPseudoGPS.Shop)editBuilding;
                sB.Rating = nRating;
            }
            else if (selectedBuilding.Type == "Mall")
            {
                int nCapacity = Convert.ToInt32(txtValue.Text);
                Mall sB = (MVCPseudoGPS.Mall)editBuilding;
                sB.Capacity = nCapacity;
            }
            else if (selectedBuilding.Type == "Train Station")
            {
                string nLine = txtValue.Text;
                TrainStation sB = (MVCPseudoGPS.TrainStation)editBuilding;
                sB.Line = nLine;
            }
            else
            {
                MessageBox.Show("Wait, What this error shouldn't happen?", "Building Type doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            nX = Convert.ToInt32(txtX.Text);
            nY = Convert.ToInt32(txtY.Text);
            nName = txtName.Text;

            selectedBuilding.X_pos = nX;
            selectedBuilding.Y_pos = nY;
            selectedBuilding.Name = nName;

            myModel.UpdateViews();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (lstBuildings.SelectedItem != null)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Do you want to delete selected shape?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        Base selectedBuilding = (MVCPseudoGPS.Base)lstBuildings.SelectedItem;
            //        myModel.DeleteBuilding(selectedBuilding);
            //        //if (myModel.BuildingList.Count < 1)
            //        //{
            //        //    MessageBox.Show("Building's List is now Empty", "No Building's Left!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //}
            //    }
            //    else
            //    {
            //        MessageBox.Show("No Changes have been made.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please chose a Building from the ListBox", "No Building Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //myModel.UpdateViews();
        }

        /// <summary>method: clearPanel
        /// clear all shapes from display on panel
        /// </summary>
        private void clearPanel()
        {
            pnlDraw.CreateGraphics().Clear(pnlDraw.BackColor);
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