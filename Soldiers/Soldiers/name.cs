using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    public class name : IComparable<name>
    {
        public String first = "";
        public String middle = "";
        public String last = "";
        public String maiden = "";

        public name()
        {
        }

        public name(String f, String mid, String l, String maid)
        {
            first = f;
            middle = mid;
            last = l;
            maiden = maid;
        }
        
        public name(String f, String mid, String l)
        {
            first = f;
            middle = mid;
            last = l;
            maiden = "";
        }
        
        //first middle last maiden
        public override string ToString()
        {
            return first + " " + (middle.Length > 0 ? middle + " ": "") + last + " " + (maiden.Length > 0 ? maiden : "");
        }

        /*
        public String toDatabaseString()
        {
            return first.PadRight(20) + " " + middle.PadRight(20) + " " + last.PadRight(20) + " " + maiden.PadRight(20);
        }
        */

        //last, first middle maiden
        public String bookString()
        {
            return (last + ", " + first + " " + middle + " " + maiden).Trim();
        }

        //sorts alphabetically by bookstring
        public int CompareTo(name other)
        {
            return bookString().CompareTo(other.bookString());
        }

    }
}
