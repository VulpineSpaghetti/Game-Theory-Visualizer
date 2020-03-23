using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Theory_Visualizer
{
    class Player
    {
        private int state;
        private readonly Strategy strategy;
        
        public int action { get => strategy.ActionOfState(state); }


        public Player(Strategy strategy)
        {
            this.strategy = strategy;
            state = 0;
        }


        public void RegisterOpponentsAction(int actionOfOpponent) {
            state = strategy.NewState(actionOfOpponent, state);
        }
    }
}
