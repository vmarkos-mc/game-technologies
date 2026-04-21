using System;
using System.Collections.Generic;
using System.Linq;

// TODO: Consider refactoring this with inventory, as they do share many elements.
// Exercise!
namespace Game_Lab_01
{
    public class Warehouse
    {
        private int capacity;
        private GridPoint location;
        private Dictionary<Artefact, int> items;

        public Warehouse(int capacity, GridPoint location)
        {
            this.capacity = capacity;
            this.location = location;
            items = new Dictionary<Artefact, int>();
        }

        public Warehouse(GridPoint location) : this(100, location) { }

        public bool Add(Artefact item)
        {
            if (IsFull()) return false;
            if (items.ContainsKey(item))
                items[item] += 1;
            else
                items.Add(item, 1);
            return true;
        }

        public bool Dump(Dictionary<Ingredient, int> items)
        {
            foreach (Ingredient item in items.Keys)
            {
                if (this.Count() + items[item] > this.capacity) return false;
                if (this.items.ContainsKey(item))
                    this.items[item] += items[item];
                else
                    this.items[item] = items[item];
                // Could have been just a loop
                // Enumerable.Range(0, items[item]).ForEach(
                //     () => added = this.Add(item)
                // );
                // if (!added) return false;
            }
            return true;
        }

        public bool Remove(Artefact item)
        {
            // Exercise
            return true;
        }

        public bool IsFull()
        {
            return this.Count() == this.capacity;
        }

        public bool IsEmpty()
        {
            // Exercise
            return false;
        }

        public int Count()
        {
            return items.Values.Aggregate(
                0,
                (a, b) => a + b
            );
        }

        public bool IsAt(int i, int j)
        {
            return this.location.GetX() == i && this.location.GetY() == j;
            // return this.location.Equals(new GridPoint(i, j));
        }

        public bool IsAt(GridPoint point)
        {
            return this.location.Equals(point);
        }

        public override string ToString()
        {
            return "W";
        }
    }   
}