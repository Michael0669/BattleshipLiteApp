using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;


namespace BattleShipLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            PlayerInfoModel activePlayer = CreatePlayer("Player 1");
            PlayerInfoModel opponent = CreatePlayer("Player 2");

            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship Lite!");
            Console.WriteLine("Created by Mike Hampshire");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"Player information for {playerTitle}");

            //Ask for users name
            output.UsersName = AskForUsersName();

            //Load up shot grid
            GameLogic.InitializeGrid(output);

            //Ask the user for their 5 ship placements
            PlaceShips(output);

            //Clear
            Console.Clear();

            return output;
        }

        private static string AskForUsersName()
        {
            Console.Write("What is your name: ");
            string output = Console.ReadLine();

            return output;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Where do you want to place ship number {model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(model, location);

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again");
                }
            } while (model.ShipLocations.Count < 5);
        }

        private static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if(gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if(gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($"{gridSpot.SpotLetter}{gridSpot.SpotNumber}");
                }
            }
        }
    }
}
