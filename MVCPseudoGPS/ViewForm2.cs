using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private int max_x = 520;
        private int max_y = 420;

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
            else
            {
                MessageBox.Show("You have not selected a Building!", "Building Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtX.Text) || string.IsNullOrWhiteSpace(txtY.Text))
            {
                MessageBox.Show("Textboxes cannot be empty", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!rbMall.Checked && !rbShop.Checked && !rbTrainStation.Checked)
            {
                MessageBox.Show("Building Type must be selected.", "No Building Type Selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Base selectedBuilding = (MVCPseudoGPS.Base)editBuilding;
                if (selectedBuilding.Type == "Shop")
                {
                    if (!Double.TryParse(txtValue.Text, out double parse))
                    {
                        MessageBox.Show("Capacity is limited to Integer's only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        double nRating = Convert.ToDouble(txtValue.Text);
                        Shop sB = (MVCPseudoGPS.Shop)editBuilding;
                        if (nRating > 10.0 || nRating < 0.0)
                        {
                            MessageBox.Show("Rating must be between 0.0 - 10.0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            sB.Rating = nRating;
                        }
                    }
                }
                else if (selectedBuilding.Type == "Mall")
                {
                    if (!int.TryParse(txtValue.Text, out int parse))
                    {
                        MessageBox.Show("Capacity is limited to Integer's only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int nCapacity = Convert.ToInt32(txtValue.Text);
                        Mall sB = (MVCPseudoGPS.Mall)editBuilding;
                        if (nCapacity < 0)
                        {
                            MessageBox.Show("Capacity cannot be less than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            sB.Capacity = nCapacity;
                        }
                    }
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

                if (nX > max_x)
                {
                    MessageBox.Show("X value cannot be greater than " + max_x, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (nX < 0)
                {
                    MessageBox.Show("X value cannot be less than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (nY > max_y)
                {
                    MessageBox.Show("Y value cannot be greater than " + max_y, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (nY < 0)
                {
                    MessageBox.Show("Y value cannot be less than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    selectedBuilding.X_pos = nX;
                    selectedBuilding.Y_pos = nY;
                    selectedBuilding.Name = nName;
                }
            }

            myModel.UpdateViews();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (editBuilding != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete selected shape?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Base selectedBuilding = (MVCPseudoGPS.Base)editBuilding;
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

        private void rbShop_CheckedChanged(object sender, EventArgs e)
        {
            lblCusVal.Text = "Rating:";
        }

        private void rbMall_CheckedChanged(object sender, EventArgs e)
        {
            lblCusVal.Text = "Capacity:";
        }

        private void rbTrainStation_CheckedChanged(object sender, EventArgs e)
        {
            lblCusVal.Text = "Line:";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtX.Text = "";
            txtY.Text = "";
            txtName.Text = "";
            txtValue.Text = "";
            if (rbMall.Checked || rbShop.Checked || rbTrainStation.Checked)
            {
                rbTrainStation.Checked = false;
                rbMall.Checked = false;
                rbShop.Checked = false;
            }
        }

        private void ctxSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                ArrayList theBuildingList = myModel.BuildingList;
                Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
                foreach (Base b in theBuildings)
                {
                    sb.Append(b.ToString());
                }
                string temp = sb.ToString();
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(sb);
                sw.Close();
            }
        }

        private void ctxLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name, type, line;
                int xL, yL, capacity;
                double rating;

                // create arrayList from model and convert to array of shapes
                ArrayList theBuildingList = myModel.BuildingList;
                Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));

                // Ask to Save First
                if (theBuildingList.Count > 0)
                {
                    DialogResult res = MessageBox.Show("There are existing Buildings, Saving is reccomened otherwise data will be lost.", "Warning: Loss of Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        saveToolStripMenuItem.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Your Data was not saved.", "Data not Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // clear panel
                clearPanel();

                // draw all shapes in array
                foreach (Base b in theBuildings)
                {
                    theBuildingList.Remove(b);
                }

                //load data
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string theObjects = sr.ReadToEnd();
                sr.Close();
                string[] theLines = theObjects.Split('#');
                foreach (string sO in theLines)
                {
                    if (sO != "")
                    {
                        string[] building = sO.Split(',');
                        type = building[0];
                        name = building[1];
                        string px = building[3];
                        string py = building[4];
                        string x = px.Replace("(", "");
                        string y = px.Replace("(", "");
                        xL = Convert.ToInt32(x);
                        yL = Convert.ToInt32(y);

                        switch (type)
                        {
                            case "Shop":
                                rating = Convert.ToDouble(building[2]);
                                Shop sBuild = new Shop(name, xL, yL, type, Color.Black, rating);
                                myModel.AddBuilding(sBuild);
                                break;

                            case "Mall":
                                capacity = Convert.ToInt32(building[2]);
                                Mall mBuild = new Mall(name, xL, yL, type, Color.Red, capacity);
                                myModel.AddBuilding(mBuild);
                                break;

                            case "Train Station":
                                line = building[2];
                                TrainStation tsBuild = new TrainStation(name, xL, yL, type, Color.Blue, line);
                                myModel.AddBuilding(tsBuild);
                                break;
                        }
                    }
                }
                this.Invalidate();
            }
        }

        private void ctxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>method: clearPanel
        /// clear all shapes from display on panel
        /// </summary>
        private void clearPanel()
        {
            pnlDraw.CreateGraphics().Clear(pnlDraw.BackColor);
        }

        /// <summary>method: CheckForNumeric
        /// check for only numbers and backspace key
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private static bool CheckForNumeric(char ch)
        {
            int keyInt = (int)ch;
            if ((keyInt < 48 || keyInt > 57) && keyInt != 8)
                return false;
            else
                return true;
        }

        /// <summary> method: txtXpos_KeyPress
        /// allow only numbers and backspace key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckForNumeric(e.KeyChar) == false)
                e.Handled = true;
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