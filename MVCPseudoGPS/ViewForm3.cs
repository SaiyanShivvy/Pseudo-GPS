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
    public partial class ViewForm3 : Form
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

        public ViewForm3()
        {
            InitializeComponent();
        }
    }
}