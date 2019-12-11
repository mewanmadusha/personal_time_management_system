using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace w1626661.dynamic
{
    class RoundedPictureBox: PictureBox
    {
        

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(GraphPath);
            base.OnPaint(e);
        }
    }
}
