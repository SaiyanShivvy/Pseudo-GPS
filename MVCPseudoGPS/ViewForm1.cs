﻿using System;
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