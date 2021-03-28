using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DunGen {
    class Program {
        // ---------------- ---------------- ---------------- ---------------- //
        static void Main(string[] args) {
            Floor fl = new Floor();
            Random rn = new Random();
            Artist al = new Artist(40, 30, 16);
            
            for(int i = 0; i < 100; i++) {
                Room rm = new Room(0, 0, 40, 30, rn);
                fl.AddNColor(rm, al);
                //al.SaveDun();
            }
            al.SaveDun("C:\\Users\\lucask\\testmat\\testdun.bmp");
        }
        // ---------------- ---------------- ---------------- ---------------- //
    } // End of class
} // End of namespace