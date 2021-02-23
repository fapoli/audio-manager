using System.Collections;
using System.Collections.Generic;

public class GroupSequence<K, T> : GroupList<K, T>
{
    private KeyCounter<K> counter = new KeyCounter<K>();

    public T Next(K key)
    {
        var list = this[key];
        return list[counter.GetAndIncrement(key) % list.Count];
    }

    public void ResetCounter(K key)
    {
        counter.Clear(key);
    }
}