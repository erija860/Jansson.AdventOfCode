using System;
using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayOne
{
    public class PathCalculator
    {
        private Direction _direction;
        private Point _position;
        public List<List<string>> Directions;
        public List<Point> DuplicatedPointsHistoryList = new List<Point>();
        public List<Point> PointsHistoryList = new List<Point>();

        public int CalculateDistanceBetweenStartAndFinish(string directions)
        {
            Directions = InputParser.ParseInput(directions);
            GoToEnd();
            return Math.Abs(_position.X) + Math.Abs(_position.Y);
        }

        public int GetFirstDuplicatedPosition()
            => Math.Abs(DuplicatedPointsHistoryList[0].X) + Math.Abs(DuplicatedPointsHistoryList[0].Y);

        public void GoToEnd()
        {
            _position = new Point { X = 0, Y = 0 };
            _direction = Direction.North;

            foreach (var direction in Directions)
            {
                if (direction[0].Equals("R"))
                    TurnRight();
                if (direction[0].Equals("L"))
                    TurnLeft();
                Walk(int.Parse(direction[1]));
            }
        }

        private void Walk(int i)
        {
            if (_direction == Direction.North)
                for (var j = 0; j < i; j++)
                {
                    PointsHistoryList.Add(new Point { X = _position.X, Y = _position.Y });
                    _position.Y++;
                    CheckForDuplicatedPoint();
                }

            if (_direction == Direction.West)
                for (var j = 0; j < i; j++)
                {
                    PointsHistoryList.Add(new Point { X = _position.X, Y = _position.Y });

                    _position.X--;
                    CheckForDuplicatedPoint();
                }
            if (_direction == Direction.South)
                for (var j = 0; j < i; j++)
                {
                    _position.Y--;
                    CheckForDuplicatedPoint();
                }
            if (_direction != Direction.East) return;
            {
                for (var j = 0; j < i; j++)
                {
                    PointsHistoryList.Add(new Point { X = _position.X, Y = _position.Y });

                    _position.X++;
                    CheckForDuplicatedPoint();
                }
            }
        }

        private void CheckForDuplicatedPoint()
        {
            foreach (var point in PointsHistoryList)
                if ((point.X == _position.X) && (point.Y == _position.Y))
                    DuplicatedPointsHistoryList.Add(new Point { X = _position.X, Y = _position.Y });
        }

        private void TurnLeft()
        {
            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.West;
                    break;
                case Direction.West:
                    _direction = Direction.South;
                    break;
                case Direction.South:
                    _direction = Direction.East;
                    break;
                case Direction.East:
                    _direction = Direction.North;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.East;
                    break;
                case Direction.East:
                    _direction = Direction.South;
                    break;
                case Direction.South:
                    _direction = Direction.West;
                    break;
                case Direction.West:
                    _direction = Direction.North;
                    break;
            }
        }
    }
}