using System;
using System.Collections.Generic;

namespace Game_Lab_01
{
    public interface ICollects
    {
        // Checks whether a piece of equipemtn can collect a certain artefact
        public bool CanCollect(Ingredient ingredient);
    }
}
