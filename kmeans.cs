using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CeAI
{
    class Point
    {
        public double x;
        public double y;
        public int center;
        public int numPointsInCluster;

        public Point(double px, double py)
        {
            x = px;
            y = py;
            center = -1;
        }
    }

    class KMeans
    {
        private List<Point> _data = null;

        public void LoadData()
        {
            char[] delimiterXY = new char[] { ' ' };
            char[] delimieterLine = new char[] { '\n' };
            string[] data = File.ReadAllText(@"c:\Users\Kubo\Documents\data.txt").Split(delimieterLine);
            _data = new List<Point>(data.Count());
            
            foreach (string line in data)
            {
                string[] stringCoords = line.Split(delimiterXY);
                if(stringCoords.Count() == 2)
                    _data.Add(new Point(double.Parse(stringCoords[0], System.Globalization.CultureInfo.InvariantCulture), double.Parse(stringCoords[1], System.Globalization.CultureInfo.InvariantCulture)));
            }
        }

        public List<Point> Run(int numOfClusters, int steps)
        {
            List<Point> centers = new List<Point>(numOfClusters);
            List<Point> newCenters = new List<Point>(numOfClusters); ;

            // todo: random init, now: first points
            for (int k = 0; k < numOfClusters; k++)
                centers.Add(_data[k]);

            for (int s = 0; s < steps; s++)
            {
                newCenters.Clear();
                for (int k = 0; k < numOfClusters; k++)
                    newCenters.Add(new Point(0, 0));

                for (int p = 0; p < _data.Count; p++)
                {
                    double prevDistance = double.MaxValue;
                    for (int k = 0; k < numOfClusters; k++)
                    {
                        double distance = Math.Pow(_data[p].x - centers[k].x, 2) + Math.Pow(_data[p].y - centers[k].y, 2);
                        if (distance < prevDistance)
                        {
                            _data[p].center = k;
                            prevDistance = distance;
                        }
                    }

                    newCenters[_data[p].center].x += _data[p].x;
                    newCenters[_data[p].center].y += _data[p].y;

                    // according to cluster, increment counter
                }

                // divide cluster positions by counts

                // set new positions of centers

                // if positions of centers dont change then break
            }

        }
    }
}