using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTools
{
    public class ChessGame
    {
        public string Event { get; set; }
        public string Site { get; set; }
        public string EventDate { get; set; }
        public string White { get; set; }
        public string Black { get; set; }
        public string WhiteElo { get; set; }
        public string BlackElo { get; set; }
        public string Result { get; set; }
        public string Moves { get; set; }
        public string Date { get; set; } // Can disregard
        public string Round { get; set; } // Can disregard
        public string ECO { get; set; } // Can disregard
    }
}
