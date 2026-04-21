using System;

namespace Game_Lab_01
{
    // Since we need this class only within our namespace, we define this as `internal`
    public class GridPoint
    {
        private int x;
        private int y;

        public GridPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        // No setters is just like x and y are constants.
        public override string ToString()
        {
            return String.Format("({0}, {1})", x, y);
        }

        public override bool Equals(object other)
        {
            // This, in practice, means that two `GridPoint`s compare equal exactly
            // when they have the same coordinates and not when they are in the same place
            // in memory.
            if (other == null) return false;
            if (other.GetType() != typeof(GridPoint)) return false;
            GridPoint otherPoint = (GridPoint) other;// Alternative: `as GridPoint`;
            return this.x == otherPoint.x && this.y == otherPoint.y; // `this` is redundant here, just emphasis
        }

        /*
         * When we override `Equals()` we typically have to override `GetHashCode()` in a way that:
         *  1. When `Equals()` returns `true`, `GetHashCode()` should return the same hash value.
         *  2. When `Equals()` returns `false`, *optionally*, `GetHashCode()` returns different hash values.
         */
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

        /*
         * In general, in OOP, besides primitives, everything is passed by *reference*, i.e., 
         * we pass as an argument a **reference** to the memory location where the object 
         * is kept.
         * 
         * This also means that, when compaing obejcts, e.g., when we check whether an element
         * is contained in a set or not, we use its *reference* and not it actual field value(s).
         * 
         * We can override this behaviour by overriding the Equals function.
         */
    }
}
