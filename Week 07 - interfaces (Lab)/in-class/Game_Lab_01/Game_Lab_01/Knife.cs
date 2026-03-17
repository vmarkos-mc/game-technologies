using System;

namespace Game_Lab_01
{
    internal class Knife : Equipment, ICollects
    {
        private HashSet<Ingredient.IngredientType> collectibles;

        public Knife(GridPoint location) : base(location)
        {
            collectibles = new HashSet<Ingredient.IngredientType>() {
                Ingredient.IngredientType.Spanaki,
                Ingredient.IngredientType.Vrouva, 
                Ingredient.IngredientType.Prasso,
                Ingredient.IngredientType.Anithos,
                Ingredient.IngredientType.Seskoulo,
            };
        }

        public bool CanCollect(Ingredient ingredient)
        {
            return collectibles.Contains(ingredient.GetIngredientType());
        }

        public override string ToString()
        {
            return "Knife"; // Dummy as it gets, but, it works...
        }
    }
}
