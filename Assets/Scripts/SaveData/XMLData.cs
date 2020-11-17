﻿using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class XMLData : ISaveData<SavedData>
    {

        XmlSerializer formatter = new XmlSerializer(typeof(SavedData[]));

        public void Save(string path = null, params SavedData[] savingObjects)
        {

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, savingObjects);
            }

            //var xmlDoc = new XmlDocument();

            //for (int i = 0; i < savingObjects.Length; i++)
            //{
            //XmlNode node = xmlDoc.CreateElement("Object");
            //xmlDoc.AppendChild(node);

            //var element = xmlDoc.CreateElement("Name");
            //element.SetAttribute("value", savingObjects[i].Name);
            //node.AppendChild(element);

            //element = xmlDoc.CreateElement("PosX");
            //element.SetAttribute("value", savingObjects[i].Position.X.ToString());
            //node.AppendChild(element);

            //element = xmlDoc.CreateElement("PosY");
            //element.SetAttribute("value", savingObjects[i].Position.Y.ToString());
            //node.AppendChild(element);

            //element = xmlDoc.CreateElement("PosZ");
            //element.SetAttribute("value", savingObjects[i].Position.Z.ToString());
            //node.AppendChild(element);

            //element = xmlDoc.CreateElement("IsEnable");
            //element.SetAttribute("value", savingObjects[i].IsEnable.ToString());
            //node.AppendChild(element);

            //xmlDoc.Save(path);
            //}
        }

        public SavedData[] Load(string path = null)
        {


            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                var result = (SavedData[])formatter.Deserialize(fileStream);

                return result;
            }

            //if (!File.Exists(path))
            //{
            //    return result.ToArray();
            //}

            //using (var reader = new XmlTextReader(path))
            //{
            //    while (reader.Read())
            //    {
            //        for (int i = 0; i < result.Count; i++)
            //        {
            //            var key = "Name";
            //            if (reader.IsStartElement(key))
            //            {
            //                result[i].Name = reader.GetAttribute("value");
            //            }
            //            key = "PosX";
            //            if (reader.IsStartElement(key))
            //            {
            //                result[i].Position.X = reader.GetAttribute("value").TrySingle();
            //            }
            //            key = "PosY";
            //            if (reader.IsStartElement(key))
            //            {
            //                result[i].Position.Y = reader.GetAttribute("value").TrySingle();
            //            }
            //            key = "PosZ";
            //            if (reader.IsStartElement(key))
            //            {
            //                result[i].Position.Z = reader.GetAttribute("value").TrySingle();
            //            }
            //            key = "IsEnable";
            //            if (reader.IsStartElement(key))
            //            {
            //                result[i].IsEnable = reader.GetAttribute("value").TryBool();
            //            }
            //        }
            //    }
            //}
            //return result.ToArray();

        }
    }
}
