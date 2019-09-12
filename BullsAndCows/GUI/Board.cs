using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using GameLogic;

namespace GUI
{
    public class Board : Form
    {
        public const int k_Padding = 20;

        private List<Guess> m_Gusses;
        private List<Result> m_Results;
        private List<SubmitButton> m_SubmitButtons;
        private byte m_numberOfGuesses;
        private Game m_Game;
        private Guess m_Secret;

        public Board(byte i_numberOfGuesses)
        {
            m_Gusses = new List<Guess>();
            m_Results = new List<Result>();
            m_SubmitButtons = new List<SubmitButton>();
            m_numberOfGuesses = i_numberOfGuesses;
            m_Game = new Game(m_numberOfGuesses);
            m_Secret = new Guess(new Point(0, 0), this);

            Text = "Bool Pgia";
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            for (int i = 0; i < 4; i++)
            {
                m_Secret.Buttons[i].BackColor = Color.Black;
            }

            Point startPos = new Point(0, 70);

            ClientSize = new Size(Guess.k_Width + SubmitButton.k_Width + Result.k_Width, (m_numberOfGuesses + 1) * Guess.k_Height + k_Padding);

            for (int i = 0; i < m_numberOfGuesses; i++)
            {
                m_Gusses.Add(new Guess(new Point(startPos.X , startPos.Y + i * Guess.k_Height), this));
                m_SubmitButtons.Add(new SubmitButton(new Point(startPos.X + Guess.k_Width, Gusses[i].Location.Y), this));
                m_Results.Add(new Result(new Point(startPos.X + Guess.k_Width + SubmitButton.k_Width, m_Gusses[i].Location.Y), this));
            }

            m_Gusses[0].Enable(true);
        }

        public List<Guess> Gusses
        {
            get
            {
                return m_Gusses;
            }
        }

        public List<SubmitButton> SubmitButtons
        {
            get
            {
                return m_SubmitButtons;
            }
        }

        public int Turn
        {
            get
            {
                return m_Game.CurrentTurn;
            }
        }

        public Game Game
        {
            get
            {
                return m_Game;
            }
        }

        public List<Result> Results
        {
            get
            {
                return m_Results;
            }
        }

        public Guess Secret
        {
            get
            {
                return m_Secret;
            }
        }
    }
}
