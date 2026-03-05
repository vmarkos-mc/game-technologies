using System;

namespace Game_Lab_01
{
    internal class Inventory
    {
        private int capacity;
        private HashSet<Artefact> items;

        public Inventory(int capacity)
        {
            this.capacity = capacity;
        }

        // Implement a "default" constructor by falling back to
        // the above constructor.
        public Inventory() : this(20) { }

        public bool Add(Artefact artefact)
        {
            if (IsFull()) return false;
            items.Add(artefact);
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
    }
}
