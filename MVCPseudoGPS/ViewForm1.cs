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
    public partial class ViewForm1 : Form, IBuildingView
    {
        private BuildingsModel myModel;
        private int max_x = 520;
        private int max_y = 420;

        // set method for myModel
        public BuildingsModel MyModel
        {
            set
            {
                myModel = value;
            }
        }

        public ViewForm1()
        {
            InitializeComponent();
        }

        // Add Input Validation

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int X, Y;
            string name;
            Color aColor;
            Base aBuilding;
            try
            {
                X = Convert.ToInt32(txtX.Text);
                Y = Convert.ToInt32(txtY.Text);
                if (X > max_x)
                {
                    MessageBox.Show("X value cannot be greater than " + max_x, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (X < 0)
                {
                    MessageBox.Show("X value cannot be less than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Y > max_y)
                {
                    MessageBox.Show("Y value cannot be greater than " + max_y, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Y < 0)
                {
                    MessageBox.Show("Y value cannot be less than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    name = txtName.Text;
                    if (rbShop.Checked)
                    {
                        string type = "Shop";
                        double rating = Convert.ToDouble(txtValue.Text);
                        aColor = Color.Black;
                        if (rating > 10.0 || rating < 0.0)
                        {
                            MessageBox.Show("Rating must be between 0.0 - 10.0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            aBuilding = new Shop(name, X, Y, type, aColor, rating);
                            myModel.AddBuilding(aBuilding);
                        }
                    }
                    else if (rbMall.Checked)
                    {
                        string type = "Mall";
                        int capacity = Convert.ToInt32(txtValue.Text);
                        aColor = Color.Red;
                        if (capacity < 0)
                        {
                            MessageBox.Show("Capacity cannot be less than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            aBuilding = new Mall(name, X, Y, type, aColor, capacity);
                            myModel.AddBuilding(aBuilding);
                        }
                    }
                    else if (rbTrainStation.Checked)
                    {
                        string type = "Train Station";
                        string line = txtValue.Text;
                        aColor = Color.Blue;
                        aBuilding = new TrainStation(name, X, Y, type, aColor, line);
                        myModel.AddBuilding(aBuilding);
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Building Type", "No Building Type Selected!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "\r\n" + ex.ToString(),
                    "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem != null)
            {
                int nX, nY;
                string nName;

                Base selectedBuilding = (MVCPseudoGPS.Base)lstBuildings.SelectedItem;
                if (selectedBuilding.Type == "Shop")
                {
                    double nRating = Convert.ToDouble(txtValue.Text);
                    Shop sB = (MVCPseudoGPS.Shop)lstBuildings.SelectedItem;
                    if (nRating > 10.0 || nRating < 0.0)
                    {
                        MessageBox.Show("Rating must be between 0.0 - 10.0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        sB.Rating = nRating;
                    }
                }
                else if (selectedBuilding.Type == "Mall")
                {
                    int nCapacity = Convert.ToInt32(txtValue.Text);
                    Mall sB = (MVCPseudoGPS.Mall)lstBuildings.SelectedItem;
                    if (nCapacity < 0)
                    {
                        MessageBox.Show("Capacity cannot be less than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        sB.Capacity = nCapacity;
                    }
                }
                else if (selectedBuilding.Type == "Train Station")
                {
                    string nLine = txtValue.Text;
                    TrainStation sB = (MVCPseudoGPS.TrainStation)lstBuildings.SelectedItem;
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
            else
            {
                MessageBox.Show("Please chose a Building from the ListBox", "No Building Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myModel.UpdateViews();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete selected shape?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Base selectedBuilding = (MVCPseudoGPS.Base)lstBuildings.SelectedItem;
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

        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            Base selItem = (MVCPseudoGPS.Base)lstBuildings.SelectedItem;
            if (selItem.Type == "Shop")
            {
                rbShop.Checked = true;
                rbMall.Checked = false;
                rbTrainStation.Checked = false;
                txtName.Text = selItem.Name;
                txtValue.Text = "";
                txtX.Text = selItem.X_pos.ToString();
                txtY.Text = selItem.Y_pos.ToString();
            }
            else if (selItem.Type == "Mall")
            {
                rbShop.Checked = false;
                rbMall.Checked = true;
                rbTrainStation.Checked = false;
                txtName.Text = selItem.Name;
                txtValue.Text = "";
                txtX.Text = selItem.X_pos.ToString();
                txtY.Text = selItem.Y_pos.ToString();
            }
            else if (selItem.Type == "Train Station")
            {
                rbShop.Checked = false;
                rbMall.Checked = false;
                rbTrainStation.Checked = true;
                txtName.Text = selItem.Name;
                txtValue.Text = "";
                txtX.Text = selItem.X_pos.ToString();
                txtY.Text = selItem.Y_pos.ToString();
            }
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
                    sb.Append("#");
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
                // clear listbox
                lstBuildings.Items.Clear();

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
                                Mall mBuild = new Mall(name, xL, yL, type, Color.Black, capacity);
                                myModel.AddBuilding(mBuild);
                                break;

                            case "Train Station":
                                line = building[2];
                                TrainStation tsBuild = new TrainStation(name, xL, yL, type, Color.Black, line);
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
            // clear listbox
            lstBuildings.Items.Clear();
            // create arrayList from model and convert to array of shapes
            ArrayList theBuildingList = myModel.BuildingList;
            Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
            // draw all shapes in array
            foreach (Base b in theBuildings)
            {
                lstBuildings.Items.Add(b);
            }
        }
    }
}