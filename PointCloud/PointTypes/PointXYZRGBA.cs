using System.ComponentModel;
using PointCloud.PointTypes.Converters;

namespace PointCloud
{
    [TypeConverter(typeof(PointXYZRGBAConverter))]
    public class PointXYZRGBA : PointXYZ
    {
        public PointXYZRGBA() : base()
        {
            R = 0;
            G = 0;
            B = 0;
            A = 0;
        }

        public PointXYZRGBA(float x, float y, float z, int r, int g, int b, int a)
            : base(x, y, z)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            A = (byte)a;
        }

        public PointXYZRGBA(float x, float y, float z, byte r, byte g, byte b, byte a)
            : base(x, y, z)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }
    }
}
