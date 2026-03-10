using System;

namespace Game_Lab_01
{
    public class Player
    {
        private GridPoint location;
        private Inventory inventory;

        public Player(int row, int col)
        {
            location = new GridPoint(row, col);
            inventory = new Inventory();
        }

        // Default constructor
        public Player() { }

        // Relics setters / getters
        public int GetRelicsCollected()
        {
            return inventory.Count();
        }

        public Inventory GetInventory() { return inventory; }

        // Update relics counter
        public void CollectRelic(Artefact artefact)
        {
            inventory.Add(artefact);
        }

        // Object method that returns player location
        public GridPoint GetLocation()
        {
            return location;
        }

        // Location Setter
        public void SetLocation(GridPoint location)
        {
            this.location = location;
        }

        // Checks whether the player is at a specific location
        public bool IsAt(int row, int col)
        {
            return location.GetX() == row && location.GetY() == col;
        }

        public override string ToString()
        {
            return "p";
        }
    }
}
