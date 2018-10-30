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
    public partial class ViewForm1 : Form, IBuildingView
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

        public ViewForm1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // required var's
            int X, Y;
            string name;
            Color aColor;
            Base aBuilding;
            aColor = Color.Black;

            try
            {
                X = Convert.ToInt32(txtX.Text);
                Y = Convert.ToInt32(txtY.Text);
                name = txtName.Text;
                if (rbShop.Checked)
                {
                    aBuilding = new Shop(name, X, Y, aColor, 4.5);
                    myModel.AddBuilding(aBuilding);
                }
                else if (rbMall.Checked)
                {
                    aBuilding = new Mall(name, X, Y, aColor, 69);
                    myModel.AddBuilding(aBuilding);
                }
                else if (rbTrainStation.Checked)
                {
                    aBuilding = new TrainStation(name, X, Y, aColor, "Test Line");
                    myModel.AddBuilding(aBuilding);
                }
                else
                {
                    MessageBox.Show("Please Select a Building Type", "No Building Type Selected!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "\r\n" + ex.ToString(),
                    "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshView()
        {
            // clear drawOn panel
            clearPanel();
            // clear listbox
            lstBuildings.Items.Clear();
            // create arrayList from model and convert to array of shapes
            ArrayList theBuildingList = myModel.BuildingList;
            Base[] theBuildings = (Base[])theBuildingList.ToArray(typeof(Base));
            Graphics g = this.pnlDraw.CreateGraphics();
            // draw all shapes in array
            foreach (Base b in theBuildings)
            {
                b.Display(g);
                lstBuildings.Items.Add(b);
            }
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

        //// set the runtime position of update panel
        //private void ViewForm1_Load(object sender, System.EventArgs e)
        //{
        //    pnlUpdate.Top = rbCircle.Top;
        //    pnlUpdate.Left = rbCircle.Left;
        //}
    }
}