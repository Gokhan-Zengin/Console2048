using System;
using System.Linq;

namespace _2048ConsoleGame
{
    class Program
    {

        #region lanes
        static int[]

        Lane1 = new int[4]{
        0   , 0  , 0  , 0
        },
        Lane2 = new int[4]{
        0   , 0  , 0  , 0
        },
        Lane3 = new int[4]{
        0   , 0  , 0  , 0
        },
        Lane4 = new int[4]{
        0   , 0  , 0  , 0
        };

        static int[][] allLanes = new int[][]{
            Lane1,
            Lane2,
            Lane3,
            Lane4
        };
        #endregion

        static bool gameRunning = true;
        static int score;

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            setRandom();
            setRandom();
            Render();
            while (gameRunning)
            {
                if (score == 2048) break;
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow: Move(0); break;
                        case ConsoleKey.LeftArrow: Move(1); break;
                        case ConsoleKey.UpArrow: Move(2); break;
                        case ConsoleKey.DownArrow: Move(3); break;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("Score : " + score);
            Console.ReadKey();
        }

        //set a random block to 2
        static void setRandom()
        {
            int numberCountExeptZeros = 0;
            allLanes.ToList().ForEach(z =>
            {
                numberCountExeptZeros += z.Count(c => c != 0);
            });
            if (numberCountExeptZeros == 16) return;
            Random rand = new Random();
            while (true)
            {
                int random1 = rand.Next(4);
                int random2 = rand.Next(4);
                if (allLanes[random1][random2] == 0) { allLanes[random1][random2] = 2; break; }
            }
        }

        //shift blocks
        static void Move(int direction)
        {//right : 0, left : 1, up : 2, down : 3
            switch (direction)
            {
                case 0://right
                    {
                        foreach (var lane in allLanes)
                        {
                            for (int i = 2; i >= 0; i--)
                            {
                                if (lane[i] == 0) continue;
                                for (int a = i + 1; a < 4; a++)
                                {
                                    if (lane[a] == 0)
                                        if (a != 3)
                                            continue;
                                        else
                                        {
                                            lane[a] = lane[i];
                                            lane[i] = 0;
                                            break;
                                        }
                                    if (lane[i] == lane[a])
                                    {
                                        lane[a] *= 2;
                                        if (lane[a] > score) score = lane[a];
                                        lane[i] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        if (a - 1 != i)
                                        {
                                            lane[a - 1] = lane[i];
                                            lane[i] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 1://left
                    {
                        foreach (var lane in allLanes)
                        {
                            for (int i = 1; i <= 3; i++)
                            {
                                if (lane[i] == 0) continue;
                                for (int a = i - 1; a >= 0; a--)
                                {
                                    if (lane[a] == 0)
                                        if (a != 0)
                                            continue;
                                        else
                                        {
                                            lane[a] = lane[i];
                                            lane[i] = 0;
                                            break;
                                        }
                                    if (lane[i] == lane[a])
                                    {
                                        lane[a] *= 2;
                                        if (lane[a] > score) score = lane[a];
                                        lane[i] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        if (lane[a + 1] != lane[i])
                                        {
                                            lane[a + 1] = lane[i];
                                            lane[i] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 2://up
                    {
                        for (int collumindex = 0; collumindex < 4; collumindex++)
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (allLanes[i][collumindex] == 0) continue;
                                for (int a = i - 1; a >= 0; a--)
                                {
                                    if (allLanes[a][collumindex] == 0)
                                        if (a != 0)
                                            continue;
                                        else
                                        {
                                            allLanes[a][collumindex] = allLanes[i][collumindex];
                                            allLanes[i][collumindex] = 0;
                                            break;
                                        }
                                    if (allLanes[a][collumindex] == allLanes[i][collumindex])
                                    {
                                        allLanes[a][collumindex] *= 2;
                                        if (allLanes[a][collumindex] > score) score = allLanes[a][collumindex];
                                        allLanes[i][collumindex] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        if (allLanes[a + 1][collumindex] != allLanes[i][collumindex])
                                        {
                                            allLanes[a + 1][collumindex] = allLanes[i][collumindex];
                                            allLanes[i][collumindex] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 3://down
                    {
                        for (int collumindex = 0; collumindex < 4; collumindex++)
                        {
                            for (int i = 2; i >= 0; i--)
                            {
                                if (allLanes[i][collumindex] == 0) continue;
                                for (int a = i + 1; a < 4; a++)
                                {
                                    if (allLanes[a][collumindex] == 0)
                                        if (a != 3)
                                            continue;
                                        else
                                        {
                                            allLanes[a][collumindex] = allLanes[i][collumindex];
                                            allLanes[i][collumindex] = 0;
                                            break;
                                        }
                                    if (allLanes[i][collumindex] == allLanes[a][collumindex])
                                    {
                                        allLanes[a][collumindex] *= 2;
                                        if (allLanes[a][collumindex] > score) score = allLanes[a][collumindex];
                                        allLanes[i][collumindex] = 0;
                                        break;
                                    }
                                    else
                                    {
                                        if (allLanes[a - 1][collumindex] != allLanes[i][collumindex])
                                        {
                                            allLanes[a - 1][collumindex] = allLanes[i][collumindex];
                                            allLanes[i][collumindex] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
            }
            if (isGameOver())
            {
                gameRunning = false;
                return;
            }
            setRandom();
            Render();
        }

        //check game over
        static bool isGameOver()
        {
            int numberCountExeptZeros = 0;
            allLanes.ToList().ForEach(z =>
            {
                numberCountExeptZeros += z.Count(c => c != 0);
            });
            if (numberCountExeptZeros != 16) return false;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    int[] Neighbors = new int[]{
                        x == 0 ? 0 : allLanes[y][x -1],
                        x == 3 ? 0 : allLanes[y][x +1],
                        y == 0 ? 0 : allLanes[y - 1][x],
                        y == 3 ? 0 : allLanes[y + 1][x]
                    };
                    foreach (var a in Neighbors)
                    {
                        if (a == allLanes[y][x]) return false;
                    }

                }
            }
            return true;
        }

        //displaying everything
        static void Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*------*------*------*------*");
            foreach (var lane in allLanes)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("|      |      |      |      |");
                Console.Write("|");
                foreach (var a in lane)
                {
                    if (a != 0)
                        switch (Math.Floor(Math.Log10(a) + 1))
                        {
                            case 1:
                                Console.ForegroundColor = (ConsoleColor)Math.Floor(Math.Log2(a)) + 1;
                                Console.Write("  " + a + "   ");
                                break;
                            case 2:
                                Console.ForegroundColor = (ConsoleColor)Math.Floor(Math.Log2(a)) + 1;
                                Console.Write("  " + a + "  ");
                                break;
                            case 3:
                                Console.ForegroundColor = (ConsoleColor)Math.Floor(Math.Log2(a)) + 1;
                                Console.Write("  " + a + " ");
                                break;
                            case 4:
                                Console.ForegroundColor = (ConsoleColor)Math.Floor(Math.Log2(a)) + 1;
                                Console.Write(" " + a + " ");
                                break;
                        }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("      ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.NewLine);
                Console.WriteLine("|      |      |      |      |");
                Console.WriteLine("*------*------*------*------*");
            }
        }
    }
}

