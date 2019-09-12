using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GUI
{
    public class Result
    {
        public const int k_Padding = 10;
        public const int k_Width = 3 * k_Padding + 2 * ResultButton.k_Size;
        public const int k_Height = 2 * k_Padding + 2 * ResultButton.k_Size;

        private List<ResultButton> m_ResultButtons;

        public Result(Point i_Location, Board i_Board)
        {
            m_ResultButtons = new List<ResultButton>();

            ResultButton first = new ResultButton(new Point(i_Location.X + k_Padding, i_Location.Y + k_Padding));
            ResultButton second = new ResultButton(new Point(i_Location.X + 2 * k_Padding + ResultButton.k_Size, i_Location.Y + k_Padding));
            ResultButton third = new ResultButton(new Point(i_Location.X + k_Padding, i_Location.Y + 2 * k_Padding + ResultButton.k_Size));
            ResultButton fourth = new ResultButton(new Point(i_Location.X + 2 * k_Padding + ResultButton.k_Size, i_Location.Y + 2 * k_Padding + ResultButton.k_Size));

            i_Board.Controls.Add(first);
            i_Board.Controls.Add(second);
            i_Board.Controls.Add(third);
            i_Board.Controls.Add(fourth);

            m_ResultButtons.Add(first);
            m_ResultButtons.Add(second);
            m_ResultButtons.Add(third);
            m_ResultButtons.Add(fourth);
        }

        public List<ResultButton> ResultButtons
        {
            get
            {
                return m_ResultButtons;
            }
        }
    }
}
