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
    public partial class ContactDisplayController : UserControl
    {
        public ContactDisplayController()
        {
            InitializeComponent();


        }
        public String id
        {
            get
            {
                return this.lblId.Text;
            }
        }
        public String name
        {
            get
            {
                return this.lblName.Text;
            }
        }

        public String mobileNo
        {
            get
            {
                return this.lblMobileno.Text;
            }
        }

        public String email
        {
            get
            {
                return this.lblEmail.Text;
            }
        }
    }
}
