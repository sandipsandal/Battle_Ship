using System;
using System.Numerics;

namespace Battle_Ship
{
    
    class Program
    { 
        static void Main(string[] args)
        {

            // print game-board
            Board b = new Board();

            

            //set and get all players name with their poistion
            string[] allPlayersName = b.CreatePlayers();

            for (int i = 0; i < allPlayersName.Length; i++)
            {
                string[,] boardGrid = b.CreateBoard();

                //Console.WriteLine(" Player {0} name :{1}", i+1, allPlayersName[i]);

                string a = b.ChoosePlayer(allPlayersName);

                Console.WriteLine("{0} Start to play game", a);
                b.PrintBoard(boardGrid);

                

                int[] ship1 = b.SetRandomShipPosition(4, 4);
                int[] ship2 = b.SetRandomShipPosition(4, 4);
                while (ship1 == ship2)
                {
                    ship2 = b.SetRandomShipPosition(4, 4);
                }
                for (int ii = 0; ii < ship1.Length; ii++) 
                {

                    Console.WriteLine("1st ship position :{0}", ship1[ii]);
                    Console.WriteLine("2nd ship position :{0}", ship2[ii]);

                }
                b.GameStrategy(ship1, ship2, boardGrid);
            }

            // generate a random number which allow the 1st player play game



            //string a = b.ChoosePlayer(allPlayersName);

            
            Console.ReadLine();
        }
    }
}
