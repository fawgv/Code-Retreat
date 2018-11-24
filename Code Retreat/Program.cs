using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using FluentAssertions;

namespace Code_Retreat
{
    public class Program
    {
        static void Main(string[] args)
        {
            var map = new Boolean[30, 30];
            var alivePoints = new HashSet<Point>()
            {
                new Point(3,3),new Point(4,3),new Point(5,3),
                                                            new Point(5,4),new Point(6,4),
                new Point(3,5),new Point(4,5),new Point(5,5)
            };
            
            var game = new GameArea(alivePoints);

            while (true)
            {
                game.NextStep();

                foreach (var point in game.AlivePoints)
                {
                    try
                    {
                        map[point.X, point.Y] = true;
                    }
                    catch
                    {

                    }
                }

                for (var x = 0; x < 30; x++)
                {
                    for (int y = 0; y < 30; y++)
                    {
                        Console.Write(map[x, y] == true ? "X" : " ");
                    }
                    Console.WriteLine();
                }
                    

                //map = new bool[50,50];
                
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }

    [TestFixture]
    public class Test
    {

    }
}
