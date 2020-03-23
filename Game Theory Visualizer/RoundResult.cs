using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Theory_Visualizer
{
    class RoundResult
    {
        public readonly int player1Action;
        public readonly int player2Action;


        public RoundResult(int player1Action, int player2Action)
        {
            this.player1Action = player1Action;
            this.player2Action = player2Action;
        }
    }
}
