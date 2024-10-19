public class main {
    public static void Main(string[] args) {
        IStorage storage = new DictionaryBasedStorage(5);
        IEvictionpolicy evictionpolicy = new LRUEvictionPolicy();
        CacheService cacheService = new CacheService(storage, evictionpolicy);
        cacheService.Put("a", "Orange");
        cacheService.Put("b", "banana");
        Console.WriteLine(cacheService.Get("a"));
        cacheService.Put("c", "carrot");
        cacheService.Put("d", "mango");
        cacheService.Put("e", "Apple");
        cacheService.Put("f", "Litchi");
        Console.WriteLine(cacheService.Get("f"));
        Console.WriteLine(cacheService.Get("b"));
        Console.WriteLine(cacheService.Get("a"));
    }
}