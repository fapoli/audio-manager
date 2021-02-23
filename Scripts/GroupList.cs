using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupList<K, T>
{
    private readonly Dictionary<K, List<T>> data = new Dictionary<K, List<T>>();

    public void Add(K key, T value)
    {
        if (!data.ContainsKey(key))
            data.Add(key, new List<T>());

        data[key].Add(value);
    }

    public List<T> this[K key]
    {
        get { return data[key]; }
    }

    public int Count(K key)
    {
        return data.ContainsKey(key) ? data[key].Count : 0;
    }

    public bool ContainsKey(K key)
    {
        return data.ContainsKey(key);
    }

    public T GetRandom(K key)
    {
        var list = this[key];
        return list[Random.Range(0, list.Count)];
    }

}