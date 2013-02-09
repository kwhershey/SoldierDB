using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Soldiers
{
    public class database
    {
        //public String file = "soldiers.dat";
        public SQLiteConnection m_dbConnection; //our handle
        public String path = "C:\\Program Files\\Illinois Soldiers Database\\";


        //uses opendb to open the default database located at "path"
        public database()
        {
            opendb();
        }

        //opens a custom database given its file path.
        public database(String filePath)
        {
            if (filePath == "")
            {
                opendb();
            }
            else
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Unable to open database.  Verify the database is located at:\n\"" + filePath + "\"\nand is of type s3db.");
                }
                else
                {
                    m_dbConnection = new SQLiteConnection("Data Source=" + filePath + ";Version=3;");
                    m_dbConnection.Open();
                }
        
            }
        }
        
        //opens the default database
        public void opendb()
        {
            if (!File.Exists(path + "soldierdb.s3db"))
            {
                MessageBox.Show("Unable to open database.  Verify the database is located at:\n\"" + path + "soldierdb.s3db\"" + " \nand is of type s3db.");
            }
            else
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + path + "soldierdb.s3db;Version=3;");
                m_dbConnection.Open();
            }
        }

        //closes the database.  I haven't used this anywhere
        public void closedb()
        {
            m_dbConnection.Close();
        }

        //returns a list of all the soldiers in the database.
        public List<Soldier> Soldiers()
        {
            List<Soldier> soldiers = new List<Soldier>();

            string readSoldiers = "select * from soldiers;";
            SQLiteCommand readcommand = new SQLiteCommand(readSoldiers, m_dbConnection);
            SQLiteDataReader reader = readcommand.ExecuteReader();

            while (reader.Read())
            {
                //all of the info in the soliers table
                Soldier newSoldier = new Soldier();
                newSoldier.id = Convert.ToInt32(reader["id"]);
                newSoldier.soldierName.first = reader["f_name"].ToString();
                newSoldier.soldierName.middle = reader["mid_name"].ToString();
                newSoldier.soldierName.last = reader["l_name"].ToString();
                newSoldier.soldierName.maiden = reader["maid_name"].ToString();
                newSoldier.birthDate.day = Convert.ToInt32(reader["b_date_day"]);
                newSoldier.birthDate.month = Convert.ToInt32(reader["b_date_month"]);
                newSoldier.birthDate.year = Convert.ToInt32(reader["b_date_year"]);
                newSoldier.birthLocation.city = reader["b_loc_city"].ToString();
                newSoldier.birthLocation.county = reader["b_loc_county"].ToString();
                newSoldier.birthLocation.state = reader["b_loc_state"].ToString();
                newSoldier.birthLocation.country = reader["b_loc_country"].ToString();
                newSoldier.deathDate.day = Convert.ToInt32(reader["d_date_day"]);
                newSoldier.deathDate.month = Convert.ToInt32(reader["d_date_month"]);
                newSoldier.deathDate.year = Convert.ToInt32(reader["d_date_year"]);
                newSoldier.deathLocation.city = reader["d_loc_city"].ToString();
                newSoldier.deathLocation.county = reader["d_loc_county"].ToString();
                newSoldier.deathLocation.state = reader["d_loc_state"].ToString();
                newSoldier.deathLocation.country = reader["d_loc_country"].ToString();
                newSoldier.cemetery = reader["c_name"].ToString();
                newSoldier.cemeteryLatitude = reader["c_latitude"].ToString();
                newSoldier.cemeteryLongitude = reader["c_longitude"].ToString();
                newSoldier.cemeteryLocation.city = reader["c_loc_city"].ToString();
                newSoldier.cemeteryLocation.county = reader["c_loc_county"].ToString();
                //newSoldier.cemeteryLocation.state = "Illinois";
                newSoldier.cemeteryLocation.state = reader["c_loc_state"].ToString();
                //newSoldier.cemeteryLocation.country = "USA";
                newSoldier.cemeteryLocation.country = reader["c_loc_country"].ToString();

                //read spouses
                string readSpouses = String.Format("select * from spouses where soldier_id={0};", newSoldier.id.ToString());
                readcommand = new SQLiteCommand(readSpouses, m_dbConnection);
                SQLiteDataReader spousesReader = readcommand.ExecuteReader();

                while (spousesReader.Read())
                {
                    spouse newSpouse = new spouse();
                    newSpouse.name.first = spousesReader["f_name"].ToString();
                    newSpouse.name.middle = spousesReader["mid_name"].ToString();
                    newSpouse.name.last = spousesReader["l_name"].ToString();
                    newSpouse.name.maiden = spousesReader["maid_name"].ToString();
                    newSpouse.id = Convert.ToInt32(spousesReader["id"]);
                    newSpouse.marriageDate.day = Convert.ToInt32(spousesReader["m_date_day"]);
                    newSpouse.marriageDate.month = Convert.ToInt32(spousesReader["m_date_month"]);
                    newSpouse.marriageDate.year = Convert.ToInt32(spousesReader["m_date_year"]);
                    newSpouse.marriageLocation.city = spousesReader["m_loc_city"].ToString();
                    newSpouse.marriageLocation.county = spousesReader["m_loc_county"].ToString();
                    newSpouse.marriageLocation.state = spousesReader["m_loc_state"].ToString();
                    newSpouse.marriageLocation.country = spousesReader["m_loc_country"].ToString();

                    newSoldier.spouses.Add(newSpouse);
                }

                //read children
                string readChildren = String.Format("select * from children where soldier_id={0};", newSoldier.id.ToString());
                readcommand = new SQLiteCommand(readChildren, m_dbConnection);
                SQLiteDataReader childrenReader = readcommand.ExecuteReader();

                while (childrenReader.Read())
                {
                    child newChild = new child();
                    newChild.name.first = childrenReader["f_name"].ToString();
                    newChild.name.middle = childrenReader["mid_name"].ToString();
                    newChild.name.last = childrenReader["l_name"].ToString();
                    newChild.name.maiden = childrenReader["maid_name"].ToString();
                    newChild.soldierID = Convert.ToInt32( childrenReader["soldier_id"]);
                    newChild.spouseID = Convert.ToInt32( childrenReader["spouse_id"]);

                    newSoldier.children.Add(newChild);
                }

                //read residences
                string readResidences = String.Format("select * from residences where soldier_id={0};", newSoldier.id.ToString());
                readcommand = new SQLiteCommand(readResidences, m_dbConnection);
                SQLiteDataReader resReader = readcommand.ExecuteReader();

                while (resReader.Read())
                {
                    residence newRes = new residence();
                    newRes.moveInDate.day = Convert.ToInt32(resReader["b_date_day"]);
                    newRes.moveInDate.month = Convert.ToInt32(resReader["b_date_month"]);
                    newRes.moveInDate.year = Convert.ToInt32(resReader["b_date_year"]);
                    newRes.moveOutDate.day = Convert.ToInt32(resReader["e_date_day"]);
                    newRes.moveOutDate.month = Convert.ToInt32(resReader["e_date_month"]);
                    newRes.moveOutDate.year = Convert.ToInt32(resReader["e_date_year"]);
                    newRes.place.city = resReader["city"].ToString();
                    newRes.place.county = resReader["county"].ToString();
                    newRes.place.state = resReader["state"].ToString();
                    newRes.place.country = resReader["country"].ToString();

                    newSoldier.residences.Add(newRes);
                }

                //read ranks
                string readPositions = String.Format("select * from ranks where soldier_id={0};", newSoldier.id.ToString());
                readcommand = new SQLiteCommand(readPositions, m_dbConnection);
                SQLiteDataReader posReader = readcommand.ExecuteReader();

                while (posReader.Read())
                {
                    newSoldier.servicePositions.Add(posReader["rank"].ToString());
                }

                //read troops
                string readTroops = String.Format("select * from troops where soldier_id={0};", newSoldier.id.ToString());
                readcommand = new SQLiteCommand(readTroops, m_dbConnection);
                SQLiteDataReader troopsReader = readcommand.ExecuteReader();

                while (troopsReader.Read())
                {
                    newSoldier.serviceTroops.Add(troopsReader["troop"].ToString());
                }

                //read superiors
                string readSuperiors = String.Format("select * from superiors where soldier_id={0};", newSoldier.id.ToString());
                readcommand = new SQLiteCommand(readSuperiors, m_dbConnection);
                SQLiteDataReader supReader = readcommand.ExecuteReader();

                while (supReader.Read())
                {
                    newSoldier.serviceSuperiors.Add(supReader["superior"].ToString());
                }

                newSoldier.serviceAddedText = reader["service_text"].ToString();
                newSoldier.residenceAddedText = reader["residence_text"].ToString();
                newSoldier.markerText = reader["marker_text"].ToString();
                newSoldier.pensionNumber = reader["pension_number"].ToString();
                newSoldier.pensionText = reader["pension_text"].ToString();
                newSoldier.sources = reader["sources"].ToString();
                newSoldier.addedText = reader["added_text"].ToString();


                soldiers.Add(newSoldier);
            }


            return soldiers;
        }

        //adds a soldier to the soldiers table.  Other tables are left alone.
        //PRE: Soldier must have unique id
        public void addSoldier(Soldier soldierToAdd)
        {
            /*
            string sql = string.Format("insert into soldiers (id, f_name, mid_name, l_name, maid_name, b_date_month, b_date_day, b_date_year, b_loc_city, b_loc_county, b_loc_state, b_loc_country, d_date_month, d_date_day, d_date_year, d_loc_city, d_loc_county, d_loc_state, d_loc_country, c_name, c_latitude, c_longitude, c_loc_city, c_loc_county, marker_text, pension_text, pension_number, sources, added_text, service_text) values ({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, '{8}', '{9}', '{10}', '{11}', {12}, {13}, {14}, '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}');",
                soldierToAdd.id.ToString(), soldierToAdd.soldierName.first, soldierToAdd.soldierName.middle, soldierToAdd.soldierName.last, soldierToAdd.soldierName.maiden,
                soldierToAdd.birthDate.month.ToString(), soldierToAdd.birthDate.day.ToString(), soldierToAdd.birthDate.year.ToString(),
                soldierToAdd.birthLocation.city, soldierToAdd.birthLocation.county, soldierToAdd.birthLocation.state, soldierToAdd.birthLocation.country,
                soldierToAdd.deathDate.month.ToString(), soldierToAdd.deathDate.day.ToString(), soldierToAdd.deathDate.year.ToString(),
                soldierToAdd.deathLocation.city, soldierToAdd.deathLocation.county, soldierToAdd.deathLocation.state, soldierToAdd.deathLocation.country,
                soldierToAdd.cemetery, soldierToAdd.cemeteryLatitude, soldierToAdd.cemeteryLongitude, soldierToAdd.cemeteryLocation.city, soldierToAdd.cemeteryLocation.county, 
                soldierToAdd.markerText, soldierToAdd.pensionText, soldierToAdd.pensionNumber, soldierToAdd.sources, soldierToAdd.addedText, soldierToAdd.serviceAddedText);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            */
            
            string sql = string.Format("insert into soldiers (id, f_name, mid_name, l_name, maid_name, b_date_month, b_date_day, b_date_year, b_loc_city, b_loc_county, b_loc_state, b_loc_country, d_date_month, d_date_day, d_date_year, d_loc_city, d_loc_county, d_loc_state, d_loc_country, c_name, c_latitude, c_longitude, c_loc_city, c_loc_county, c_loc_state, c_loc_country, marker_text, pension_text, pension_number, sources, added_text, service_text, residence_text) values ({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, '{8}', '{9}', '{10}', '{11}', {12}, {13}, {14}, '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}');",
                soldierToAdd.id.ToString(), soldierToAdd.soldierName.first, soldierToAdd.soldierName.middle, soldierToAdd.soldierName.last, soldierToAdd.soldierName.maiden,
                soldierToAdd.birthDate.month.ToString(), soldierToAdd.birthDate.day.ToString(), soldierToAdd.birthDate.year.ToString(),
                soldierToAdd.birthLocation.city, soldierToAdd.birthLocation.county, soldierToAdd.birthLocation.state, soldierToAdd.birthLocation.country,
                soldierToAdd.deathDate.month.ToString(), soldierToAdd.deathDate.day.ToString(), soldierToAdd.deathDate.year.ToString(),
                soldierToAdd.deathLocation.city, soldierToAdd.deathLocation.county, soldierToAdd.deathLocation.state, soldierToAdd.deathLocation.country,
                soldierToAdd.cemetery, soldierToAdd.cemeteryLatitude, soldierToAdd.cemeteryLongitude, soldierToAdd.cemeteryLocation.city, soldierToAdd.cemeteryLocation.county, soldierToAdd.cemeteryLocation.state, soldierToAdd.cemeteryLocation.country,
                soldierToAdd.markerText, soldierToAdd.pensionText, soldierToAdd.pensionNumber, soldierToAdd.sources, soldierToAdd.addedText, soldierToAdd.serviceAddedText, soldierToAdd.residenceAddedText);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
             

        }

        //removes soldier from soldiers table and removes all aphiliated data from other tables
        public void removeSoldier(Soldier soldierToRemove)
        {
            string sql = String.Format("delete from soldiers where id={0};",soldierToRemove.id);
            SQLiteCommand deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();

            sql = String.Format("delete from children where soldier_id={0};", soldierToRemove.id);
            deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();

            sql = String.Format("delete from ranks where soldier_id={0};", soldierToRemove.id);
            deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();

            sql = String.Format("delete from residences where soldier_id={0};", soldierToRemove.id);
            deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();

            sql = String.Format("delete from spouses where soldier_id={0};", soldierToRemove.id);
            deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();

            sql = String.Format("delete from superiors where soldier_id={0};", soldierToRemove.id);
            deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();

            sql = String.Format("delete from troops where soldier_id={0};", soldierToRemove.id);
            deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }

        //calls removeSoldier, then addSoldier
        //NOTICE: removes data from all tables, only adds back into soldiers table
        public void updateSoldier(Soldier soldierToUpdate)
        {
            removeSoldier(soldierToUpdate);
            addSoldier(soldierToUpdate);
        }

        //adds a spouse to the spouse table.  
        //PRE: must have unique ID
        public void addSpouse(spouse spouseToAdd,Int32 soldierID)
        {
            string sql = string.Format("insert into spouses (id, soldier_id, f_name, mid_name, l_name, maid_name, m_date_day, m_date_month, m_date_year, m_loc_city, m_loc_county, m_loc_state, m_loc_country) values ({0}, {1}, '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, '{9}', '{10}', '{11}', '{12}');",
                spouseToAdd.id, soldierID, spouseToAdd.name.first, spouseToAdd.name.middle, spouseToAdd.name.last, spouseToAdd.name.maiden,
                spouseToAdd.marriageDate.day, spouseToAdd.marriageDate.month, spouseToAdd.marriageDate.year,
                spouseToAdd.marriageLocation.city, spouseToAdd.marriageLocation.county, spouseToAdd.marriageLocation.state, spouseToAdd.marriageLocation.country); 
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();   
        }

        //remove all spouses that match the soldiers id
        public void removeSpouses(Soldier soldierSpousesToRemove)
        {
            string sql = String.Format("delete from spouses where soldier_id={0};", soldierSpousesToRemove.id);
            SQLiteCommand deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }

        //adds a child to the table. 
        public void addChild(child childToAdd, Int32 soldierID)
        {
            string sql = string.Format("insert into children (soldier_id, spouse_id, f_name, mid_name, l_name, maid_name) values ({0}, {1}, '{2}', '{3}', '{4}', '{5}');",
                soldierID, childToAdd.spouseID, childToAdd.name.first, childToAdd.name.middle, childToAdd.name.last, childToAdd.name.maiden);            
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();  
        }

        //remove all children that match soldiers id
        public void removeChildren(Soldier soldierChildrenToRemove)
        {
            string sql = String.Format("delete from children where soldier_id={0};", soldierChildrenToRemove.id);
            SQLiteCommand deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }

        //adds to the rank table
        public void addRank(String rankToAdd, Int32 soldierID)
        {
            string sql = string.Format("insert into ranks (soldier_id, rank) values ({0}, '{1}');",
                soldierID, rankToAdd);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //removes all ranks with soldierID
        public void removeRanks(Soldier soldierRanksToRemove)
        {
            string sql = String.Format("delete from ranks where soldier_id={0};", soldierRanksToRemove.id);
            SQLiteCommand deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }

        //add to the residence table
        public void addResidence(residence resToAdd, Int32 soldierID)
        {
            string sql = string.Format("insert into residences (soldier_id, b_date_day, b_date_month, b_date_year, e_date_day, e_date_month, e_date_year, city, county, state, country) values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', '{8}', '{9}', '{10}');",
                soldierID, resToAdd.moveInDate.day, resToAdd.moveInDate.month, resToAdd.moveInDate.year,
                resToAdd.moveOutDate.day, resToAdd.moveOutDate.month, resToAdd.moveOutDate.year,
                resToAdd.place.city, resToAdd.place.county, resToAdd.place.state, resToAdd.place.country);

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //removes all residences with soldierID
        public void removeResidences(Soldier soldierResidencesToRemove)
        {
            string sql = String.Format("delete from residences where soldier_id={0};", soldierResidencesToRemove.id);
            SQLiteCommand deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }

        //adds to the superiors table
        public void addSuperior(String superiorToAdd, Int32 soldierID)
        {
            string sql = string.Format("insert into superiors (soldier_id, superior) values ({0}, '{1}');",
                soldierID, superiorToAdd);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //removes all superiors with soldierID
        public void removeSuperiors(Soldier soldierSuperiorsToRemove)
        {
            string sql = String.Format("delete from superiors where soldier_id={0};", soldierSuperiorsToRemove.id);
            SQLiteCommand deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }

        //adds to the troops table
        public void addTroop(String troopToAdd, Int32 soldierID)
        {
            string sql = string.Format("insert into troops (soldier_id, troop) values ({0}, '{1}');",
                soldierID, troopToAdd);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //removes all troops with soldierID
        public void removeTroops(Soldier soldierTroopsToRemove)
        {
            string sql = String.Format("delete from troops where soldier_id={0};", soldierTroopsToRemove.id);
            SQLiteCommand deleteCommand = new SQLiteCommand(sql, m_dbConnection);
            deleteCommand.ExecuteNonQuery();
        }

        //returns a unique id to be used for a new soldier
        public Int32 findNewSoldierID()
        {
            Int32 id = -1;
            Int32 count = 1;
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);

            while (count > 0)
            {
                id++;
                cmd.CommandText = "select count(id) from soldiers where id=" + id + ";";
                //cmd.CommandType = CommandType.Text;
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return id;
        }

        //returns a unique id for the spouse table
        public Int32 findNewSpouseID()
        {
            Int32 id = 0;
            Int32 count = 1;
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);

            while (count > 0)
            {
                id++;
                cmd.CommandText = "select count(id) from spouses where id=" + id + ";";
                //cmd.CommandType = CommandType.Text;
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            //ids start at 1 because 0 indicates unknown spouse
            return id;
        }

        //children don't have an id, but this is left in case they do at some point.
        //public Int32 findNewChildID()
        //{
        //    Int32 id = -1;
        //    Int32 count = 1;
        //    SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);

        //    while (count > 0)
        //    {
        //        id++;
        //        cmd.CommandText = "select count(id) from children where id=" + id + ";";
        //        //cmd.CommandType = CommandType.Text;
        //        count = Convert.ToInt32(cmd.ExecuteScalar());
        //    }

        //    return id;
        //}
        //public Int32 findNewRankID()
        //{
        //    Int32 id = -1;
        //    Int32 count = 1;
        //    SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);

        //    while (count > 0)
        //    {
        //        id++;
        //        cmd.CommandText = "select count(id) from ranks where id=" + id + ";";
        //        //cmd.CommandType = CommandType.Text;
        //        count = Convert.ToInt32(cmd.ExecuteScalar());
        //    }

        //    return id;
        //}
        //public Int32 findNewresidenceID()
        //{
        //    Int32 id = -1;
        //    Int32 count = 1;
        //    SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);

        //    while (count > 0)
        //    {
        //        id++;
        //        cmd.CommandText = "select count(id) from residences where id=" + id + ";";
        //        //cmd.CommandType = CommandType.Text;
        //        count = Convert.ToInt32(cmd.ExecuteScalar());
        //    }

        //    return id;
        //}
        //public Int32 findNewSuperiorID()
        //{
        //    Int32 id = -1;
        //    Int32 count = 1;
        //    SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);

        //    while (count > 0)
        //    {
        //        id++;
        //        cmd.CommandText = "select count(id) from superiors where id=" + id + ";";
        //        //cmd.CommandType = CommandType.Text;
        //        count = Convert.ToInt32(cmd.ExecuteScalar());
        //    }

        //    return id;
        //}
        //public Int32 findNewTroopID()
        //{
        //    Int32 id = -1;
        //    Int32 count = 1;
        //    SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);

        //    while (count > 0)
        //    {
        //        id++;
        //        cmd.CommandText = "select count(id) from troops where id=" + id + ";";
        //        //cmd.CommandType = CommandType.Text;
        //        count = Convert.ToInt32(cmd.ExecuteScalar());
        //    }

        //    return id;
        //}
    }
}
