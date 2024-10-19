public class DictionaryBasedStorage : IStorage
{
    Dictionary<string, string> dictionary;
    int size;

    public DictionaryBasedStorage(int size)
    {
       this.size = size;
       this.dictionary= new Dictionary<string, string>(size);
    }

    public void Put(string key, string value) {
        if (StorageFull()) {
            throw new Exception("Memory Full");
        }
        dictionary.Add(key, value);
    }
    
    public string Get(string key) {
        if(!dictionary.ContainsKey(key)) {
            throw new Exception("No such key found");
        }
        return dictionary[key];
    }

    public void Remove(string key) {
        if(!dictionary.ContainsKey(key)) {
            throw new Exception("No such key found");
        }
        dictionary.Remove(key);
    }

    private bool StorageFull() {
        return dictionary.Count >= size;
    }
}