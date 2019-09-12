using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace GUI
{
    public class ColorsForm : Form
    {
        public const int k_Padding = 10;
        public const int k_Width = 5 * k_Padding + 4 * PickColorButton.k_Size;

        public ColorsForm(BoardButton i_BoardButton)
        {
            ClientSize = new Size(k_Width, (int)k_Width / 2 + 5);
            Text = "Pick A Color:";
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Controls.Add(new PickColorButton(Color.Purple, new Point(k_Padding, k_Padding), i_BoardButton, this));
            Controls.Add(new PickColorButton(Color.Red, new Point(2 * k_Padding + PickColorButton.k_Size, k_Padding), i_BoardButton, this));
            Controls.Add(new PickColorButton(Color.LightGreen, new Point(3 * k_Padding + 2 * PickColorButton.k_Size, k_Padding), i_BoardButton, this));
            Controls.Add(new PickColorButton(Color.Aqua, new Point(4 * k_Padding + 3 * PickColorButton.k_Size, k_Padding), i_BoardButton, this));
            Controls.Add(new PickColorButton(Color.Blue, new Point(k_Padding, 2 * k_Padding + PickColorButton.k_Size), i_BoardButton, this));
            Controls.Add(new PickColorButton(Color.Yellow, new Point(2 * k_Padding + PickColorButton.k_Size, 2 * k_Padding + PickColorButton.k_Size), i_BoardButton, this));
            Controls.Add(new PickColorButton(Color.Brown, new Point(3 * k_Padding + 2 * PickColorButton.k_Size, 2 * k_Padding + PickColorButton.k_Size), i_BoardButton, this));
            Controls.Add(new PickColorButton(Color.White, new Point(4 * k_Padding + 3 * PickColorButton.k_Size, 2 * k_Padding + PickColorButton.k_Size), i_BoardButton, this));
        }

        public void DisableSelectedColors(HashSet<Color> i_SelectedColors)
        {
            foreach (PickColorButton btn in Controls)
            {
                if (i_SelectedColors.Contains(btn.BackColor))
                {
                    btn.Enabled = false;
                }
            }
        }
    }
}
