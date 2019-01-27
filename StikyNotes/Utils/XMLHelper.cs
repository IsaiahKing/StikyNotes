﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace StikyNotes
{
    public static class XMLHelper
    {
        /// <summary>
        /// 将对象序列化为指定的文件名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveObjAsXml<T>(T obj,string fileName)
        {
            
                FileStream fs = new FileStream(fileName, FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(fs, obj);
                fs.Close();
                
                return true;


           
           
            
        }

        /// <summary>
        /// 将xml文件进行反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T DecodeXML<T>(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                T obj = (T)xs.Deserialize(fs);
                return obj;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
            
        }
    }
}