using System.Collections.Generic;
using System;

namespace GameLogic
{
    public class GameUtils
    {
        public const byte k_MinNumberOfGuesses = 4;
        public const byte k_MaxNumberOfGuesses = 10;
        public const byte k_LengthOfSecret = 4;

        public static Random s_Random = new Random();

        public static eValidLetter[] GenerateSecret()
        {
            HashSet<eValidLetter> hs = new HashSet<eValidLetter>();
            eValidLetter[] secretArr = new eValidLetter[k_LengthOfSecret];

            while (hs.Count < k_LengthOfSecret)
            {
                hs.Add((eValidLetter)s_Random.Next((byte)eValidLetter.A, (byte)eValidLetter.H));
            }

            hs.CopyTo(secretArr);

            return secretArr;
        }
    }
}
