using AoCHelper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_12 : BaseDay
    {
        private readonly List<KeyValuePair<char, int>> _input;

        public Day_12()
        {
            _input = new List<KeyValuePair<char, int>> { };
            Regex re = new Regex(@"([a-zA-Z]+)(\d+)");

            foreach (var item in File.ReadAllLines(InputFilePath))
            {
                Match result = re.Match(item);
                _input.Add(new KeyValuePair<char, int>(result.Groups[1].Value[0], int.Parse(result.Groups[2].Value)));
            }
        }

        public override string Solve_1()
        {
            int north = 0;
            int east = 0;
            int oreintation = 90;

            foreach (var item in _input)
            {
                switch (item.Key)
                {
                    case 'N':
                        north += item.Value;
                        break;
                    case 'S':
                        north -= item.Value;
                        break;
                    case 'E':
                        east += item.Value;
                        break;
                    case 'W':
                        east -= item.Value;
                        break;
                    case 'L':
                        oreintation = Rotate(oreintation, -item.Value);
                        break;
                    case 'R':
                        oreintation = Rotate(oreintation, item.Value);
                        break;
                    case 'F':
                        switch (oreintation)
                        {
                            case 0:
                                north += item.Value;
                                break;
                            case 90:
                                east += item.Value;
                                break;
                            case 180:
                                north -= item.Value;
                                break;
                            case 270:
                                east -= item.Value;
                                break;
                        }
                        break;
                }
            }
            return (Math.Abs(north) + Math.Abs(east)).ToString();
        }

        public override string Solve_2()
        {
            int northPos = 0;
            int eastPos = 0;
            int northWayPoint = 1;
            int eastWayPoint = 10;

            foreach (var item in _input)
            {
                switch (item.Key)
                {
                    case 'N':
                        northWayPoint += item.Value;
                        break;
                    case 'S':
                        northWayPoint -= item.Value;
                        break;
                    case 'E':
                        eastWayPoint += item.Value;
                        break;
                    case 'W':
                        eastWayPoint -= item.Value;
                        break;
                    case 'L' or 'R':
                        if (item.Value == 180)
                        {
                            northWayPoint *= -1;
                            eastWayPoint *= -1;
                        }
                        else
                        {
                            int swapTemp = northWayPoint;
                            northWayPoint = eastWayPoint;
                            eastWayPoint = swapTemp;
                            switch (item.Key)
                            {
                                case 'L' when item.Value == 90:
                                case 'R' when item.Value == 270:
                                    eastWayPoint *= -1;
                                    break;
                                default:
                                    northWayPoint *= -1;
                                    break;
                            }
                        }
                        break;
                    case 'F':

                        northPos += (northWayPoint * item.Value);
                        eastPos += (eastWayPoint * item.Value);
                        break;
                }
            }
            return (Math.Abs(northPos) + Math.Abs(eastPos)).ToString();
        }

        public static int Rotate(int orientation, int degrees)
        {
            orientation = (orientation + degrees) % 360;
            if (orientation < 0) orientation += 360;
            return orientation;
        }

    }

}


