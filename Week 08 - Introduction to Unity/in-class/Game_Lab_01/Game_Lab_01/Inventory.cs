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

        public Dictionary<Ingredient, int> GetIngredients()
        {
            // Returns a collection of all ingredients
            return items.Where(pair => pair.Key.GetType() == typeof(Ingredient))
                        .Select((pair) => new KeyValuePair<Ingredient, int>((Ingredient)pair.Key, pair.Value))
                        .ToDictionary<Ingredient, int>(); // Redundant Generics here, used just for clarity
        }

        /*
         * Anonymous Fuctions:
         * Syntax: <arguments> => <return value>
         * Remarks:
         *  - <arguments> is a comma-separated list of valid C# identifiers;
         *  - <return value> is (typically) a single C# expression.
         */

        //public Dictionary<Ingredient, int> GetIngredients()
        //{
        //    IEnumerable<Ingredient> query = items.Keys.Where(item => item.GetType() == typeof(Ingredient))
        //                                              .Select((ingredient) => (Ingredient)ingredient );
        //    Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();
        //    foreach (Ingredient ingredient in query)
        //    {
        //        ingredients[ingredient] = items[ingredient];
        //    }
        //    return ingredients;
        //}

        public override string ToString()
        {
            Dictionary<Ingredient, int> ingredients = GetIngredients();
            HashSet<Equipment> equipment = GetEquipment();
            string ingredientsString = String.Join("\n", ingredients.Select(
                pair => String.Format("{0}: {1}", pair.Key.ToString(), pair.Value.ToString())
            ));
            string equipmentString = String.Join(", ", equipment.Select(
                equipment => equipment.ToString()
            ));
            return String.Format("Ingredients:\n{0}\n\nEquipment:\n{1}", ingredientsString, equipmentString);
        }
    }
}
