using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunGen {
    class Room {
        // ---------------- ---------------- ---------------- ---------------- //
        public int North, South, East, West;
        // ---------------- ---------------- ---------------- ---------------- //
        // Place a random room at a randon point within the bounds.
        public Room(int xmin, int ymin, int xmax, int ymax, Random rand) {
            // X bounds
            int w1 = rand.Next(xmin, xmax);
            int w2 = rand.Next(xmin, xmax);
            this.West = Math.Min(w1, w2);
            this.East = Math.Max(w1, w2);

            // Y bounds
            int h1 = rand.Next(ymin, ymax);
            int h2 = rand.Next(ymin, ymax);
            this.North = Math.Min(h1, h2);
            this.South = Math.Max(h1, h2);
        }
        // ---------------- //
        // Create a room of a specific size and location
        public Room(int North, int South, int East, int West) {
            this.North = North; this.South = South;
            this.East = East; this.West = West;
        }
        // ---------------- ---------------- ---------------- ---------------- //
        override public string ToString() {
            return "N: " + North + "\nS: " + South + "\nW: " + West + "\nE: " + East + "\n";
        }
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace