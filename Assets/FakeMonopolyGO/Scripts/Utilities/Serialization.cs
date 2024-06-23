using System;
using System.Collections.Generic;

[Serializable]
public class Serialization<TKey, TValue>
{
    public List<TKey> keys;
    public List<TValue> values;

    public Serialization(Dictionary<TKey, TValue> dictionary)
    {
        keys = new List<TKey>(dictionary.Keys);
        values = new List<TValue>(dictionary.Values);
    }

    public Dictionary<TKey, TValue> ToDictionary()
    {
        Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
        for (int i = 0; i < keys.Count; i++)
        {
            result[keys[i]] = values[i];
        }
        return result;
    }
}