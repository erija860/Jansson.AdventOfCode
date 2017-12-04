using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Jansson.AdventOfCode._2017.Day3
{
    public class SpiralMemory
    {
        public int CalculateMinStepsToAccessPort(int square)
        {
            var result = CalculateSquareForInputNumber(square);
            var steps = Math.Abs(result.X) + Math.Abs(result.Y);
            return steps;
        }

        private Square CalculateSquareForInputNumber(int squareNumber)
        {
            var maxY = 0;
            var maxX = 0;

            var minY = 0;
            var minX = 0;

            var currentSquare = new Square {X = 0, Y = 0};

            if (squareNumber == 1)
                return currentSquare;

            currentSquare.X++;

            for (var i = 2; i < squareNumber; i++)
            {
                if (currentSquare.X > maxX && maxY >= currentSquare.Y)
                {
                    currentSquare.Y++;
                    if (currentSquare.Y == maxY)
                        minY--;
                }
                else if (currentSquare.Y > maxY && minX <= currentSquare.X)
                {
                    currentSquare.X--;
                    if (currentSquare.X == minX)
                        maxX++;
                }
                else if (currentSquare.X < minX && minY <= currentSquare.Y)
                {
                    currentSquare.Y--;
                    if (currentSquare.Y == minY)
                    {
                        maxY++;
                    }
                }
                else if (currentSquare.Y < minY && maxX >= currentSquare.X)
                {
                    currentSquare.X++;
                    if (currentSquare.X == maxX)
                    {
                        minX--;
                    }
                }
            }

            return currentSquare;
        }

        public int GetFirstValueHigherThanInput(int input)
        {
            var maxY = 0;
            var maxX = 0;

            var minY = 0;
            var minX = 0;

            var squares = new List<Square>();

            var currentSquare = new Square {X = 0, Y = 0, Value = 1};

            squares.Add(new Square
            {
                X = currentSquare.X,
                Y = currentSquare.Y,
                Value = currentSquare.Value
            });

            currentSquare.X++;

            while (true)
            {
                squares.Add(new Square
                {
                    X = currentSquare.X,
                    Y = currentSquare.Y,
                    Value = currentSquare.CalculateAndSetValue(squares)
                });

                if (currentSquare.Value > input)
                    return currentSquare.Value;

                if (currentSquare.X > maxX && maxY >= currentSquare.Y)
                {
                    currentSquare.Y++;
                    if (currentSquare.Y == maxY)
                        minY--;
                }
                else if (currentSquare.Y > maxY && minX <= currentSquare.X)
                {
                    currentSquare.X--;
                    if (currentSquare.X == minX)
                        maxX++;
                }
                else if (currentSquare.X < minX && minY <= currentSquare.Y)
                {
                    currentSquare.Y--;
                    if (currentSquare.Y == minY)
                    {
                        maxY++;
                    }
                }
                else if (currentSquare.Y < minY && maxX >= currentSquare.X)
                {
                    currentSquare.X++;
                    if (currentSquare.X == maxX)
                    {
                        minX--;
                    }
                }
            }
        }
    }
}