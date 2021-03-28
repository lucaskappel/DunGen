using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunGen {
    class Floor {
        // ---------------- ---------------- ---------------- ---------------- //
        public Room[] RmList, Shadow;
        public int elements, carryInd;
        // ---------------- ---------------- ---------------- ---------------- //
        public Floor() {
            this.RmList = new Room[4];
            this.Shadow = new Room[8];
            this.carryInd = 0;
            this.elements = 0;
        }
        // ---------------- ---------------- ---------------- ---------------- //
        // Keep track of rooms using an Array-and-Shadow structure.
        public void AddRoom(Room rm) {
            RmList[elements] = rm;
            Shadow[elements] = rm;
            Shadow[carryInd] = RmList[carryInd];
            elements++; carryInd++;
            if (elements == RmList.Length) {
                RmList = Shadow;
                Shadow = new Room[RmList.Length * 2];
                carryInd = 0;
            }
        }
        // ---------------- ---------------- ---------------- ---------------- //
        public bool ICheck(Room rm) {
            bool flag = false;
            foreach(Room ram in RmList) {
                if (ram == null) break;
                if (rm.South > ram.North && rm.South < ram.South) flag = true;
                if (rm.North < ram.South && rm.North > ram.North) flag = true;
                if (rm.East > ram.West && rm.East < ram.East) flag = true;
                if (rm.West > ram.West && rm.West < ram.East) flag = true;
                if (rm.South < ram.North || rm.North > ram.South
                    || rm.East < ram.West || rm.West > ram.East) flag = false;
            }
            return flag;
        }
        // ---------------- ---------------- ---------------- ---------------- //
        public void AddNColor(Room rm, Artist al) {
            if (!this.ICheck(rm)) {
                this.AddRoom(rm);
                al.ColorRoom(rm, 1);
            }
            else al.ColorRoom(rm, 0);
        }
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of Class
} // End of Namespace