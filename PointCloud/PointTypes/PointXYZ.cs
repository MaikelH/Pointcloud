using System.ComponentModel;
using PointCloud.PointTypes.Converters;

namespace PointCloud
{
    [TypeConverter(typeof(PointXYZConverter))]
    public class PointXYZ : PointXY
    {
        public PointXYZ() : base()
        {
            Z = 0;
        }

        public PointXYZ(double x, double y, double z) : base(x, y)
        {
            Z = z;
        }

        public double Z { get; set; }
    }
}
