using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Theory_Visualizer
{
    class GameSpec
    {
        public readonly string name;
        private readonly string[] nameOfPlayer1Action;
        private readonly string[] nameOfPlayer2Action;
        private readonly int[,] player1Reward;
        private readonly int[,] player2Reward;


        public GameSpec(string name, string[] nameOfP1Action, string[] nameOfP2Action, int[,] p1Reward, int[,] p2Reward)
        {
            this.name = name;
            nameOfPlayer1Action = nameOfP1Action;
            nameOfPlayer2Action = nameOfP2Action;
            player1Reward = p1Reward;
            player2Reward = p2Reward;
        }


        public string getNameOfActionOfPlayer1(int action) => nameOfPlayer1Action[action];
        public string getNameOfActionOfPlayer2(int action) => nameOfPlayer2Action[action];

        public int NumOfActionsOfPlayer1 { get => nameOfPlayer1Action.Length; }
        public int NumOfActionsOfPlayer2 { get => nameOfPlayer2Action.Length; }

        public int getRewardOfPlayer1(int actionOfP1, int actionOfP2) => player1Reward[actionOfP1, actionOfP2];
        public int getRewardOfPlayer2(int actionOfP1, int actionOfP2) => player2Reward[actionOfP1, actionOfP2];


        public GameSpec makeSymmetricalGame(string name, string[] nameOfAction, int[,] p1Reward, int[,] p2Reward)
            => new GameSpec(name, nameOfAction, nameOfAction, p1Reward, p2Reward);

        public GameSpec makeSymmetricConstSumGame(string name, string[] nameOfAction, int[,] p1Reward, int c)
        {
            int[,] p2Reward = new int[p1Reward.GetLength(0), p1Reward.GetLength(1)];
            for (int i = 0; i < p1Reward.GetLength(0); i++)
                for (int j = 0; j < p1Reward.GetLength(1); j++)
                    p2Reward[i, j] = c - p1Reward[i, j];

            return makeSymmetricalGame(name, nameOfAction, p1Reward, p2Reward);
        }

        public GameSpec makeSymmetricZeroSumGame(string name, string[] nameOfAction, int[,] p1Reward)
            => makeSymmetricConstSumGame(name, nameOfAction, p1Reward, 0);

        public GameSpec makeSymmetricTransposedGame(string name, string[] nameOfAction, int[,] p1Reward)
        {
            int[,] p2Reward = new int[p1Reward.GetLength(0), p1Reward.GetLength(1)];
            for (int i = 0; i < p1Reward.GetLength(0); i++)
                for (int j = 0; j < p1Reward.GetLength(1); j++)
                    p2Reward[j, i] = p1Reward[i, j];

            return makeSymmetricalGame(name, nameOfAction, p1Reward, p2Reward);
        }


        public GameSpec prisonersDilemmaGameSpec()
            => makeSymmetricTransposedGame("Prisoner's Dilemma", new string[] {"Cooperate", "Betray"},
                new int[,] {{2,0}, {3,1}});

        public GameSpec battleOfSexesGameSpec()
            => makeSymmetricalGame("Battle of Sexes", new string[] { "Opera", "Football" },
                new int[,] {{3,0}, {0,2}}, new int[,] {{2,0}, {0,3}});
    }
}
