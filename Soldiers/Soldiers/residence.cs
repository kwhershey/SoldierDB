using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    public class residence
    {
        public date moveInDate = new date();
        public date moveOutDate = new date();
        public location place = new location();

        public residence()
        {
        }

        public residence(date i, date o, location p)
        {
            moveInDate = i;
            moveOutDate = o;
            place = p;
        }

        //for printing book.  Generates sentence.
        public override string ToString()
        {
            if (moveInDate.isUndetermined() || moveOutDate.isUndetermined())
            {
                return place.ToString() + " " + moveInDate.BookString() + " " + moveOutDate.BookString();
            }
            else return place.ToString() + " from " + moveInDate.BookString() + " to " + moveOutDate.BookString();
        }

    }
}
