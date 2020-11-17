using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace ShipovMihail_Roll_A_Boll
{
    public class XMLData<T> : ISaveData<T>
    {

        XmlSerializer _formatter = new XmlSerializer(typeof(T[]));

        public void Save(string path = null, params T[] savingObjects)
        {

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
