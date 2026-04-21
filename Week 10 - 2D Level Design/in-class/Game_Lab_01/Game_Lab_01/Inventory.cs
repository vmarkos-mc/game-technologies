using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

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
            Knife knife = new Knife(new GridPoint(0, 0)); // HACK: Just a hack!
            items.Add(knife, 1);
        }

        // Implement a "default" constructor by falling back to
        // the above constructor.
        // FIXME: Use capacity to check if more things can be carried or not!
        public Inventory() : this(10) { }

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
            return this.Count() == this.capacity;
        }

        public bool IsEmpty()
        {
            return this.Count() == 0;
        }

        public int Count()
        {
            int count = items.Values.Aggregate(
                0, // Initial value
                (a, b) => a + b // Aggregator function
            );
            // Utils.Log("" + count);
            return count;
        }

        public HashSet<Equipment> GetEquipment()
        {
            HashSet<Equipment> result = new HashSet<Equipment>();
            foreach (Artefact item in items.Keys)
            {
                if (item is Equipment)
                    result.Add((Equipment)item);
            }
            return result;
        }

        public Dictionary<Ingredient, int> GetIngredients()
        {
            // Returns a collection of all ingredients
            return items.Where(pair => pair.Key is Ingredient)
                     .Select((pair) => new Dictionary<Ingredient, int>() { { pair.Key as Ingredient, pair.Value } })
                     .Aggregate(
                        new Dictionary<Ingredient, int>(),
                        (a, b) =>
                        {
                            Ingredient bFirstKey = b.First().Key;
                            if (a.ContainsKey(bFirstKey))
                                a[bFirstKey] += b.First().Value;
                            else
                                a[bFirstKey] = b.First().Value;
                            return a;
                        });
        }

        public Dictionary<Ingredient, int> EmptyIngredients()
        {
            Dictionary<Ingredient, int> ingredients = GetIngredients();
            this.items = this.items.Where(pair => !(pair.Key is Ingredient))
                        .Aggregate(
                            new Dictionary<Artefact, int>(),
                            (a, b) =>
                            {
                                if (a.ContainsKey(b.Key))
                                    a[b.Key] += b.Value;
                                else
                                    a[b.Key] = b.Value;
                                return a;
                            }
                        );
            return ingredients;
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
                _equipment => _equipment.ToString()
            ));
            return String.Format("Ingredients:\n{0}\nEquipment:\n{1}", ingredientsString, equipmentString);
        }
    }
}
