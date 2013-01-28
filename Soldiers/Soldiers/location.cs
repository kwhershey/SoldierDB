using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    public class location
    {
        public String city;
        public String county;
        public String state;
        public String country;

        public location()
        {
        }

        public location(String cty, String cnt, String st, String ctry)
        {
            city = cty;
            county = cnt;
            state = st;
            country = ctry;
        }

        public location(String cty, String cnt)
        {
            city = cty;
            county = cnt;
            state = "IL";
            country = "USA";
        }

        public override string ToString()
        {
            if (city == "" && county == "" && state == "" && country == "")
                return "";
            if (city == "" && county == "" && state == "")
                return country;
            if (city =="" && county == "")
                return state + ", " + country;
            if (city == "" && state == "")
                return county + " County, " + country;
            if (city == "")
                return county + " County, " + state + ", " + country;
         
            return city + ", " + county + " County, " + state + ", " + country;
                
           
        }

        public string toDatabaseString()
        {
            return city.PadRight(30) + " " + county.PadRight(20) + " " + state.PadRight(20) + " " + country.PadRight(20);
        }

        public bool isIllinoisCounty()
        {
            county.Trim();
            if (county == "Adams" || county =="adams" ||
                county == "Alexander" || county =="alexander" ||
                county == "Bond" || county =="bond" ||
                county == "Boone" || county =="boone" ||
                county == "Brown" || county =="brown" ||
                county == "Bureau" || county =="bureau " ||
                county == "Calhoun" || county =="calhoun" ||
                county == "Carroll" || county =="carroll" ||
                county == "Cass" || county =="cass" ||
                county == "Champaign" || county =="champaign" ||
                county == "Christian" || county =="christian" ||
                county == "Clark" || county =="clark" ||
                county == "Clay" || county =="clay" ||
                county == "Clinton" || county =="clinton" ||
                county == "Coles" || county =="coles" ||
                county == "Cook" || county =="cook" ||
                county == "Crawford" || county =="crawford" ||
                county == "Cumberland" || county =="cumberland" ||
                county == "DeKalb" || county =="deKalb" ||
                county == "De Witt" || county =="de witt" ||
                county == "Douglas" || county =="douglas" ||
                county == "DuPage" || county =="dupage" ||
                county == "Edgar" || county =="edgar" ||
                county == "Edwards" || county =="edwards" ||
                county == "Effingham" || county =="effingham" ||
                county == "Fayette" || county =="fayette" ||
                county == "Ford" || county =="ford" ||
                county == "Franklin" || county =="franklin" ||
                county == "Fulton" || county =="fulton" ||
                county == "Gallatin" || county =="gallatin" ||
                county == "Greene" || county =="greene" ||
                county == "Grundy" || county =="grundy" ||
                county == "Hamilton" || county =="hamilton" ||
                county == "Hancock" || county =="hancock" ||
                county == "Hardin" || county =="hardin" ||
                county == "Henderson" || county =="henderson" ||
                county == "Henry" || county =="henry" ||
                county == "Iroquois" || county =="iroquois" ||
                county == "Jackson" || county =="jackson" ||
                county == "Jasper" || county =="jasper" ||
                county == "Jefferson" || county =="jefferson" ||
                county == "Jersey" || county =="jersey" ||
                county == "Jo Daviess" || county =="jo daviess" ||
                county == "Johnson" || county =="johnson" ||
                county == "Kane" || county =="kane" ||
                county == "Kankakee" || county =="kankakee" ||
                county == "Kendall" || county =="kendall" ||
                county == "Knox" || county =="knox" ||
                county == "Lake" || county =="lake" ||
                county == "La Salle" || county =="la salle" ||
                county == "Lawrence" || county =="lawrence" ||
                county == "Lee" || county =="lee" ||
                county == "Livingston" || county =="livingston" ||
                county == "Logan" || county =="logan" ||
                county == "McDonough" || county =="mcdonough" ||
                county == "McHenry" || county =="mchenry" ||
                county == "McLean" || county =="mclean" ||
                county == "Macon" || county =="macon" ||
                county == "Macoupin" || county =="macoupin" ||
                county == "Madison" || county =="madison" ||
                county == "Marion" || county =="marion" ||
                county == "Marshall" || county =="marshall" ||
                county == "Mason" || county =="mason" ||
                county == "Massac" || county =="massac" ||
                county == "Menard" || county =="menard" ||
                county == "Mercer" || county =="mercer" ||
                county == "Monroe" || county =="monroe" ||
                county == "Montgomery" || county =="montgomery" ||
                county == "Morgan" || county =="morgan" ||
                county == "Moultrie" || county =="moultrie" ||
                county == "Ogle" || county =="ogle" ||
                county == "Peoria" || county =="peoria" ||
                county == "Perry" || county =="perry" ||
                county == "Piatt" || county =="piatt" ||
                county == "Pike" || county =="pike" ||
                county == "Pope" || county =="pope" ||
                county == "Pulaski" || county =="pulaski" ||
                county == "Putnam" || county =="putnam" ||
                county == "Randolph" || county =="randolph" ||
                county == "Richland" || county =="richland" ||
                county == "Rock Island" || county =="rock island" ||
                county == "St. Clair" || county =="st. clair" ||
                county == "Saline" || county =="saline" ||
                county == "Sangamon" || county =="sangamon" ||
                county == "Schuyler" || county =="schuyler" ||
                county == "Scott" || county =="scott" ||
                county == "Shelby" || county =="shelby" ||
                county == "Stark" || county =="stark" ||
                county == "Stephenson" || county =="stephenson" ||
                county == "Tazewell" || county =="tazewell" ||
                county == "Union" || county =="union" ||
                county == "Vermilion" || county =="vermilion" ||
                county == "Wabash" || county =="wabash" ||
                county == "Warren" || county =="warren" ||
                county == "Washington" || county =="washington" ||
                county == "Wayne" || county =="wayne" ||
                county == "White" || county =="white" ||
                county == "Whiteside" || county =="whiteside" ||
                county == "Will" || county =="will" ||
                county == "Williamson" || county =="williamson" ||
                county == "Winnebago" || county =="winnebago" ||
                county == "Woodford" || county =="woodford" )
                return true;

            return false;

        }



    }
}
