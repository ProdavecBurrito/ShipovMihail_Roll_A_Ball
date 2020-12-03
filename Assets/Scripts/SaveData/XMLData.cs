using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ShipovMihail_Roll_A_Boll
{
    public class XMLData<T> : ISaveData<T>
    {

        XmlSerializer _formatter = new XmlSerializer(typeof(T[]));
        XmlSerializer xmlSerializer;

        private string _savingWords;

        public void Save(string path = null, params T[] savingObjects)
        {
            File.WriteAllText(path, null);

            //xmlSerializer = new XmlSerializer(savingObjects.GetType());

            //using (StringWriter textWriter = new StringWriter())
            //{
            //    xmlSerializer.Serialize(textWriter, savingObjects);
            //    _savingWords = textWriter.ToString();
            //    File.WriteAllText(path, Cripto.CryptoXOR(_savingWords));
            //}

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fileStream, savingObjects);
            }

            //_savingWords = string.Empty;
        }


        public T[] Load(string path = null)
        {
            //var str = File.ReadAllText(path);
            //str =  Cripto.DeCryptoXOR(str);
            ////File.WriteAllText(path, str);

            //using (StringReader textWriter = new StringReader(Cripto.DeCryptoXOR(path)))
            //{
            //    xmlSerializer.Deserialize(textWriter);
            //    _savingWords = textWriter.ToString();
            //    File.WriteAllText(path, Cripto.CryptoXOR(_savingWords));
            //}

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                var result = (T[])_formatter.Deserialize(fileStream);

                return result;
            }
        }
    }
}
