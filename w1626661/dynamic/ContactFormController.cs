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
    public partial class ContactFormController : UserControl
    {
        public ContactFormController()
        {
            InitializeComponent();
        }

        public String name
        {
            get
            {
                return this.contactNametxt.Text;
            }
        }

        public String mobileNo
        {
            get
            {
                return this.mobilenumbertxt.Text;
            }
        }

        public String email
        {
            get
            {
                return this.emailtxt.Text;
            }
        }
    }
}
