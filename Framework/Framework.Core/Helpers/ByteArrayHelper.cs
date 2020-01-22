﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework.Core.Helpers
{
    public static class ByteArrayHelper
    {
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        public static T ByteArrayToObject<T>(byte[] arrBytes)
        {
            var obj = ByteArrayToObject(arrBytes);
            return (T)obj;
        }
    }
}