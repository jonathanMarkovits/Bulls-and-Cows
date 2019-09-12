using System.Windows.Forms;
using System.Drawing;
using System;

namespace GUI
{
    public class ResultButton : Button
    {
        public const int k_Size = 20;

        public ResultButton(Point i_Location)
        {
            Location = i_Location;
            ClientSize = new Size(k_Size, k_Size);
            Enabled = false;
        }
    }
}
