using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    public class spouse
    {
        public name name = new name();
        public int id;
        public date marriageDate = new date();
        public location marriageLocation = new location();

        public spouse()
        {
        }

        public spouse(name n, int i, date d, location m)
        {
            name = n;
            id = i;
            marriageDate = d;
            marriageLocation = m;
        }

        //sorts by name
        public override string ToString()
        {
            if (marriageDate.isUndetermined())
            {
                if (marriageLocation.ToString() == "")
                    return name.ToString();
                else return name.ToString() + " in " + marriageLocation.ToString();
            }
            else
            {
                if (marriageLocation.ToString() == "")
                    return name.ToString() + " on " + marriageDate.BookString();
                else return name.ToString() + " on " + marriageDate.BookString() + " in " + marriageLocation.ToString();
            }

        }
    }
}
