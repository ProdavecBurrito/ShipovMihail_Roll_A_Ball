using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ShipovMihail_Roll_A_Boll
{
    internal class XMLData<T> : ISaveData<T>
    {
        XmlSerializer _formatter = new XmlSerializer(typeof(T[]));

        public void Save(string path = null, params T[] savingObjects)
        {
            File.WriteAllText(path, null);

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fileStream, savingObjects);
            }
        }


        public T[] Load(string path = null)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                var result = (T[])_formatter.Deserialize(fileStream);

                return result;
            }
        }
    }
}
