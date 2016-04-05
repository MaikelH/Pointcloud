/*
Pointcloud library for .NET
Copyright (C) 2013  M. Hofman

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System.ComponentModel;
using NUnit.Framework;

namespace PointCloud.Test
{
    [TestFixture]
    class PointTypeTest
    {
        [Test]
        public void PointConvertFromTest()
        {
            PointXYZ point = (PointXYZ) TypeDescriptor.GetConverter(typeof (PointXYZ)).ConvertFrom("1 2 3");

            Assert.AreEqual(1, point.X);
            Assert.AreEqual(2, point.Y);
            Assert.AreEqual(3, point.Z);
        }

        [Test]
        public void PointConvertToTest()
        {
            PointXYZ point = new PointXYZ(1, 2, 3);

            Assert.AreEqual("1 2 3", TypeDescriptor.GetConverter(point).ConvertTo(point, typeof(string)));
        }

        [Test]
        public void PointRGBAConvertFromTest()
        {

            var bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x5a, 0x24, 0xd7, 0x44, 0xbc, 0x77, 0xfb, 0x43, 0x00, 0x00, 0x80, 0x3f };
            PointXYZRGBA point = (PointXYZRGBA)TypeDescriptor.GetConverter(typeof(PointXYZRGBA)).ConvertFrom(bytes);

            Assert.AreEqual(0, point.X, 0.000001);
            Assert.AreEqual(1721.136, point.Y, 0.000001);
            Assert.AreEqual(502.9354, point.Z, 0.000001);
            Assert.AreEqual(0x00, point.R);
            Assert.AreEqual(0x00, point.G);
            Assert.AreEqual(0x80, point.B);
            Assert.AreEqual(0x3f, point.A);
        }
    }
}
