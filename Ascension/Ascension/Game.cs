
using System;

namespace Ascension
{
    public class Game
    {
        private int gameInt;

        public int GameInt
        {
            get; private set;
        }

        public Game (int gameIntInput)
		{
            if (gameIntInput < 0)
                throw new ArgumentOutOfRangeException("Game int must not be negative!");

			gameInt = gameIntInput;
		}
    }
}