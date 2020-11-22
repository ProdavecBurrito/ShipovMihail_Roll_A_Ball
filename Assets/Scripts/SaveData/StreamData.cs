using System.IO;

namespace ShipovMihail_Roll_A_Boll
{
    public class StreamData /*: ISaveData<SavedData>*/
    {
        //public void Save(string path = null, params SavedData[] data)
        //{
        //    if (path == null)
        //    {
        //        return;
        //    }

        //    using (var streamWriter = new StreamWriter(path))
        //    {
        //        for (int i = 0; i < data.Length; i++)
        //        {
        //            streamWriter.WriteLine(data[i].Name);
        //            streamWriter.WriteLine(data[i].Position.X);
        //            streamWriter.WriteLine(data[i].Position.Y);
        //            streamWriter.WriteLine(data[i].Position.Z);
        //            streamWriter.WriteLine(data[i].IsEnable);
        //        }
        //    }
        //}

        //public SavedData[] Load(string path = null)
        //{
        //    var result = new SavedData();

        //    using (var streamReader = new StreamReader(path))
        //    {
        //        while (!streamReader.EndOfStream)
        //        {
        //            result.Name = streamReader.ReadLine();
        //            result.Position.X = streamReader.ReadLine().TrySingle();
        //            result.Position.Y = streamReader.ReadLine().TrySingle();
        //            result.Position.Z = streamReader.ReadLine().TrySingle();
        //            result.IsEnable = streamReader.ReadLine().TryBool();
        //        }
        //    }
        //    return result.;

        //}
    }
}
