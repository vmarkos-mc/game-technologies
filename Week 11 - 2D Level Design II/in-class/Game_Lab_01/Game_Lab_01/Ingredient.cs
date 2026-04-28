using System;
using System.Linq;

namespace Game_Lab_01
{
    public class Ingredient : Artefact
    {
        private IngredientType type;

        public Ingredient(GridPoint location, IngredientType type) : base(location)
        {
            this.type = type;
        }

        public IngredientType GetIngredientType() { return this.type; }

        // Ingredient type enumerator
        public enum IngredientType
        {
            Spanaki, Vrouva, Prasso, Anithos, Seskoulo, Feta, Fyllo,
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ingredient)) return false;
            Ingredient other = (Ingredient) obj; // Safe to cast
            // `other.type` is visible since we are inside the Ingredient class
            return this.type == other.type;
        }

        public override int GetHashCode()
        {
            return type.GetHashCode();
        }

        public override string ToString()
        {
            return type.ToString();
        }
    }
}
