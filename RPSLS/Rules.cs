using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Rules
    {
        readonly int amount;

        public Rules(string[] args)
        {
            amount = args.Length;
        }

        public string Winner(int userMove, int pcMove)
        {
            if (userMove == pcMove)
            {
                return "Draw";
            }
            for (int i = 0; i < (amount - 1) / 2; i++)
            {
                if (pcMove == amount - 1)
                {
                    pcMove = 0;
                }
                else
                {
                    pcMove++;
                }
                if (pcMove == userMove)
                {
                    return "PC won";
                }
            }
            return "You won";
        }
    }
}
