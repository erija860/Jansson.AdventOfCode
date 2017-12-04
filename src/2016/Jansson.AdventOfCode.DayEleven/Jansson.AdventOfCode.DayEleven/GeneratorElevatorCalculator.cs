using System;
using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayEleven
{
    public class GeneratorElevatorCalculator
    {
        private List<Floor> _floors;

        public int CalculateMinimumStepsToReachFloor4(List<Floor> floors)
        {
            _floors = floors;

            return 1;
        }

    }

    public class Floor
    {
        private string _floor;
        private bool _hasElevator;
        private string v3;
        private string v4;
        private string v5;
        private string v6;

        public Floor(string floor, string elevator, string v3, string v4, string v5, string v6)
        {
            _floor = floor;
            _hasElevator = elevator=="E";
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }
    }

    public abstract class Generator { }
    public abstract class Microchip { }
}
