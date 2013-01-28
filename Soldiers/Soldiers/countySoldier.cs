using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    public class countySoldier:IComparable<countySoldier>
    {
        //This class is used for printing the book.  Implements IComparable for the soldier associated with
        //the county so that you can sort the soldiers for the county index.
        public name soldierName = new name();
        public String county;

        public countySoldier(name n, String c)
        {
            soldierName = n;
            county = c;
        }

        public int CompareTo(countySoldier other)
        {
            return county.CompareTo(other.county);
        }
    }
}
