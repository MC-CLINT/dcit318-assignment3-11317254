using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    { 
        items.Add(item); 
    }


    public List<T> GetAll()
    {
        return new List<T>(items);
    }

    public T? GetById(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }

    public bool Remove(Func<T, bool> predicate)
    {
        var item = items.FirstOrDefault(predicate);
        if(item != null)
        {
            items.Remove(item);
            return true;
        }
        return false;
    }
}
