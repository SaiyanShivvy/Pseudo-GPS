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
        private BuildingsController theController;
        private BuildingsModel theModel;
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
            // make controller
            theController = new BuildingsController();
            // make model
            theModel = new BuildingsModel(theController);
            // make views
            viewForm1 = new ViewForm1();
            //myViewForm2 = new ViewForm2();
            //myViewForm3 = new ViewForm3();
            viewForm1.MyModel = theModel;
            //myViewForm2.MyModel = theModel;
            //myViewForm3.MyModel = theModel;

            theController.AddView(viewForm1);
            //theController.AddView(myViewForm2);
            //theController.AddView(myViewForm3);

            //show views
            //myViewForm3.Show();
            //myViewForm2.Show();
            viewForm1.Show();
        }
    }
}