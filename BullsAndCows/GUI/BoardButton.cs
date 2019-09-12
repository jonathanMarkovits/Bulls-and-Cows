using System.Drawing;
using System;
using System.Windows.Forms;

namespace GUI
{
    public class BoardButton : Button
    {
        public const int k_Size = 50;

        private Board m_Board;

        public BoardButton(Point i_Location, Board i_Board)
        {
            m_Board = i_Board;
            Location = i_Location;
            ClientSize = new Size(k_Size, k_Size);
            Click += m_BoardButton_Click;
            Enabled = false;
        }

        public void m_BoardButton_Click(object sender, EventArgs e)
        {
            ColorsForm colorsForm = new ColorsForm(this);

            colorsForm.DisableSelectedColors(m_Board.Gusses[m_Board.Turn].SelectedColors);
            colorsForm.ShowDialog();
            if (m_Board.Gusses[m_Board.Turn].UniqueColors == 4)
            {
                m_Board.SubmitButtons[m_Board.Turn].Enable(true);
            }
            else
            {
                m_Board.SubmitButtons[m_Board.Turn].Enable(false);
            }
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }
    }
}
