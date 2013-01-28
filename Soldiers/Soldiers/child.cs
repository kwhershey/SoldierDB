using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    public class child
    {
        //keeps track of spouse id for the database.  I don't 
        //think the soldierId is ever used.
        public name name = new name();
        public int soldierID;
        public int spouseID;

        public child()
        {
        }

        public child(name n, int sID, int mID)
        {
            name = n;
            soldierID = sID;
            spouseID = mID;
        }

        public override string ToString()
        {
            return name.ToString();
        }

    }
}
