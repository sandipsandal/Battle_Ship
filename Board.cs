using System;
using System.Collections.Generic;
using System.Text;

namespace Battle_Ship
{
    class Board
    {
        /// <summary>
        /// string[,] defines 2-d array
        /// string[4,4] defines 4x4 matrix which has string value
        /// </summary>
        /// <returns>
        ///     board which has 2-d array value
        /// </returns>
        public string[,] CreateBoard()
        {
            string[,] board = new string[4, 4]
            {
                {"0","0","0","0"},
                {"0","0","0","0"},
                {"0","0","0","0"},
                {"0","0","0","0"},

            };

            return board;
        }

        /// <summary>
        /// This prints game board.
        /// </summary>
        /// <param name="board"></param>

        public void PrintBoard(string[,] board)
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0}\t", board[i, j]));

                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
        /// <summary>
        /// set the board size how many row and column of board (matrix like-4x4)
        /// generate a random position of row and column in int-array
        /// we set the a position of ship on board randomly
        /// </summary>
        /// <param name="row">row defines how many rows in board - like -4</param>
        /// <param name="col">col defines how many rows in board - like -4</param>
        /// <returns>it returns one ship position on board  </returns>        
        public int[] SetRandomShipPosition(int row, int col)
        {
            Random random = new Random();
            int randomRow = random.Next(0, row);
            int randomCol = random.Next(0, col);
            int[] ship1 = new int[2] { randomRow, randomCol };
            //SetSecondShipPosition(randomRow, randomCol);
            return ship1;
        }


        /// <summary>
        /// set how many player wants to play, we ask the user setHowManyPlayers 
        /// user enter in string form we convert it into integer form
        /// create a for loop , when user inter players number loops runs and ask all user name 
        /// ask from user to enter players name with  message = Enter player name 1 (i+1)
        /// we create string array 'playersName' contains all playersname in string array
        /// </summary>
        /// <returns>all player names in string array</returns>
        public string[] CreatePlayers()
        {
            int setHowManyPlayers;
            Console.Write("Enter how many player wants to play : ");

            while (!int.TryParse(Console.ReadLine(), out setHowManyPlayers) || setHowManyPlayers <= 0)
            {
                           
                Console.WriteLine("please a valid number try agin");
                Console.Write("Enter how many player wants to play : ");
            }


            string[] playersName = new string[setHowManyPlayers];

            for (int i = 0; i < setHowManyPlayers; i++)
            {
                Console.Write("Enter Players {0} name : ", i + 1);
                playersName[i] = Console.ReadLine();

            }

            return playersName;

        }
        /// <summary>
        /// create a function which select randomly which player start the game with a message
        /// pass all players name wit
        /// .Next - count all value of parameters 
        /// .Length user for int value
        /// </summary>
        /// <param name="playersName">pass all players name in strng array</param>
        /// <returns>which no or index number of player starts play</returns>
        public string ChoosePlayer(string[] playersName)
        {
            Random playerWinToss = new Random();
            int index = playerWinToss.Next(0, playersName.Length);
            return playersName[index];
        }

        public void GameStrategy(int[] firstShip, int[] secondShip, string[,] boardGrids)
        {
          
            int hitCount = 0;
            int turn = 0;
            while (turn < 3)
            {
                
                turn++;
                
                Console.WriteLine("Please choose row and col val. 0-3");

                int guessRow;
                int guessCol;
                //int guessRow = Convert.ToInt32(Console.ReadLine());
                //int guessCol = Convert.ToInt32(Console.ReadLine());
                Console.Write("Guess ship position in row : ");

                while (!int.TryParse(Console.ReadLine(), out guessRow))
                {

                    Console.WriteLine("please a valid number try again");
                    
                }
                Console.Write("Guess ship position in column :");
                while (!int.TryParse(Console.ReadLine(), out guessCol))
                {

                    Console.WriteLine("please enter a valid number try again");
                    
                }
                


                if ((guessRow < 0 || guessRow > 3) || (guessCol < 0 || guessCol > 3))
                {
                    Console.WriteLine("Oops, that's not even in the ocean.");
                    turn--;
                    
                }
                else if (boardGrids[guessRow, guessCol] == "*")
                {
                    Console.WriteLine("You have already chose this value try another value");
                    
                    turn--;
                }

                else
                {
                    if ((guessRow == firstShip[0] && guessCol == firstShip[1]) || (guessRow == secondShip[0] && guessCol == secondShip[1]))
                    {
                        hitCount++;
                        Console.WriteLine("Right selection");
                        boardGrids[guessRow, guessCol] = "*";

                        if (hitCount == 1)
                        {
                            Console.WriteLine("You sunk First battleship");
                            
                        }
                        else if (hitCount == 2)
                        {
                            Console.WriteLine("You sunk 2nd battleship");
                            PrintBoard(boardGrids);
                            break;
                        }
                    }
                    
                    else
                    {
                        if (boardGrids[guessRow, guessCol] == "X")
                        {
                            Console.WriteLine("You are already select this value try another value");
                            
                            turn--;
                        }
                        else
                        {
                            boardGrids[guessRow, guessCol] = "X";
                            Console.WriteLine("Sorry! You miss battleship");
                            //Console.WriteLine(boardGrids);
                            
                        }

                        
                    }
                

                }
                Console.WriteLine("Turn {0}",turn);
                Console.WriteLine("-------");
                PrintBoard(boardGrids);// non return method(void) if print only call that place

            }

            if (hitCount == 2)
            {
                Console.WriteLine("Congratulation you select two right choise, you win this battle ship");
            }
            else
            {
                Console.WriteLine("Sorry! You loose the battle-ship game");
            }
            
        }
        



    }
}
