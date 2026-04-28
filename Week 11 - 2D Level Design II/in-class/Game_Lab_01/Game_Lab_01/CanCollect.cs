using System;
using System.Collections.Generic;

namespace Game_Lab_01
{
    interface ICollects
    {
        // Checks whether a piece of equipemtn can collect a certain artefact
        bool CanCollect(Ingredient ingredient);
    }
}
