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
    public partial class MainForm : Form
    {
        private BuildingsController theController;
        private BuildingsModel theModel;
        private ViewForm1 viewForm1;
        private ViewForm2 viewForm2;
        private ViewForm3 viewForm3;

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
            // make controller
            theController = new BuildingsController();
            // make model
            theModel = new BuildingsModel(theController);
            // make views
            viewForm1 = new ViewForm1();
            viewForm2 = new ViewForm2();
            viewForm3 = new ViewForm3();
            viewForm1.MyModel = theModel;
            viewForm2.MyModel = theModel;
            viewForm3.MyModel = theModel;

            theController.AddView(viewForm1);
            //theController.AddView(viewForm2);
            //theController.AddView(viewForm3);

            //show views
            //viewForm3.Show();
            //viewForm2.Show();
            viewForm1.Show();
        }
    }
}