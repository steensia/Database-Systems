using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTools
{
    public class PGNReader
    {
        private List<ChessGame> gamesList = new List<ChessGame>();

        public List<ChessGame> ReadFromFile(string PGNfilename)
        {

            bool moveFlag = false; // Check if moves is being read
            ChessGame games = new ChessGame(); 

            string[] readText = File.ReadAllLines(PGNfilename); // extract info from PGN files

            // Read line by line and check for tags
            foreach (var s in readText)
            {
                if (s.StartsWith("[Event"))
                {
                    if (s.StartsWith("[EventDate"))
                    {
                        string[] temp = s.Split('\"');
                        games.EventDate = temp[1];
                    }
                    else
                    {
                        string[] temp = s.Split('\"');
                        games.Event = temp[1];
                    }
                }

                else if (s.StartsWith("[Site"))
                {
                    string[] temp = s.Split('\"');
                    games.Site = temp[1];
                }

                else if (s.StartsWith("[White"))
                {
                    if (s.StartsWith("[WhiteElo"))
                    {
                        string[] temp = s.Split('\"');
                        games.WhiteElo = temp[1];
                    }
                    else
                    {
                        string[] temp = s.Split('\"');
                        games.White = temp[1];
                    }
                }
                else if (s.StartsWith("[Black"))
                {
                    if (s.StartsWith("[BlackElo"))
                    {
                        string[] temp = s.Split('\"');
                        games.BlackElo = temp[1];
                    }
                    else
                    {
                        string[] temp = s.Split('\"');
                        games.Black = temp[1];
                    }
                }

                else if (s.StartsWith("[Result"))
                {
                    string[] temp = s.Split('\"');

                    if (temp[1].Equals("1-0"))
                    {
                        games.Result = "W";
                    }
                    else if (temp[1].Equals("0-1"))
                    {
                        games.Result = "B";
                    }
                    else if (temp[1].Equals("1/2-1/2"))
                    {
                        games.Result = "D";
                    }
                }

                else if (s.StartsWith("[Date"))
                {
                    string[] temp = s.Split('\"');
                    games.Date = temp[1];
                }

                else if (s.StartsWith("[Round"))
                {
                    string[] temp = s.Split('\"');
                    games.Round = temp[1];
                }

                else if (s.StartsWith("[ECO"))
                {
                    string[] temp = s.Split('\"');
                    games.ECO = temp[1];
                }

                // Start reading moves
                else if (s.StartsWith("1.") && moveFlag == false)
                {
                    moveFlag = true;
                }

                // Read moves
                if (moveFlag)
                {
                    // Keep storing moves until a new line is reached
                    if(!string.IsNullOrEmpty(s))
                    {
                        games.Moves += s;
                    }
                    // New line has reached, time to add the ChessGame to the list and create a new ChessGame to be added
                    else
                    {
                        gamesList.Add(games);
                        games = new ChessGame();
                        moveFlag = false;
                    }
                }
            }

            return new List<ChessGame>(gamesList);
        }
    }
}
