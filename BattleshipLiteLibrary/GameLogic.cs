using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLiteLibrary.Models;

namespace BattleshipLiteLibrary
{
    public static class GameLogic
    {
        public static void InitializeGrid(PlayerInfoModel model)
        {
            List<string> letters = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E"
            };

            List<int> numbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }
            }
        }

        private static void AddGridSpot(PlayerInfoModel model, string letters, int number)
        {
            GridSpotModel spot = new GridSpotModel();
            spot.SpotLetter = letters;
            spot.SpotNumber = number;
            spot.Status = GridSpotStatus.Empty;

            model.ShotGrid.Add(spot);
        }

        public static bool PlaceShip(PlayerInfoModel model, string location)
        {
            throw new NotImplementedException();
        }
    }
}
