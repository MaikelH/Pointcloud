using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PointCloud.PointTypes.Converters
{

    struct PointPosColor
    {
        public float x;
        public float y;
        public float z;
        public byte r;
        public byte g;
        public byte b;
        public byte a;
    }

    /// <summary>
    /// Class that converts between PointXYZ objects and string objects.
    /// </summary>
    class PointXYZRGBAConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if(sourceType == typeof(byte[]))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is byte[])
            {
                byte[] bytes = (byte[]) value;
                PointPosColor ppc = (PointPosColor)BytesToStruct(bytes, typeof(PointPosColor));
                return new PointXYZRGBA(ppc.x, ppc.y, ppc.z, ppc.r, ppc.g, ppc.b, ppc.a);
            }

            return base.ConvertFrom(context, culture, value);
        }

        static object BytesToStruct(byte[] bytes, Type strcutType)
        {
            int size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return Marshal.PtrToStructure(buffer, strcutType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        static byte[] StructToBytes(object structObj)
        {
            int size = Marshal.SizeOf(structObj);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structObj, buffer, false);
                byte[] bytes = new byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if(destinationType == typeof(byte[]))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(byte[]))
            {
                PointXYZRGBA point = (PointXYZRGBA)value;
                PointPosColor ppc;
                ppc.x = point.X;
                ppc.y = point.Y;
                ppc.z = point.Z;
                ppc.r = point.R;
                ppc.g = point.G;
                ppc.b = point.B;
                ppc.a = point.A;
                byte[] bytes = StructToBytes(ppc);
                return bytes;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
