using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PointCloud.io
{
    public class PCDReader<T> where T:PointT
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public PointCloud<T> Read(String filename, int offset)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static PointCloud<T> LoadPCDFile(String filename)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the header of PCD file;
        /// </summary>
        /// <param name="Filename">PCD File</param>
        /// <returns>PCDHeader object</returns>
        public PCDHeader ReadHeader(string Filename)
        {
            PCDHeader header = new PCDHeader();

            using (StreamReader sr = new StreamReader(Filename))
            {
                String line = sr.ReadLine();

                // Keep reading until Datasection is found
                while(line != null && !line.Contains("DATA"))
                {
                    if(line.Contains("VERSION"))
                    {
                        header.Version = getVersion(line);
                    }
                    if (line.Contains("WIDTH"))
                    {
                        header.Width = Convert.ToInt32(line.Substring(6));                  
                    }
                    if (line.Contains("HEIGHT"))
                    {
                        header.Height = Convert.ToInt32(line.Substring(7));
                    }

                    line = sr.ReadLine();
                }
            }

            return header;
        }

        private PCDVersion getVersion(String line)
        {
            PCDVersion returnval = PCDVersion.PCDv5;
            string value = new string(line.Skip(8).ToArray());
            if (value == ".7" || value == "0.7")
            {
                returnval = PCDVersion.PCDv7;
            }
            else if (value == ".6")
            {
                returnval = PCDVersion.PCDv6;
            }
            else if (value == ".5" || value == "0.5")
            {
                returnval = PCDVersion.PCDv5;
            }

            return returnval;
        }
    }
}
