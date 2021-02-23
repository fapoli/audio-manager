using System;
using System.Collections;
using System.Collections.Generic;

public class KeyCounter<K>
{
    private Dictionary<K, int> counter = new Dictionary<K, int>();

    public int GetAndIncrement(K key)
    {
        if (!counter.ContainsKey(key))
            counter[key] = 0;

        return ++counter[key];
    }

    public void Clear(K key)
    {
        counter[key] = 0;
    }
}