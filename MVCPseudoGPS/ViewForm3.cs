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
    /// <summary>
    /// Date: 1/11/18
    /// Author: Shivneel Achari
    /// Note: The Section above applies for all the following comments on this class
    /// defines view form 3
    /// </summary>
    public partial class ViewForm3 : Form, IBuildingView
    {
        // declare the model
        private BuildingsModel myModel;

        // set method for myModel
        public BuildingsModel MyModel
        {
            set
            {
                myModel = value;
            }
        }

        public ViewForm3()
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

        /// <summary>
        /// Displays builds with the same type as the selected value in the combobox.
        /// </summary>
        public void DisplayType()
        {
            // clear panel
            clearPanel();
            // create arrayList from model and convert to array of shapes
            ArrayList theBuildingList = myModel.BuildingList;
            Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
            string displayType = cbSelectType.SelectedItem.ToString();
            Graphics g = this.pnlDraw.CreateGraphics();
            // draw all shapes in array
            foreach (Base b in theBuildings)
            {
                if (b.Type.Equals(displayType))
                {
                    b.Display(g);
                }
            }
        }

        /// <summary>
        /// same as FormView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// same as viewform1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// updates and redraws view to reflect any changes.
        /// </summary>
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

        /// <summary>
        /// helper method to run another method when the combobox is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayType();
        }
    }
}