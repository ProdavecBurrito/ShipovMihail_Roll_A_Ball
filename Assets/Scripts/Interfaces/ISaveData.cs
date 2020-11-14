namespace ShipovMihail_Roll_A_Boll
{
    public interface ISaveData<T>
    {
        void Save(string path = null, params T[] data);
        T[] Load(string path = null);
    }
}
