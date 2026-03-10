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

        private bool CanCollect(Artefact artefact)
        {
            if (artefact.GetType() != typeof(Ingredient)) return true;
            foreach (Equipment equipment in inventory.GetEquipment())
            {
                if (equipment is ICollects)
                {
                    var collectingEquipment = equipment as ICollects;
                    if (collectingEquipment.CanCollect((Ingredient)artefact)) return true;
                }
            }
            return false;
        }

        // Update relics counter
        public bool CollectRelic(Artefact artefact)
        {
            if (!CanCollect(artefact)) return false;
            inventory.Add(artefact);
            return true;
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
