using System;
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
    public partial class MainForm : Form
    {
        private BuildingController buildingController;
        private BuildingModel buildingModel;
        private ViewForm1 viewForm1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnVF1_Click(object sender, EventArgs e)
        {
            viewSetup();
        }

        /// <summary>
        ///
        /// </summary>
        private void viewSetup()
        {
            // make the controller
            buildingController = new BuildingController();
            // make the model
            buildingModel = new BuildingModel(buildingController);
            // make views
            viewForm1 = new ViewForm1();

            buildingController.AddView(viewForm1);
            viewForm1.Show();
        }
    }
}