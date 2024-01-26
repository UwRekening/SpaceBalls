using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders_Monogame
{
    internal class Score
    {
        public int score;

        public Score()
        {
            score = 0;
        }

        private static Score _instance;
        public static Score GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Score();
            }
            return _instance;
        }
    }
}
