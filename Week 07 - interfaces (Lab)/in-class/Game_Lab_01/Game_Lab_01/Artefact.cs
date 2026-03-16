using System;

namespace Game_Lab_01
{
    public class Artefact
    {
        private GridPoint location;

        public Artefact(GridPoint location) {
            this.location = location;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Artefact)) return false;
            Artefact other = (Artefact)obj;
            return this.location.Equals(other.location);
        }

        public override int GetHashCode()
        {
            return this.location.GetHashCode();
        }
    }
}
