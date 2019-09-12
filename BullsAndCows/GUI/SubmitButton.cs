using System.Windows.Forms;
using System.Drawing;
using System;
using GameLogic;
using System.Collections.Generic;

namespace GUI
{
    public class SubmitButton : Button
    {
        public const int k_ButtonWidth = 50;
        public const int k_ButtonHeight = 25;
        public const int k_Width = 2 * k_Padding + k_ButtonWidth;
        public const int k_Height = Guess.k_Height;
        public const int k_Padding = 10;

        private Board m_Board;

        public SubmitButton(Point i_Location, Board i_Board)
        {
            m_Board = i_Board;
            ClientSize = new Size(k_ButtonWidth, k_ButtonHeight);
            Text = "-->>";
            Location = new Point(i_Location.X + k_Padding, (int)(i_Location.Y + 0.5 * (k_Height + Guess.k_Padding) - 0.5 * k_ButtonHeight));
            Enabled = false;
            Click += m_SubmitButton_Click;
            i_Board.Controls.Add(this);
        }

        public void m_SubmitButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            m_Board.Game.Turn(fromColorToLetter().ToArray());
            m_Board.Gusses[m_Board.Turn - 1].Enable(false);

            if (m_Board.Game.HasMoreGuesses)
            {
                m_Board.Gusses[m_Board.Turn].Enable(true);
            }

            fromFeedbackToColor();

            if (m_Board.Game.HasWon || !m_Board.Game.HasMoreGuesses)
            {
                fromLetterToColor();
            }

            if (m_Board.Game.HasWon && m_Board.Game.HasMoreGuesses)
            {
                m_Board.Gusses[m_Board.Turn].Enable(false);
            }
        }

        public void Enable(bool i_Input)
        {
            Enabled = i_Input;
        }

        private void fromFeedbackToColor()
        {
            for (int i = 0; i < 4; i++)
            {
                eFeedback feedback = m_Board.Game.Results[m_Board.Turn - 1, i];

                if (feedback == eFeedback.V)
                {
                    m_Board.Results[m_Board.Turn - 1].ResultButtons[i].BackColor = Color.Black;
                }
                else if (feedback == eFeedback.X)
                {
                    m_Board.Results[m_Board.Turn - 1].ResultButtons[i].BackColor = Color.Yellow;
                }
            }
        }

        private void fromLetterToColor()
        {
            for (int i = 0; i < m_Board.Game.Secret.Length; i++)
            {
                if (m_Board.Game.Secret[i] == eValidLetter.A)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.Purple;
                }
                else if (m_Board.Game.Secret[i] == eValidLetter.B)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.Red;
                }
                else if (m_Board.Game.Secret[i] == eValidLetter.C)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.LightGreen;
                }
                else if (m_Board.Game.Secret[i] == eValidLetter.D)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.Aqua;
                }
                else if (m_Board.Game.Secret[i] == eValidLetter.E)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.Blue;
                }
                else if (m_Board.Game.Secret[i] == eValidLetter.F)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.Yellow;
                }
                else if (m_Board.Game.Secret[i] == eValidLetter.G)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.Brown;
                }
                else if (m_Board.Game.Secret[i] == eValidLetter.H)
                {
                    m_Board.Secret.Buttons[i].BackColor = Color.White;
                }
            }
        }

        private List<eValidLetter> fromColorToLetter()
        {
            List<eValidLetter> validletters = new List<eValidLetter>();

            foreach (BoardButton btn in m_Board.Gusses[m_Board.Turn].Buttons)
            {
                if (btn.BackColor == Color.Purple)
                {
                    validletters.Add(eValidLetter.A);
                }
                else if (btn.BackColor == Color.Red)
                {
                    validletters.Add(eValidLetter.B);
                }
                else if (btn.BackColor == Color.LightGreen)
                {
                    validletters.Add(eValidLetter.C);
                }
                else if (btn.BackColor == Color.Aqua)
                {
                    validletters.Add(eValidLetter.D);
                }
                else if (btn.BackColor == Color.Blue)
                {
                    validletters.Add(eValidLetter.E);
                }
                else if (btn.BackColor == Color.Yellow)
                {
                    validletters.Add(eValidLetter.F);
                }
                else if (btn.BackColor == Color.Brown)
                {
                    validletters.Add(eValidLetter.G);
                }
                else if (btn.BackColor == Color.White)
                {
                    validletters.Add(eValidLetter.H);
                }
            }

            return validletters;
        }
    }
}
