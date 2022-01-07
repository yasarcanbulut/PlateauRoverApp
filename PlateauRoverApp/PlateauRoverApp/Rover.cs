using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauRoverApp
{
    public class Rover
    {
        public Coordinate Coordinates { get; private set; }
        public string RoverDirection { get; set; }
        public Rover(Coordinate coordinates, string direction)
        {
            this.Coordinates = coordinates;
            this.RoverDirection = direction;
        }

        public bool MoveForward(PlateauCoordinates plateauCoordinates)
        {
            switch (RoverDirection)
            {
                case DirectionConst.East:
                    return ForwardEast(plateauCoordinates);
                case DirectionConst.West:
                    return ForwardWest(plateauCoordinates);
                case DirectionConst.South:
                    return ForwardSouth(plateauCoordinates);
                case DirectionConst.North:
                    return ForwardNorth(plateauCoordinates);
            }

            if (!CheckRoverLimits(plateauCoordinates))
                return false;

            Coordinates.X = Coordinates.X + 1;
            return true;
        }

        public void TurnLeft()
        {
            switch (RoverDirection)
            {
                case DirectionConst.East:
                    RoverDirection = DirectionConst.North;
                    break;
                case DirectionConst.West:
                    RoverDirection = DirectionConst.South;
                    break;
                case DirectionConst.South:
                    RoverDirection = DirectionConst.East;
                    break;
                case DirectionConst.North:
                    RoverDirection = DirectionConst.West;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (RoverDirection)
            {
                case DirectionConst.East:
                    RoverDirection = DirectionConst.South;
                    break;
                case DirectionConst.West:
                    RoverDirection = DirectionConst.North;
                    break;
                case DirectionConst.South:
                    RoverDirection = DirectionConst.West;
                    break;
                case DirectionConst.North:
                    RoverDirection = DirectionConst.East;
                    break;
            }
        }

        public bool ForwardEast(PlateauCoordinates plateauCoordinates)
        {
            if (plateauCoordinates.xMax == Coordinates.X)
                return false;

            Coordinates.X = Coordinates.X + 1;
            return true;
        }

        public bool ForwardWest(PlateauCoordinates plateauCoordinates)
        {
            if (plateauCoordinates.xMin == Coordinates.X)
                return false;

            Coordinates.X = Coordinates.X - 1;
            return true;
        }

        public bool ForwardSouth(PlateauCoordinates plateauCoordinates)
        {
            if (plateauCoordinates.yMin == Coordinates.Y)
                return false;

            Coordinates.Y = Coordinates.Y - 1;
            return true;
        }

        public bool ForwardNorth(PlateauCoordinates plateauCoordinates)
        {
            if (plateauCoordinates.yMax == Coordinates.Y)
                return false;

            Coordinates.Y = Coordinates.Y + 1;
            return true;
        }

        public bool CheckRoverLimits(PlateauCoordinates plateauCoordinates)
        {
            if (plateauCoordinates.xMax == Coordinates.X)
                return false;

            return true;
        }

        public string GetLocation()
        {
            return this.Coordinates.X + " " + this.Coordinates.Y + " " + RoverDirection;
        }

        public Coordinate GetCoordinates()
        {
            return this.Coordinates;
        }
    }
}
