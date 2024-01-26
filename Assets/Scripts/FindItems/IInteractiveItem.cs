namespace CorruptedLandTales
{
    public interface IInteractiveItem
    {
        //TODO можно сделать ScriptableObject
        T GetData<T>();
    }
}