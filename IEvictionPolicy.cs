public interface IEvictionpolicy 
{
    public void KeyAccessed(string key);
    public string EvictKey();
}