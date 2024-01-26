namespace CorruptedLandTales
{
    public interface IUsableItem
    {
        //TODO можно сделать ScriptableObject
        T GetData<T>();
    }
}