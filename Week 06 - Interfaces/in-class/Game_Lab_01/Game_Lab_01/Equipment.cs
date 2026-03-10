using System;

namespace Game_Lab_01
{
    public abstract class Equipment : Artefact
    {
        /* 
         * This is an abstract class since we are not intending to create a 
         * single instance of `Equipment` but specific pieces of equipment, such 
         * as `Knife`, `Tray` etc.
         */
        public Equipment(GridPoint location) : base(location) { }


    }
}
