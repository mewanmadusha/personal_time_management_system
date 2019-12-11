using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w1626661.dynamic
{
    public partial class EventDisplayController : UserControl
    {
        public EventDisplayController()
        {
            InitializeComponent();
        }

        public String title
        {
            get
            {
                return this.lblTitle.Text;
            }
        }

        public String description
        {
            get
            {
                return this.lblDescription.Text;
            }
        }

        public String EventVareity
        {
            get
            {
                return this.lblVareity.Text;
            }
        }


        public String startingTime
        {
            get
            {
                return this.lblDateStart.Text;
            }
        }



        public String EndingTime
        {
            get
            {
                return this.lblDateEnd.Text;
            }
        }

        public String location
        {
            get
            {
                return this.lblLocation.Text;
            }
        }
        public String id
        {
            get
            {
                return this.lblId.Text;
            }
        }

        public String recurType
        {
            get
            {
                return this.lblRecuringType.Text;
            }
        }
      

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblVareity_Click(object sender, EventArgs e)
        {

        }

        private void lblDateStart_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblLocation_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblDateEnd_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRecuringType_Click(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }
    }
}
