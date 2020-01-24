using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    public class Game
    {
        private List<PlayItem> PossibleMoves = new List<PlayItem>();

        public Game()
        {
            PossibleMoves.Add(new PlayItem() { TheChosenObject = ChosenObject.Rock, TheChosenObjectAction = ObjectAction.Smash, Beats = ChosenObject.Scissors });
            PossibleMoves.Add(new PlayItem() { TheChosenObject = ChosenObject.Paper, TheChosenObjectAction = ObjectAction.Wrap, Beats = ChosenObject.Rock });
            PossibleMoves.Add(new PlayItem() { TheChosenObject = ChosenObject.Scissors, TheChosenObjectAction = ObjectAction.Cut, Beats = ChosenObject.Paper });
        }

        public void GameLoop()
        {
            while(true)
            {
                SingleGame();

                Console.WriteLine("Play Again? [Yes,No]");
                var input = Console.ReadLine();

                // This could be a bit better! what if you type any other word
                if (input.Equals("No", StringComparison.InvariantCultureIgnoreCase))
                    break;

            }
        }
        public void SingleGame()
        {
            Console.WriteLine("Choose your weapon [Rock,Paper,Scissors]");

            var input = Console.ReadLine();
           
            ChosenObject playerInput;
            if (!Enum.TryParse<ChosenObject>(input, true, out playerInput))
            {
                Console.WriteLine("Invalid Choice");
                return;
            }

            // Find the PlayItem Chosen
            var playerChoice = PossibleMoves.Find(x => x.TheChosenObject == playerInput);

            Random rand = new Random();

            var computerInput = (ChosenObject) rand.Next(0, Enum.GetNames(typeof(ChosenObject)).Length-1);
            var computerChoice =  PossibleMoves.Find(x => x.TheChosenObject == computerInput);
            

            if (playerChoice.Beats == computerChoice.TheChosenObject)
                Console.WriteLine($"You win {playerChoice.TheChosenObject} {playerChoice.TheChosenObjectAction} {computerChoice.TheChosenObject}");
            else if (playerChoice.TheChosenObject == computerChoice.TheChosenObject)
                Console.WriteLine("Draw");
            else
                Console.WriteLine($"Loser! {computerChoice.TheChosenObject} {computerChoice.TheChosenObjectAction} {playerChoice.TheChosenObject}");

        }
    }
}
