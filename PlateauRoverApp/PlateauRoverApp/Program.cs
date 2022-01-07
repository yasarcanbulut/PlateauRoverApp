using System;
using System.Linq;

namespace PlateauRoverApp
{
    class Program
    {
        static void Main()
        {
            Plateau plateau = CreatePlateau();

            if (plateau != null)
                LocateRoverOnPlateu(plateau);

            #region Create Plateau Again

            if (CheckDoItAgain("Enter 'Y' to create plateau again?"))
                Main();

            #endregion
        }

        static Plateau CreatePlateau()
        {
            Console.WriteLine("Enter the plateau limits");
            var plateauLimits = Console.ReadLine();

            if (CheckCreatePlateauCommand(plateauLimits))
            {
                var limits = plateauLimits.Split(" ");
                var xLimit = int.Parse(limits[0]);
                var yLimit = int.Parse(limits[1]);
                Plateau plateau = new Plateau(xLimit, yLimit);
                return plateau;
            }
            else
            {
                Console.WriteLine("Wrong command!");
            }
            return null;
        }

        static void LocateRoverOnPlateu(Plateau plateau)
        {
            Console.WriteLine("Locate Rover on the plateau");
            var positionAndDirection = Console.ReadLine();

            if (CheckLocateRoverCommand(positionAndDirection))
            {
                var pieces = positionAndDirection.Split(" ");

                var isLocated = plateau.LocateRover(new Rover(new Coordinate(int.Parse(pieces[0]), int.Parse(pieces[1])), pieces[2]));

                if (isLocated)
                    MoveRover(plateau);
                else
                    Console.WriteLine("Out of plateau limits!");
            }
            else
            {
                Console.WriteLine("Wrong command!");
            }

            #region Locate Rover Again

            if (CheckDoItAgain("Enter 'Y' to locate rover again?"))
                LocateRoverOnPlateu(plateau);

            #endregion
        }

        static void MoveRover(Plateau plateau)
        {
            Console.WriteLine("Move the rover..");
            var commands = Console.ReadLine();

            if (CheckMoveRoverCommand(commands))
            {
                foreach (var item in commands.ToList())
                {
                    var canMove = plateau.MoveRover(item.ToString());
                    
                    if (!canMove)
                    {
                        Console.WriteLine("Rover on the plateau limits. Can't move!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong command!");
            }

            Console.WriteLine("Rover Location");
            Console.WriteLine(plateau.Rover.GetLocation());

            #region Move Rover Again

            if (CheckDoItAgain("Enter 'Y' to move rover again?"))
                MoveRover(plateau);

            #endregion
        }

        #region Check Functions

        static bool CheckDoItAgain(string Message)
        {
            Console.WriteLine(Message);
            var command = Console.ReadLine();

            if (command == "Y")
                return true;

            return false;
        }

        static bool CheckCreatePlateauCommand(string command)
        {
            var commandDetails = command.Split(" ");
            if (commandDetails.Length != 2)
                return false;

            var isNumeric = int.TryParse(commandDetails[0].ToString(), out _);

            if (!isNumeric)
                return false;

            isNumeric = int.TryParse(commandDetails[1].ToString(), out _);

            if (!isNumeric)
                return false;

            return true;
        }

        static bool CheckLocateRoverCommand(string command)
        {
            var commandDetails = command.Split(" ");
            if (commandDetails.Length != 3)
                return false;

            var isNumeric = int.TryParse(commandDetails[0].ToString(), out _);

            if (!isNumeric)
                return false;

            isNumeric = int.TryParse(commandDetails[1].ToString(), out _);

            if (!isNumeric)
                return false;

            return CheckCommandContainsWrongChar(commandDetails[2].ToString(), "EWSN");
        }

        static bool CheckMoveRoverCommand(string command)
        {
            return CheckCommandContainsWrongChar(command, "LRM");
        }

        static bool CheckCommandContainsWrongChar(string command, string allowableLetters)
        {
            foreach (char c in command)
            {
                if (!allowableLetters.Contains(c.ToString()))
                    return false;
            }

            return true;
        }

        #endregion
    }
}
