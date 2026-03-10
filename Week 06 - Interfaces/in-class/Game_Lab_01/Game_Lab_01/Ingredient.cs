using System;

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
    }
}
