using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GUI
{
    public class Guess
    {
        public const int k_Padding = 10;
        public const int k_Width = 5 * k_Padding + 4 * BoardButton.k_Size;
        public const int k_Height = k_Padding + BoardButton.k_Size;

        private List<BoardButton> m_Buttons;
        private Point m_Location;
        private int m_UniqueColors = 0;
        private Board m_Board;
        private HashSet<Color> m_SelectedColors = new HashSet<Color>(); 

        public Guess(Point i_Location, Board i_Board)
        {
            m_Buttons = new List<BoardButton>();
            m_Location = i_Location;
            m_Board = i_Board;

            BoardButton first = new BoardButton(new Point(i_Location.X + k_Padding, i_Location.Y + k_Padding), i_Board);
            BoardButton second = new BoardButton(new Point(i_Location.X + 2 * k_Padding + BoardButton.k_Size, i_Location.Y + k_Padding), i_Board);
            BoardButton third = new BoardButton(new Point(i_Location.X + 3 * k_Padding + 2 * BoardButton.k_Size, i_Location.Y + k_Padding), i_Board);
            BoardButton fourth = new BoardButton(new Point(i_Location.X + 4 * k_Padding + 3 * BoardButton.k_Size, i_Location.Y + k_Padding), i_Board);

            i_Board.Controls.Add(first);
            i_Board.Controls.Add(second);
            i_Board.Controls.Add(third);
            i_Board.Controls.Add(fourth);

            m_Buttons.Add(first);
            m_Buttons.Add(second);
            m_Buttons.Add(third);
            m_Buttons.Add(fourth);
        }

        public void ColorCounter()
        {
            m_SelectedColors = new HashSet<Color>();

            foreach (BoardButton btn in m_Buttons)
            {
                if (btn.BackColor != m_Board.BackColor)
                {
                    m_SelectedColors.Add(btn.BackColor);
                }
            }

            m_UniqueColors = m_SelectedColors.Count();
        }

        public void Enable(bool i_Input)
        {
            foreach (BoardButton btn in m_Buttons)
            {
                btn.Enabled = i_Input;
            }
        }

        public Point Location
        {
            get
            {
                return m_Location;
            }
        }

        public List<BoardButton> Buttons
        {
            get
            {
                return m_Buttons;
            }
        }

        public int UniqueColors
        {
            get
            {
                return m_UniqueColors;
            }
        }

        public HashSet<Color> SelectedColors
        {
            get
            {
                return m_SelectedColors;
            }
        }
    }
}
