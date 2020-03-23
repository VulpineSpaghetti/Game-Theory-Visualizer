using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Theory_Visualizer
{
    class Match
    {
        private readonly Player player1;
        private readonly Player player2;


        public Match(Strategy strategy1, Strategy strategy2)
        {
            player1 = new Player(strategy1);
            player2 = new Player(strategy2);
        }


        public RoundResult playARound() {
            int p1Action = player1.action;
            int p2Action = player2.action;

            player1.RegisterOpponentsAction(p2Action);
            player2.RegisterOpponentsAction(p1Action);

            return new RoundResult(p1Action, p2Action);
        }
    }
}
