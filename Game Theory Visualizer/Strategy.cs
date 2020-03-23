using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Theory_Visualizer
{
    class Strategy
    {
        public readonly string name;
        private readonly int[] actionOfState;
        private readonly int[,] stateTransitionFn;


        public Strategy(string name, int[] actionOfState, int[,] stateTransitionFn)
        {
            this.name = name;
            this.actionOfState = actionOfState;
            this.stateTransitionFn = stateTransitionFn;
        }


        public int ActionOfState(int state)
            => actionOfState[state];

        public int NewState(int action, int currentState)
            => stateTransitionFn[currentState, action];


        public Strategy pd_AlwaysCooperate()
            => new Strategy("Always Cooperate", new int[] {0}, new int[,] {{1,1}});

        public Strategy pd_AlwaysBetray()
            => new Strategy("Always Betray", new int[] {1}, new int[,] {{0,0}});

        public Strategy pd_Tit()
            => new Strategy("Tit for tat", new int[] {0,1}, new int[,] {{0,1}, {0,1}});

        public Strategy pd_Eye()
            => new Strategy("Eye for an eye", new int[] {1,0}, new int[,] {{1,0}, {1,0}});

        public Strategy pd_PavlovsDog()
            => new Strategy("Pavlov's Dog", new int[] {0,1}, new int[,] {{1,0}, {0,1}});


        public Strategy[] prisonersDilemaStrategies()
            => new Strategy[] {pd_AlwaysCooperate(), pd_AlwaysCooperate(), pd_Tit(), pd_Eye(), pd_PavlovsDog()};
    }
}
