using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    public enum ChosenObject  
    {
        Rock,
        Paper,
        Scissors,
    }

    public enum ObjectAction
    {
        Smash,
        Wrap,
        Cut
    }

    public class PlayItem
    {


        public ChosenObject? TheChosenObject = null;

        public ObjectAction? TheChosenObjectAction = null;

        public ChosenObject? Beats = null; // Could be re factored into a list if playing +Spock/Lizard 
    }
}
