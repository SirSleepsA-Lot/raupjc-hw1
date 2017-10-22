using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IGenericList<X> : IEnumerable<X>
{
    void Add(X item);
    bool Remove(X item);
    bool RemoveAt(int index);
    X GetElement(int index);
    int IndexOf(X item);
    int Count { get; }
    void Clear();
    bool Contains(X item);
    
}


public class GenericList<X> : IGenericList<X>
{
    private X[] _internalStorage;
    private int _last;

    public IEnumerator<X> GetEnumerator()
    {
        for (int i = 0; i < _last; i++)
        {
            yield return _internalStorage[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        public X Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }



    public GenericList()
    {
        _internalStorage = new X[4];
        _last = 0;
    }
    public GenericList(int initialSize)
    {
        if (initialSize > 0)
        {
            _internalStorage = new X[initialSize];
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





    public void Add(X item)
    {

        if (_last + 1 > _internalStorage.Length)
        {
            int i;
            X[] substitution = new X[2 * _internalStorage.Length];
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

    public bool Remove(X item)
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
    public X GetElement(int index)
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
    public int IndexOf(X item)
    {

        for (int i = 0; i < _last; i++)
        {
            if (_internalStorage[i].Equals(item)) return i;
        }
        return -1;
    }
    public void Clear()
    {
        X[] substitution = new X[_internalStorage.Length];
        _internalStorage = substitution;
        _last = 0;
        return;
    }
    public bool Contains(X item)
    {

        for (int i = 0; i < _last; i++)
        {
            if (_internalStorage[i].Equals(item)) return true;
        }
        return false;
    }
}
