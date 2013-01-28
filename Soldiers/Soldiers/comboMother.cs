using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    class comboMother
    {
        //A wrapper class for the mother dropdown of the child 
		public spouse mother;

        public comboMother()
        {
        }

		public comboMother(spouse m)
		{
            mother = m;
		}

		public override string ToString()
		{
			return mother.name.ToString();
		}


    }
}
