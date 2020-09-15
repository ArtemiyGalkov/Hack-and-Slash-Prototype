using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name;
    public int Id;

    public Item(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public T Clone<T>() where T : Item
    {
        return (T)this.MemberwiseClone();
    }
}
