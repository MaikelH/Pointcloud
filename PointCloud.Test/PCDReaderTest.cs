using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PointCloud.io;

namespace PointCloud.Test
{
    [TestFixture]
    public class PCDReaderTest
    {
        [Test]
        public void FileReadVersionTest()
        {
            PCDReader<PointXYZ> reader = new PCDReader<PointXYZ>();

            PCDHeader header = reader.ReadHeader("test.pcd");

            Assert.AreEqual(PCDVersion.PCDv7, header.Version);
        }

        [Test]
        public void FileReadWidthTest()
        {
            PCDReader<PointXYZ> reader = new PCDReader<PointXYZ>();

            PCDHeader header = reader.ReadHeader("test.pcd");

            Assert.AreEqual(213, header.Width);
        }

        [Test]
        public void FileReadHeightTest()
        {
            PCDReader<PointXYZ> reader = new PCDReader<PointXYZ>();

            PCDHeader header = reader.ReadHeader("test.pcd");

            Assert.AreEqual(1, header.Height);
        }

        [Test]
        public void FileReadPointsTest()
        {
            PCDReader<PointXYZ> reader = new PCDReader<PointXYZ>();

            PCDHeader header = reader.ReadHeader("test.pcd");

            Assert.AreEqual(213, header.Points);
        }
    }
}
