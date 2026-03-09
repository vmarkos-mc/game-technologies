using System;

namespace Example {
    class Item {
        private string name;
        
        public Item(string name) {
            this.name = name;
        }

        public override ToString() { return this.name; }
    }
}
