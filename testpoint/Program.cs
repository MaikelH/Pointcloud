using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PointCloud;
using System.ComponentModel;
using PointCloud.io;

namespace testpoint
{
    class Program
    {
        static void Main(string[] args)
        {

            PCDReader<PointXYZRGBA> reader = new PCDReader<PointXYZRGBA>();
            PointCloud<PointXYZRGBA> cloud = reader.Read("testbin.pcd");


            Console.WriteLine("count:{0},x:{1} Y:{2} Z:{3}, R:{4} G:{5} B:{6} A:{7}", cloud.Points.Count, cloud[0].X, cloud[0].Y, cloud[0].Z,
                cloud[0].R, cloud[0].G, cloud[0].B, cloud[0].A);
            Console.ReadKey();

        }
    }
}
