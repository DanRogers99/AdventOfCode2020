using AoCHelper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_11 : BaseDay
    {
        private List<List<char>> _inputList;
        public Day_11()
        {
            _inputList = File.ReadAllText(InputFilePath).Split("\n").Select(line => line.ToCharList()).ToList();
        }

        public override string Solve_1()
        {
            while (true)
            {
                var previous = (_inputList.Select(item => item.Select(book => book).ToList())).ToList();
                var change = false;

                for (int i = 0; i < _inputList.Count; i++)
                {
                    for (int j = 0; j < _inputList[i].Count; j++)
                    {
                        List<bool> d = FindToEndOfRow(i, j, previous, true);

                        if (_inputList[i][j] == '#')
                        {
                            if (d.Where(x => x).Count() >= 4)
                            {
                                _inputList[i][j] = 'L';
                                change = true;

                            }
                        }
                        else if (_inputList[i][j] == 'L')
                        {
                            if (!d.Where(x => x).Any())
                            {
                                _inputList[i][j] = '#';
                                change = true;

                            }
                        }
                    }
                }

                if (change == false)
                {
                    int count = 0;
                    foreach (var item in _inputList)
                    {
                        count += item.Where(x => x == '#').Count();
                    }

                    return count.ToString();
                }
            }

            throw new SolvingException();
        }

        public override string Solve_2()
        {
            _inputList = File.ReadAllText(InputFilePath).Split("\n").Select(line => line.ToCharList()).ToList();

            while (true)
            {
                var previous = (_inputList.Select(item => item.Select(book => book).ToList())).ToList();
                var change = false;

                for (int i = 0; i < _inputList.Count; i++)
                {

                    for (int j = 0; j < _inputList[i].Count; j++)
                    {

                        List<bool> d = FindToEndOfRow(i, j, previous, false);

                        if (_inputList[i][j] == '#')
                        {
                            if (d.Where(x => x).Count() >= 5)
                            {
                                _inputList[i][j] = 'L';
                                change = true;
                            }
                        }
                        else if (_inputList[i][j] == 'L')
                        {
                            if (!d.Where(x => x).Any())
                            {
                                _inputList[i][j] = '#';
                                change = true;
                            }
                        }
                    }
                }

                if (change == false)
                {
                    int count = 0;
                    foreach (var item in _inputList)
                    {
                        count += item.Where(x => x == '#').Count();
                    }

                    return count.ToString();
                }
            }

            throw new SolvingException();
        }

      
        private List<bool> FindToEndOfRow(int i, int j, List<List<char>> previous, bool immediate)
        {
            var seats = new List<bool>();
            int tempj = j;
            //Left
            while (tempj >= 1)
            {
                if (previous[i][tempj - 1] == 'L')
                {
                    break;
                }

                if (previous[i][tempj - 1] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempj--;
                }

                if (immediate)
                {
                    break;
                }
            }


            //Right
            tempj = j;
            while (tempj + 1 < _inputList[i].Count)
            {
                if (previous[i][tempj + 1] == 'L')
                {
                    break;
                }

                if (previous[i][tempj + 1] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempj++;
                }

                if (immediate)
                {
                    break;
                }
            }

            //Front
            int tempi = i;
            while (tempi >= 1)
            {
                if (previous[tempi - 1][j] == 'L')
                {
                    break;
                }

                if (previous[tempi - 1][j] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempi--;
                }

                if (immediate)
                {
                    break;
                }
            }

            tempj = j;
            tempi = i;
            while (tempi >= 1 && tempj >= 1)
            {
                if (previous[tempi - 1][tempj - 1] == 'L')
                {
                    break;
                }

                if (previous[tempi - 1][tempj - 1] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempj--;
                    tempi--;
                }

                if (immediate)
                {
                    break;
                }
            }

            tempj = j;
            tempi = i;
            while (tempi >= 1 && tempj + 1 < previous[tempi].Count)
            {
                if (previous[tempi - 1][tempj + 1] == 'L')
                {
                    break;
                }

                if (previous[tempi - 1][tempj + 1] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempi--;
                    tempj++;
                }

                if (immediate)
                {
                    break;
                }
            }

            //Back
            tempi = i;
            while (_inputList.Count > tempi + 1)
            {
                if (previous[tempi + 1][j] == 'L')
                {
                    break;
                }

                if (previous[tempi + 1][j] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempi++;
                }

                if (immediate)
                {
                    break;
                }
            }


            tempj = j;
            tempi = i;
            while (_inputList.Count > tempi + 1 && tempj >= 1)
            {
                if (previous[tempi + 1][tempj - 1] == 'L')
                {
                    break;
                }

                if (previous[tempi + 1][tempj - 1] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempi++;
                    tempj--;
                }

                if (immediate)
                {
                    break;
                }

            }

            tempj = j;
            tempi = i;
            while (_inputList.Count > tempi + 1 && tempj + 1 < previous[tempi].Count)
            {
                if (previous[tempi + 1][tempj + 1] == 'L')
                {
                    break;
                }

                if (previous[tempi + 1][tempj + 1] == '#')
                {
                    seats.Add(true);
                    break;
                }
                else
                {
                    tempi++;
                    tempj++;
                }

                if (immediate)
                {
                    break;
                }
            }

            return seats;
        }
    }

}


