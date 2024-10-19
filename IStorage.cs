public interface IStorage 
{
    string Get(string key);
    void Put(string key, string value);
    void Remove(string key);
} 