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
    public partial class ViewForm3 : Form, IBuildingView
    {
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
        }

        private void ctxClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cbSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayType();
        }
    }
}