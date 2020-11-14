using System.IO;

namespace ShipovMihail_Roll_A_Boll
{
    public class StreamData : ISaveData<SavedData>
    {
        public void Save(SavedData data, string path = null)
        {
            if (path == null)
            {
                return;
            }

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(data.Name);
                streamWriter.WriteLine(data.Position.X);
                streamWriter.WriteLine(data.Position.Y);
                streamWriter.WriteLine(data.Position.Z);
                streamWriter.WriteLine(data.IsEnable);
            }
        }

        public SavedData Load(string path = null)
        {
            var result = new SavedData();

            using (var streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    result.Name = streamReader.ReadLine();
                    result.Position.X = streamReader.ReadLine().TrySingle();
                    result.Position.Y = streamReader.ReadLine().TrySingle();
                    result.Position.Z = streamReader.ReadLine().TrySingle();
                    result.IsEnable = streamReader.ReadLine().TryBool();
                }
            }
            return result;

        }
    }
}
