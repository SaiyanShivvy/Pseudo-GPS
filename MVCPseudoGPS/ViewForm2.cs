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

        // variables for mouse position
        private Point lastPosition = new Point(0, 0);

        private Point currentPosition = new Point(0, 0);

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

        private void pnlDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectBuilding != null)
            {
                edit();
                dragging = true;
            }
        }

        private void pnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            // set last position to current position
            lastPosition = currentPosition;
            // set current position to mouse position
            currentPosition = new Point(e.X, e.Y);
            // calculate how far mouse has moved
            int xMove = currentPosition.X - lastPosition.X;
            int yMove = currentPosition.Y - lastPosition.Y;

            if (!dragging) // mouse not down
            {
                // reset variables
                selectBuilding = null;
                bool needsDisplay = false;

                // create arrayList of shaapes from myModel
                ArrayList theBuildingList = myModel.BuildingList;
                // create array of shapes from array list
                Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
                // graphics object to draw shapes when required
                Graphics g = this.pnlDraw.CreateGraphics();

                // loop through array checking if mouse is over shape
                foreach (Base b in theBuildings)
                {
                    // check if mouse is over shape
                    if (b.HitTest(new Point(e.X, e.Y)))
                    {
                        // if so make shape topShape
                        selectBuilding = b;
                    }

                    if (b.Highlight == true)
                    {
                        // shape to be redrawn
                        needsDisplay = true;
                        // redraw shape
                        b.Display(g);
                        b.Highlight = false;
                    }
                }

                if (selectBuilding != null) // if there is a building
                {
                    needsDisplay = true; // need to redisplay
                    selectBuilding.Display(g); // redisplay topShape
                    selectBuilding.Highlight = true;
                }

                if (needsDisplay)
                {
                    // redisplay model
                    myModel.UpdateViews();
                }
            }
            else // mouse is down
            {
                // reset position of selected shape by value of mouse move
                selectBuilding.X_pos = selectBuilding.X_pos + xMove;
                selectBuilding.Y_pos = selectBuilding.Y_pos + yMove;
                edit();
                myModel.UpdateViews();
            }
        }

        private void pnlDraw_MouseUp(object sender, MouseEventArgs e)
        {
            edit();
            dragging = false;
            clearPanel();
            // create arrayList of shapes from model and convert to array of shapes
            ArrayList theBuildingList = myModel.BuildingList;
            Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
            Graphics g = this.pnlDraw.CreateGraphics();
            // check if shape selected and if so display
            if (editBuilding != null)
            {
                theBuildings[0] = selectBuilding;
                selectBuilding.Display(g);
            }
            myModel.UpdateViews();
        }

        private void edit()
        {
            if (selectBuilding != null)
            {
                editBuilding = selectBuilding;

                txtName.Text = selectBuilding.Name;
                txtX.Text = selectBuilding.X_pos.ToString();
                txtY.Text = selectBuilding.Y_pos.ToString();
                switch (selectBuilding.Type)
                {
                    case "Shop":
                        rbShop.Checked = true;
                        rbMall.Checked = false;
                        rbTrainStation.Checked = false;
                        Shop sp = (MVCPseudoGPS.Shop)selectBuilding;
                        lblCusVal.Text = "Rating";
                        txtValue.Text = sp.Rating.ToString();
                        break;

                    case "Mall":
                        rbShop.Checked = false;
                        rbMall.Checked = true;
                        rbTrainStation.Checked = false;
                        Mall ml = (MVCPseudoGPS.Mall)selectBuilding;
                        lblCusVal.Text = "Capacity";
                        txtValue.Text = ml.Capacity.ToString();
                        break;

                    case "Train Station":
                        rbShop.Checked = false;
                        rbMall.Checked = false;
                        rbTrainStation.Checked = true;
                        TrainStation ts = (MVCPseudoGPS.TrainStation)selectBuilding;
                        lblCusVal.Text = "Line";
                        txtValue.Text = ts.Line;
                        break;
                }
            }
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
            if (selectBuilding != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete selected shape?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Base selectedBuilding = (MVCPseudoGPS.Base)selectBuilding;
                    myModel.DeleteBuilding(selectedBuilding);
                }
                else
                {
                    MessageBox.Show("No Changes have been made.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please chose a Building from the ListBox", "No Building Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myModel.UpdateViews();
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