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
    /// Note: The Section above applies for all the following comments on this class, I also ran out of time to completely comment all code.
    /// Purpose: This class is meant to act as a menu and allow the user to open ViewForms
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// declaring the controller, views and model
        /// </summary>
        private BuildingsController theController;

        private BuildingsModel theModel;
        private ViewForm1 viewForm1;
        private ViewForm2 viewForm2;
        private ViewForm3 viewForm3;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Menu";
            viewSetup();
        }

        /// <summary>
        /// This method is to setup views, model and controller and add views to the controller
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
            // setup models
            viewForm1.MyModel = theModel;
            viewForm2.MyModel = theModel;
            viewForm3.MyModel = theModel;
            // add view to controller
            theController.AddView(viewForm1);
            theController.AddView(viewForm2);
            theController.AddView(viewForm3);
        }

        /// <summary>
        /// setup views and display viewform1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVF1_Click(object sender, EventArgs e)
        {
            viewSetup();
            viewForm1.Show();
        }

        /// <summary>
        /// setup views and display viewform2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVF2_Click(object sender, EventArgs e)
        {
            viewSetup();
            viewForm2.Show();
        }

        /// <summary>
        /// setup views and display viewform3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVF3_Click(object sender, EventArgs e)
        {
            viewSetup();
            viewForm3.Show();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}