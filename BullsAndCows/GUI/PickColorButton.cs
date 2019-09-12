using System.Drawing;
using System;
using System.Windows.Forms;

namespace GUI
{
    public class PickColorButton : Button
    {
        public const int k_Size = 50;

        private BoardButton m_BoardButton;
        private ColorsForm m_ColorsForm;

        public PickColorButton(Color i_Color, Point i_Location, BoardButton i_BoardButton, ColorsForm i_ColorsForm) 
        {
            m_ColorsForm = i_ColorsForm;
            m_BoardButton = i_BoardButton;

            ClientSize = new Size(k_Size, k_Size);
            BackColor = i_Color;
            Location = i_Location;
            Click += m_Color_Button_Click;
        }

        public void m_Color_Button_Click(object sender, EventArgs e)
        {
            m_BoardButton.BackColor = BackColor;
            m_ColorsForm.Close();
            m_BoardButton.Board.Gusses[m_BoardButton.Board.Turn].ColorCounter();
        }
    }
}
