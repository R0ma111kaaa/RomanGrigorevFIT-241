class TypedArray<T>
{
    private T[] items;
    private int count;

    public TypedArray(int capasity = 10)
    {
        items = new T[capasity];
        count = 0;
    }

    public int Count => count;

    public void Add(T item)
    {
        if (count >= items.Length)
        {
            Array.Resize<T>(ref items, items.Length * 2);
        }
        items[count] = item;
        count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || items.Length <= index)
        
            throw new IndexOutOfRangeException("Индекс за границей");
        
        for (int i = index; i < items.Length - 1; i++)
        {
            items[i] = items[i + 1];
        }
        count--;
        items[count] = default!;
    }

    public T Get(int index)
    {
        if (index < 0 || items.Length <= index)
        
            throw new IndexOutOfRangeException("Индекс за границей");
        
        return items[index];
    }
}