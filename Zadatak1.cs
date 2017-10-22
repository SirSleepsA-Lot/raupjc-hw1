using System;

public interface IIntegerList
{
    void Add(int item);
    bool Remove(int item);
    bool RemoveAt(int index);
    int GetElement(int index);
    int IndexOf(int item);
    int Count { get; }
    void Clear();
    bool Contains(int item);
    
}


public class IntegerList : IIntegerList
{
    private int[] _internalStorage;
    private int _last;
    public IntegerList()
    {
        _internalStorage = new int[4];
        _last = 0;
    }
    public IntegerList(int initialSize)
    {
        if (initialSize > 0)
        {
            _internalStorage = new int[initialSize];
            _last = 0;
        }
        else throw new Exception("Size of the internal storage cannot be negative");
    }
    public int Count
    {
        get
        {
            return _last;
        }
    }
    public void Add(int item)
    {
        if (_last + 1 > _internalStorage.Length)
        {
            int i;
            int[] substitution = new int[2 * _internalStorage.Length];
            for (i = 0; i < _last; i++)
            {
                substitution[i] = _internalStorage[i];
            }
            substitution[i] = item;
            _internalStorage = substitution;

        }
        else
        {
            _internalStorage[_last] = item;

        }
        _last++;
    }

    public bool Remove(int item)
    {
        bool var = false;
        int a = IndexOf(item);
        if (a >= 0) var = RemoveAt(a);
        return var;
    }

    public bool RemoveAt(int index)
    {

        int i;
        if (index >= _last)
        {
            
            throw new IndexOutOfRangeException("Index is not in range of the list");

        }
        else
        {
            for (i = index; i < _last - 1; i++)
            {
                ///moramo pripaziti na krajnji slucaj tj. kako cemo zamijeniti zadnji clan
                /// jer on nema sljedbenika pa metoda mozda nece raditi
                _internalStorage[i] = _internalStorage[i + 1];

            }
            _last--;
            return true;
        }
    }
    public int GetElement(int index)
    {
        if (index >= _last)
        {
            throw new IndexOutOfRangeException("Index is not in range of the list");

        }
        else
        {
            return _internalStorage[index];
        }
    }
    public int IndexOf(int item)
    {

        for (int i = 0; i < _last; i++)
        {
            if (_internalStorage[i] == item) return i;
        }
        return -1;
    }
    public void Clear()
    {
        int[] substitution = new int[_internalStorage.Length];
        _internalStorage = substitution;
        _last = 0;
        return;
    }
    public bool Contains(int item)
    {

        for (int i = 0; i < _last; i++)
        {
            if (_internalStorage[i] == item) return true;
        }
        return false;
    }
    
}
