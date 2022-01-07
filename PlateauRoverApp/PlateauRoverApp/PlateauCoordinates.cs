using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateauRoverApp
{
    public class PlateauCoordinates
    {
        public int xMax { get; set; }
        public int xMin { get; set; }
        public int yMax { get; set; }
        public int yMin { get; set; }

        public PlateauCoordinates(int x, int y)
        {
            this.xMax = x;
            this.yMax = y;
            this.xMin = 0;
            this.yMin = 0;
        }
    }
}
