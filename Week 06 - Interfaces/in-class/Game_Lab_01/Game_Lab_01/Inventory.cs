using System;
using System.Runtime.CompilerServices;

namespace Game_Lab_01
{
    public class Inventory
    {
        private int capacity;
        private Dictionary<Artefact, int> items;

        public Inventory(int capacity)
        {
            this.capacity = capacity;
            items = new Dictionary<Artefact, int>();
        }

        // Implement a "default" constructor by falling back to
        // the above constructor.
        public Inventory() : this(20) { }

        public bool Add(Artefact artefact)
        {
            if (IsFull()) return false;
            if (items.ContainsKey(artefact))
                items[artefact] += 1;
            else
                items.Add(artefact, 1);
            return true;
        }

        public bool Drop(Artefact artefact)
        {
            if (IsEmpty()) return false;
            items.Remove(artefact);
            return true;
        }

        public bool IsFull()
        {
            return items.Count == capacity;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }

        public int Count()
        {
            return items.Count;
        }

        public HashSet<Equipment> GetEquipment()
        {
            HashSet<Equipment> result = new HashSet<Equipment>();
            foreach (Artefact item in items.Keys)
            {
                if (item.GetType() == typeof(Equipment))
                    result.Add((Equipment)item);
            }
            return result;
        }

        public override string ToString()
        {
            return String.Format("Items Found: {0}", Count());
        }
    }
}
