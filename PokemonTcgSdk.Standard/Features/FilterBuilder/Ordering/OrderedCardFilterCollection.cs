namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Ordering;

using System.Collections;
using System.Collections.Generic;

using Base;

public class OrderedCardFilterCollection<TCollection, TKey, TValue> : IFilterCollection<TKey, TValue>
    where TCollection : BaseFilterCollection<TKey, TValue>
{
    private readonly TCollection _baseCollection;

    internal OrderedCardFilterCollection(TCollection collection)
    {
        _baseCollection = collection;
    }

    // Implement IFilterCollection by delegating to _baseCollection
    public TValue this[TKey key]
    {
        get => _baseCollection[key];
        set => _baseCollection[key] = value;
    }

    public ICollection<TKey> Keys => _baseCollection.Keys;
    public ICollection<TValue> Values => _baseCollection.Values;
    public int Count => _baseCollection.Count;
    public bool IsReadOnly => _baseCollection.IsReadOnly;

    public void Add(TKey key, TValue value) => _baseCollection.Add(key, value);
    public void Add(KeyValuePair<TKey, TValue> item) => _baseCollection.Add(item);
    public void Clear() => _baseCollection.Clear();
    public bool Contains(KeyValuePair<TKey, TValue> item) => _baseCollection.Contains(item);
    public bool ContainsKey(TKey key) => _baseCollection.ContainsKey(key);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _baseCollection.CopyTo(array, arrayIndex);
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _baseCollection.GetEnumerator();
    public bool Remove(TKey key) => _baseCollection.Remove(key);
    public bool Remove(KeyValuePair<TKey, TValue> item) => _baseCollection.Remove(item);
    public bool TryGetValue(TKey key, out TValue value) => _baseCollection.TryGetValue(key, out value);
    IEnumerator IEnumerable.GetEnumerator() => _baseCollection.GetEnumerator();
    internal bool TryGetOrderingValue(string key, out TValue value)
    {
        return _baseCollection.TryGetOrderingValue(key, out value);
    }

    internal void SetOrderingValue(string key, TValue value)
    {
        _baseCollection.SetOrderingValue(key, value);
    }
}