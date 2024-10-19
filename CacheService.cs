public class CacheService 
{
    IStorage storage;
    IEvictionpolicy evictionPolicy;
    public CacheService(IStorage storage, IEvictionpolicy evictionPolicy)
    {
        this.storage = storage;
        this.evictionPolicy = evictionPolicy;
    }

    public void Put(string key, string value) 
    {
        try {
            storage.Put(key, value);
            evictionPolicy.KeyAccessed(key);
        } catch (Exception ex) {
            string keyToBeEvicted = evictionPolicy.EvictKey();
            storage.Remove(keyToBeEvicted);
            storage.Put(key, value);
        }
    }
    public string Get(string key)
    {
        try {
            string value = storage.Get(key);
            evictionPolicy.KeyAccessed(key);
            return value;
        }catch(Exception ex) {
            Console.WriteLine("Not found");
        }
        return null;
    }
}