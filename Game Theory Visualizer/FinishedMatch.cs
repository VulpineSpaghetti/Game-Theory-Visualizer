using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Theory_Visualizer
{
    class FinishedMatch
    {
        public readonly List<RoundResult> initialRounds;
        public readonly List<RoundResult> cycleOfRounds;

        public readonly GameSpec gameSpec;

        public readonly int player1ScoreNumerator = 0;
        public readonly int player2ScoreNumerator = 0;
        public readonly int playerScoreDenominator;


        public FinishedMatch(Match match, GameSpec gameSpec) {
            List<RoundResult> rounds = new List<RoundResult>();
            RoundResult roundResult;

            this.gameSpec = gameSpec;

            do {
                roundResult = match.playARound();

                if (rounds.IndexOf(roundResult) != -1)
                    break;

                rounds.Add(roundResult);
            } while (true);

            initialRounds = (List<RoundResult>)rounds.TakeWhile(res => res != roundResult);
            cycleOfRounds = (List<RoundResult>)rounds.SkipWhile(res => res != roundResult);


            playerScoreDenominator = cycleOfRounds.Count;

            foreach(RoundResult round in cycleOfRounds) {
                player1ScoreNumerator += gameSpec.getRewardOfPlayer1(round.player1Action, round.player2Action);
                player2ScoreNumerator += gameSpec.getRewardOfPlayer2(round.player1Action, round.player2Action);
            }
        }
    }
}
