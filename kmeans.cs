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
        double x;
        double y;

        public Point(double px, double py)
        {
            x = px;
            y = py;
        }
    }

    static class KMeans
    {


        public static void LoadData()
        {
            char[] delimiterXY = new char[] { ' ' };
            char[] delimieterLine = new char[] { '\n' };
            string[] data = File.ReadAllText(@"c:\Users\Kubo\Documents\data.txt").Split(delimieterLine);
            List<Point> points = new List<Point>(data.Count());
            

            foreach (string line in data)
            {
                string[] stringCoords = line.Split(delimiterXY);
                if(stringCoords.Count() == 2)
                    points.Add(new Point(double.Parse(stringCoords[0], System.Globalization.CultureInfo.InvariantCulture), double.Parse(stringCoords[1], System.Globalization.CultureInfo.InvariantCulture)));
            }
        }
    }
}