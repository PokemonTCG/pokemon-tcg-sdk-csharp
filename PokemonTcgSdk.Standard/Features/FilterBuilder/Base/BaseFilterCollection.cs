namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Base;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Ordering;

public abstract class BaseFilterCollection<TKey, TValue> : IFilterCollection<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

    public TValue this[TKey key]
    {
        get => _dictionary[key];
        set => _dictionary[key] = value;
    }

    public ICollection<TKey> Keys => _dictionary.Keys;
    public ICollection<TValue> Values => _dictionary.Values;
    public int Count => _dictionary.Count;
    public bool IsReadOnly => false;

    public void Add(TKey key, TValue value) => _dictionary.Add(key, value);
    public void Add(KeyValuePair<TKey, TValue> item) => _dictionary.Add(item.Key, item.Value);
    public void Clear() => _dictionary.Clear();
    public bool Contains(KeyValuePair<TKey, TValue> item) => _dictionary.Contains(item);
    public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        => ((IDictionary<TKey, TValue>)_dictionary).CopyTo(array, arrayIndex);
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _dictionary.GetEnumerator();
    public bool Remove(TKey key) => _dictionary.Remove(key);
    public bool Remove(KeyValuePair<TKey, TValue> item)
        => ((IDictionary<TKey, TValue>)_dictionary).Remove(item);
    public bool TryGetValue(TKey key, out TValue value) => _dictionary.TryGetValue(key, out value);
    IEnumerator IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();

    /// <summary>
    /// Orders the collection by the specified value and direction.
    /// </summary>
    /// <param name="value">The value to order by.</param>
    /// <param name="ordering">Optional. The ordering direction. Default is ascending (0). Use Ordering.Descending for descending order.</param>
    /// <returns>A new <see cref="OrderedCardFilterCollection{TCollection, TKey, TValue}"/> containing the ordered collection.</returns>
    /// <remarks>
    /// Once OrderBy is called, subsequent ordering must use ThenBy. Multiple OrderBy calls are prevented at compile time.
    /// </remarks>
    /// <example>
    /// <code>
    /// var filter = new PokemonFilterCollection&lt;string, string&gt;()
    ///     .AddName("Darkrai")
    ///     .OrderBy("hp", Ordering.Descending);
    /// </code>
    /// </example>
    public OrderedCardFilterCollection<BaseFilterCollection<TKey, TValue>, TKey, TValue> OrderBy(TValue value, Ordering ordering = 0)
    {
        var typedKey = (TKey)(object)"orderby";
        if (ordering == Ordering.Descending)
        {
            _dictionary[typedKey] = (TValue)(object)$"-{value}";
        }
        else
        {
            _dictionary[typedKey] = value;
        }
        return new OrderedCardFilterCollection<BaseFilterCollection<TKey, TValue>, TKey, TValue>(this);
    }

    protected internal bool TryGetOrderingValue(string key, out TValue value)
    {
        value = default;
        var typedKey = (TKey)(object)key;
        return _dictionary.TryGetValue(typedKey, out value);
    }

    protected internal void SetOrderingValue(string key, TValue value)
    {
        var typedKey = (TKey)(object)key;
        _dictionary[typedKey] = value;
    }
}