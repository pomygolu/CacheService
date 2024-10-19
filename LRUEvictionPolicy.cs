public class LRUEvictionPolicy : IEvictionpolicy 
{
    LinkedList<string> linkedList;
    HashSet<string> hashSet;
    public LRUEvictionPolicy()
    {
        this.linkedList = new LinkedList<string>();
        this.hashSet = new HashSet<string>();
    }

    public void KeyAccessed(string key) {
        if (hashSet.Contains(key)){
            linkedList.Remove(key);
            linkedList.AddLast(key);
        }
        else {
            linkedList.AddLast(key);
            hashSet.Add(key);
        }
    }

    public string EvictKey()
    {
        if (linkedList.Count == 0)
        {
            // Handle the case when the list is empty
            throw new InvalidOperationException("Cannot evict from an empty list.");
        }

        // Get and remove the first element from the linked list
        var key = linkedList.First.Value;
        linkedList.RemoveFirst();

        // Remove the key from the hashset
        hashSet.Remove(key);

        return key;
        }
}