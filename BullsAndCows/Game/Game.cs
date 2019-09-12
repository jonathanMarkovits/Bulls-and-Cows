using System;

namespace GameLogic
{
    public class Game
    {
        private eValidLetter[,] m_Pins;
        private eFeedback[,] m_Results;
        private eValidLetter[] m_Secret;
        private byte m_NumberOfGuesses;
        private byte m_CurrentTurn;
        private bool m_HasMoreGuesses;
        private bool m_HasWon;


        public Game(byte i_NumberOfGuesses)
        {
            m_NumberOfGuesses = i_NumberOfGuesses;
            m_Pins = new eValidLetter[i_NumberOfGuesses, GameUtils.k_LengthOfSecret];
            m_Results = new eFeedback[i_NumberOfGuesses, GameUtils.k_LengthOfSecret];
            m_Secret = GameUtils.GenerateSecret();
            m_CurrentTurn = 0;
            m_HasMoreGuesses = true;
            m_HasWon = false;
        }

        public void Turn(eValidLetter[] i_Guess)
        {
            eFeedback[] feedbacks = new eFeedback[GameUtils.k_LengthOfSecret];
            byte numOfCorrectlyGuesses = 0;

            for (int i = 0; i < GameUtils.k_LengthOfSecret; i++)
            {
                m_Pins[m_CurrentTurn, i] = i_Guess[i];
                if (Array.Exists(m_Secret, element => element == i_Guess[i]))
                {
                    if (m_Secret[i] == i_Guess[i])
                    {
                        feedbacks[i] = eFeedback.V;
                        numOfCorrectlyGuesses++;
                    }
                    else
                    {
                        feedbacks[i] = eFeedback.X;
                    }
                }
            }

            Array.Sort(feedbacks);
            Array.Reverse(feedbacks);
            for (int i = 0; i < GameUtils.k_LengthOfSecret; i++)
            {
                m_Results[m_CurrentTurn, i] = feedbacks[i];
            }

            m_CurrentTurn++;
            if (m_CurrentTurn == m_NumberOfGuesses)
            {
                m_HasMoreGuesses = false;
            }

            if (numOfCorrectlyGuesses == GameUtils.k_LengthOfSecret)
            {
                m_HasWon = true;
            }
        }

        public byte NumberOfGuesses
        {
            get
            {
                return m_NumberOfGuesses;
            }
        }

        public eValidLetter[,] Pins
        {
            get
            {
                return m_Pins;
            }
        }

        public eFeedback[,] Results
        {
            get
            {
                return m_Results;
            }
        }

        public eValidLetter[] Secret
        {
            get
            {
                return m_Secret;
            }
        }

        public byte CurrentTurn
        {
            get
            {
                return m_CurrentTurn;
            }
        }

        public bool HasMoreGuesses
        {
            get
            {
                return m_HasMoreGuesses;
            }
        }

        public bool HasWon
        {
            get
            {
                return m_HasWon;
            }
        }
    }
}