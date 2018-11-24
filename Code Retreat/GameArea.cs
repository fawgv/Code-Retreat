using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Code_Retreat
{
    public class GameArea
    {
        public HashSet<Point> AlivePoints = new HashSet<Point>();
        private HashSet<Point> AllNeighboursPoints = new HashSet<Point>();

        public GameArea(HashSet<Point> alivePoints)
        {
            AlivePoints = alivePoints;
        }

        public void NextStep()
        {
            FillAllNeighboursPoints();
            HashSet<Point> newAlivePoints = new HashSet<Point>();
            foreach (var point in AllNeighboursPoints)
            {
                var neighboursCount = GetAlivePointsInNeighbours(point);
                if (VerifyIfAlive(neighboursCount, point))
                {
                    newAlivePoints.Add(point);
                }
            }

            AlivePoints = newAlivePoints;
        }

        private bool VerifyIfAlive(int aliveNPointsCount, Point point)
        {
            if (aliveNPointsCount < 2)
                return false;
            else if (aliveNPointsCount > 3)
                return false;
            else if (aliveNPointsCount == 3)
                return true;
            return AlivePoints.Contains(point);
        }

        private void FillAllNeighboursPoints()
        {
            foreach (var alivePoint in AlivePoints)
            {
                for (int x = alivePoint.X - 1; x <= alivePoint.X + 1; x++)
                {
                    for (int y = alivePoint.Y - 1; y <= alivePoint.Y + 1; y++)
                    {
                        AllNeighboursPoints.Add(new Point(x, y));
                    }
                }
            }
        }

        private int GetAlivePointsInNeighbours(Point point)
        {
            int result = 0;
            var aliveWithoutPoint = AlivePoints.Where(point1 => point != point1).Select(point1 => point1);
            for (int x = point.X - 1; x <= point.X + 1; x++)
            {
                for (int y = point.Y - 1; y <= point.Y + 1; y++)
                {
                    if (VerifyPointInAlivePoints(new Point(x, y),aliveWithoutPoint))
                    {
                        result++;
                    }
                }
            }


            return result;
        }

        private bool VerifyPointInAlivePoints(Point point, IEnumerable<Point> alivePoints)
        {
            bool result = false;
            foreach (var alivePoint in alivePoints)
            {
                if (alivePoint.X == point.X && alivePoint.Y == point.Y)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}