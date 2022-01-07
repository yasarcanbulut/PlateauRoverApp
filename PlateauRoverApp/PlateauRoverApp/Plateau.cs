using System;
using System.Collections.Generic;
using System.Text;

namespace PlateauRoverApp
{
    public class Plateau
    {
        public PlateauCoordinates plateauCoordinates { get; set; }
        public Rover Rover { get; private set; }
        public Plateau(int xMax, int yMax)
        {
            plateauCoordinates = new PlateauCoordinates(xMax, yMax);
        }

        public bool LocateRover(Rover rover)
        {
            this.Rover = rover;
            return CheckPlatueLimits(rover);
        }

        public bool MoveRover(string command)
        {
            switch (command)
            {
                case CommandsConst.Move:
                    return Rover.MoveForward(plateauCoordinates);
                case CommandsConst.TurnLeft:
                    Rover.TurnLeft();
                    return true;
                case CommandsConst.TurnRight:
                    Rover.TurnRight();
                    return true;
            }
            return true;
        }

        public bool CheckPlatueLimits(Rover rover)
        {
            if (rover.GetCoordinates().X > this.plateauCoordinates.xMax)
                return false;
            if (rover.GetCoordinates().Y > this.plateauCoordinates.yMax)
                return false;
            if (rover.GetCoordinates().X < this.plateauCoordinates.xMin)
                return false;
            if (rover.GetCoordinates().Y < this.plateauCoordinates.yMin)
                return false;

            return true;
        }
    }
}
