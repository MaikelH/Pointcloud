using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace PointCloud.io
{
    public class PCDWriter
    {
        public bool WriteBinData(List<PointXYZRGBA> pointList,string filePathAndName)
        {
            System.IO.FileStream fs = null;
            try
            {
                using (fs = System.IO.File.Create(filePathAndName))
                {
                    BinaryWriter writeInfo = new BinaryWriter(fs);
                    string s = "# .PCD v0.7 - Point Cloud Data file format\n" +
                                    "VERSION 0.7\n" +
                                    "FIELDS x y z rgba\n" +
                                    "SIZE 4 4 4 4\n" +
                                    "TYPE F F F U\n" +
                                    "COUNT 1 1 1 1\n" +
                                    string.Format("WIDTH {0}\n", pointList.Count >> 1) +
                                    "HEIGHT 1\n" +
                                    "VIEWPOINT 0 0 0 1 0 0 0\n" +
                                    string.Format("POINTS {0}\n", pointList.Count >> 1) +
                                    "DATA binary\n";

                    writeInfo.Write(Encoding.ASCII.GetBytes(s));

                    foreach (PointXYZRGBA pointXYZRGBA in pointList)
                    {
                        var bytes =TypeDescriptor.GetConverter(typeof(PointXYZRGBA)).ConvertTo(pointXYZRGBA, typeof(byte[]));
                        writeInfo.Write((byte[])bytes);
                    }

                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
