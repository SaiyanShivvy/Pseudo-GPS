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
                    double rating = Convert.ToDouble(txtValue.Text);
                    Console.WriteLine(rating);
                    aBuilding = new Shop("shop", X, Y, aColor, rating);
                    myModel.AddBuilding(aBuilding);
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
            lblCusVal.Text = "Rating";
        }

        private void rbMall_CheckedChanged(object sender, EventArgs e)
        {
            lblCusVal.Text = "Stores";
        }

        private void rbTrainStation_CheckedChanged(object sender, EventArgs e)
        {
            lblCusVal.Text = "Line";
        }

        //// set the runtime position of update panel
        //private void ViewForm1_Load(object sender, System.EventArgs e)
        //{
        //    pnlUpdate.Top = rbCircle.Top;
        //    pnlUpdate.Left = rbCircle.Left;
        //}
    }
}