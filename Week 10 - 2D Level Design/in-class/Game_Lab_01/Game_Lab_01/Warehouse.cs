using System;
using System.Collections.Generic;

// TODO: Consider refactoring this with inventory, as they do share many elements.
// Exercise!
public class Warehouse
{
    private int capacity;
    private Dictionary<Artefact, int> items;

    public Warehouse(int capacity)
    {
        this.capacity = capacity;
    }

    public Warehouse() : this(100) { }

    public bool Add()
    {
        return true;
    }

    public bool Remove(Artefact item)
    {
        
    }

    public bool IsFull()
    {
        
    }

    public bool IsEmpty()
    {
        
    }


}