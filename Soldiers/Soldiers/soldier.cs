using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soldiers
{
    public class Soldier : IComparable<Soldier>
    {
        public int id;
        public name soldierName = new name();
        public date birthDate = new date();
        public location birthLocation = new location();
        public date deathDate = new date();
        public location deathLocation = new location();
        public String cemetery = "";
        public String cemeteryLatitude = "";
        public String cemeteryLongitude = "";
        public location cemeteryLocation = new location();
        public List<spouse> spouses = new List<spouse>();
        public List<child> children = new List<child>();
        public List<residence> residences = new List<residence>();
        public List<String> servicePositions = new List<string>();
        public List<String> serviceTroops = new List<string>();
        public List<String> serviceSuperiors = new List<string>();
        public String serviceAddedText;
        public String markerText;
        public String pensionNumber;
        public String pensionText;
        public String sources;
        public String addedText;

        public Soldier()
        {
        }

        public Soldier(name n, date bd, location bl, date dd, location dl, String c, String cLat, String cLong, location cl, List<spouse> sps, List<child> cld, List<residence> r, List<String> sp, List<String> st, List<String> swu,
            String sat, String mt, String pn, String pt, String src, String at)
        {
            soldierName = n;
            birthDate = bd;
            birthLocation = bl;
            deathDate = dd;
            deathLocation = dl;
            cemetery = c;
            cemeteryLatitude = cLat;
            cemeteryLongitude = cLong;
            cemeteryLocation = cl;
            spouses = sps;
            children = cld;
            residences = r;
            servicePositions = sp;
            serviceTroops = st;
            serviceSuperiors = swu;
            serviceAddedText = sat;
            markerText = mt;
            pensionNumber = pn;
            pensionText = pt;
            sources = src;
            addedText = at;

        }

        //fills in the listview columns
        public void printToListView(ListView printBox)
        {
            string[] soldierToPrint = { soldierName.bookString(), birthDate.ToString(), birthLocation.ToString(), deathDate.ToString(), deathLocation.ToString(), cemetery , cemeteryLocation.ToString(),
                                      spouses.Count().ToString(), children.Count().ToString(), residences.Count().ToString(), 
                                      servicePositions.Count()>0 ? servicePositions.First():"" , 
                                      serviceTroops.Count()>0 ? serviceTroops.First():""  , 
                                      serviceSuperiors.Count()>0 ? serviceSuperiors.First():""  , 
                                      pensionNumber};

            ListViewItem soldier = new ListViewItem(soldierToPrint);
            soldier.Tag = this;
            printBox.Items.Add(soldier);
         
        }

        //returns true if name matches what is in the filter textbox
        public bool filter(string text)
        {
            if (soldierName.first.ToLower().Contains(text) || soldierName.middle.ToLower().Contains(text) || soldierName.last.ToLower().Contains(text) || soldierName.maiden.ToLower().Contains(text) || soldierName.ToString().ToLower().Contains(text))
                return true;


            return false;
        }

        //sorts by names bookstring
        public int CompareTo(Soldier other)
        {
            return soldierName.CompareTo(other.soldierName);
        }




    }
}
