using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Soldiers
{
    public partial class SoldiersForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public String databaseFile = "";

        public SoldiersForm()
        {
            InitializeComponent();
            menuStripViewSoldierList_Click(null, null);

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listViewSoldiers.ListViewItemSorter = lvwColumnSorter;
        }

        public SoldiersForm(String db)
        {
            databaseFile = db;
            InitializeComponent();
            menuStripViewSoldierList_Click(null, null);

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listViewSoldiers.ListViewItemSorter = lvwColumnSorter;
        }

        //setups

        public void setupListviewForSoldierObjectPrint()
        {
            listViewSoldiers.Items.Clear();
            listViewSoldiers.Columns.Clear();
            listViewSoldiers.Columns.Add("Soldier Name", 100);
            listViewSoldiers.Columns.Add("Birth Date", 70);
            listViewSoldiers.Columns.Add("Birth Location", 100);
            listViewSoldiers.Columns.Add("Death Date", 70);
            listViewSoldiers.Columns.Add("Death Location", 100);
            listViewSoldiers.Columns.Add("Buried", 100);
            listViewSoldiers.Columns.Add("Burial Location", 100);
            listViewSoldiers.Columns.Add("# Spouses", 50);
            listViewSoldiers.Columns.Add("# Children", 50);
            listViewSoldiers.Columns.Add("# of Known Residences", 50);
            listViewSoldiers.Columns.Add("Service Position", 100);
            listViewSoldiers.Columns.Add("Service Troop", 100);
            listViewSoldiers.Columns.Add("Service Superior", 100);
            listViewSoldiers.Columns.Add("Pension #", 75);
            buttonDetails.Enabled = false;
            buttonRemoveSoldier.Enabled = false;
            buttonCreateDuplicate.Enabled = false;

        }

        private void listViewSoldiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSoldiers.SelectedItems.Count == 1)
            {
                buttonDetails.Enabled = true;
                buttonRemoveSoldier.Enabled = true;
                buttonCreateDuplicate.Enabled = true;
            }
            else
            {
                buttonDetails.Enabled = false;
                buttonRemoveSoldier.Enabled = false;
                buttonCreateDuplicate.Enabled = false;
            }
        }

        //menustrip

        public void menuStripViewSoldierList_Click(object sender, EventArgs e)
        {
            listViewSoldiers.View = View.Details;
            listViewSoldiers.GridLines = true;
            listViewSoldiers.FullRowSelect = true;
            setupListviewForSoldierObjectPrint();
            try
            {
                List<Soldier> printSoldiers = new database(databaseFile).Soldiers();
                foreach (Soldier s in printSoldiers)
                {
                    s.printToListView(listViewSoldiers);
                }
            }
            catch
            {
                MessageBox.Show("There was a problem reading the database.\nPlease verify file location and try again.");
            }

        }

        private void menuStripItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soldiers Buried in Illinois Database \nVersion 1.3 \nCreated by: Kyle Hershey \nDate: December 2012 \nContact: kwhershey@gmail.com");
        }

        private void menuStripItemPrintBook_Click(object sender, EventArgs e)
        {


            StreamWriter file; //NEW
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();//NEW

            List<String> spouseStrings = new List<String>();
            List<countySoldier> countyIndex = new List<countySoldier>();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";//NEW
            saveFileDialog1.FilterIndex = 1;//NEW
            saveFileDialog1.RestoreDirectory = true;//NEW

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//NEW
            {
                file = new StreamWriter(@saveFileDialog1.FileName.ToString());//NEW





                //StreamWriter file = new StreamWriter(@path + "book.txt");
                //StreamWriter texfile = new StreamWriter(@path +"book.tex");
                List<Soldier> soldiersToPrint = new database(databaseFile).Soldiers();
                soldiersToPrint.Sort();

                foreach (Soldier s in soldiersToPrint)
                {
                    //NAME
                    file.WriteLine("#" + s.soldierName.bookString() + "#");
                    //texfile.WriteLine("\\noindent \\textbf{" + s.soldierName.bookString() + "}\n");

                    //BORN:
                    if (s.birthDate.day == 0 && s.birthDate.month == 0 && s.birthDate.year == 0) //no date
                    {
                        if (s.birthLocation.ToString() != "")
                        {
                            file.WriteLine("Born: " + s.birthLocation.ToString());
                            //texfile.WriteLine("Born: " + s.birthLocation.ToString() + "\n");
                        }
                        //else nothing.  no born info
                    }
                    else
                    {
                        if (s.birthLocation.ToString() != "")
                        {
                            file.WriteLine("Born: " + s.birthDate.BookString() + " in " + s.birthLocation.ToString());
                            //texfile.WriteLine("Born: " + s.birthDate.BookString() + " in " + s.birthLocation.ToString() + "\n");
                        }
                        else
                        {
                            file.WriteLine("Born: " + s.birthDate.BookString());
                            //texfile.WriteLine("Born: " + s.birthDate.BookString() + "\n");
                        }
                    }

                    //DIED:
                    if (s.deathDate.day == 0 && s.deathDate.month == 0 && s.deathDate.year == 0) //no date
                    {
                        if (s.deathLocation.ToString() != "")
                        {
                            file.WriteLine("Died: " + s.deathLocation.ToString());
                            //texfile.WriteLine("Died: " + s.deathLocation.ToString() + "\n");
                        }
                        //else nothing.  no born info
                    }
                    else
                    {
                        if (s.deathLocation.ToString() != "")
                        {
                            file.WriteLine("Died: " + s.deathDate.BookString() + " in " + s.deathLocation.ToString());
                            //texfile.WriteLine("Died: " + s.deathDate.BookString() + " in " + s.deathLocation.ToString() + "\n");
                        }
                        else
                        {
                            file.WriteLine("Died: " + s.deathDate.BookString());
                            // texfile.WriteLine("Died: " + s.deathDate.BookString() + "\n");
                        }
                    }

                    //BURIED:
                    if (s.cemetery != "" || s.cemeteryLocation.ToString() != "" || s.cemeteryLatitude != "" || s.cemeteryLongitude != "")
                    {
                        file.Write("Buried: " + s.cemetery + " " + s.cemeteryLocation.ToString());  //latitude and longitude
                        if (s.cemeteryLatitude != "")
                        {
                            file.Write(" Latitude: " + s.cemeteryLatitude);
                            //texfile.Write(" Latitude: " + s.cemeteryLatitude);
                        }
                        if (s.cemeteryLongitude != "")
                        {
                            file.Write(" Longitude: " + s.cemeteryLongitude);
                            //texfile.Write(" Longitude: " + s.cemeteryLongitude);
                        }
                        file.WriteLine();
                        //texfile.WriteLine("\n");

                    }


                    //#####################################
                    //String indexCounty;
                    if (s.cemeteryLocation.county != "")
                    {
                        if (s.cemeteryLocation.isIllinoisCounty())
                            countyIndex.Add(new countySoldier(s.soldierName, s.cemeteryLocation.county));
                    }
                    else if (s.deathLocation.county != "")
                    {
                        if (s.deathLocation.isIllinoisCounty())
                            countyIndex.Add(new countySoldier(s.soldierName, s.deathLocation.county));
                    }


                    if (s.residences.Count > 0)
                    {
                        file.WriteLine("Residences: ");
                        foreach (residence r in s.residences)
                        {
                            file.WriteLine("    " + r.ToString());
                            //texfile.WriteLine("    " + r.ToString() + "\n");
                        }
                    }

                    if (s.spouses.Count > 0)
                    {
                        file.WriteLine("Spouses: ");
                        foreach (spouse sp in s.spouses)
                        {
                            file.WriteLine("    " + sp.ToString());
                            //texfile.WriteLine("    " + sp.ToString() + "\n");
                            spouseStrings.Add(sp.name.bookString() + "(" + s.soldierName.bookString() + ")"); //spousePrint
                        }
                    }
                    if (s.children.Count > 0)
                    {
                        file.WriteLine("Children: ");
                        foreach (child c in s.children)
                        {
                            file.WriteLine("    " + c.ToString());
                            //texfile.WriteLine("    " + c.ToString() + "\n");
                        }
                    }
                    if (s.serviceAddedText != "" || s.servicePositions.Count > 0 || s.serviceSuperiors.Count > 0 || s.serviceTroops.Count > 0)
                    {
                        file.WriteLine("Service: " + s.serviceAddedText);
                        //texfile.WriteLine("Service: " + s.serviceAddedText + "\n");
                        if (s.servicePositions.Count > 0)
                        {
                            file.WriteLine("    Positions: ");
                            //texfile.WriteLine("    Positions: \n");
                            foreach (String p in s.servicePositions)
                            {
                                file.WriteLine("        " + p);
                                //texfile.WriteLine("        " + p + "\n");
                            }
                        }
                        if (s.serviceTroops.Count > 0)
                        {
                            file.WriteLine("    Troops:");
                            //texfile.WriteLine("    Troops: \n");
                            foreach (String t in s.serviceTroops)
                            {
                                file.WriteLine("        " + t);
                                //texfile.WriteLine("        " + t + "\n");
                            }
                        }
                        if (s.serviceSuperiors.Count > 0)
                        {
                            file.WriteLine("    Superiors:");
                            //texfile.WriteLine("    Superiors: \n");
                            foreach (String sup in s.serviceSuperiors)
                            {
                                file.WriteLine("        " + sup);
                                //texfile.WriteLine("        " + sup + "\n");
                            }
                        }
                    }

                    if (s.pensionNumber != "" || s.pensionText != "")
                    {
                        file.WriteLine("Pension: " + s.pensionNumber + " " + s.pensionText);
                        //texfile.WriteLine("Pension: " + s.pensionNumber + " " + s.pensionText + "\n");
                    }
                    if (s.markerText != "")
                    {
                        file.WriteLine("Marker: " + s.markerText);
                        //texfile.WriteLine("Marker: " + s.markerText + "\n");
                    }

                    if (s.addedText != "")
                    {
                        file.WriteLine("Additional Info: " + s.addedText);
                        //texfile.WriteLine("Additional Info: " + s.addedText + "\n");
                    }

                    if (s.sources != "")
                    {
                        file.WriteLine("Sources: " + s.sources);
                        //texfile.WriteLine("Sources: " + s.sources + "\n");
                    }



                    file.WriteLine();


                }

                //indexes
                file.WriteLine("County Index:");
                countyIndex.Sort();
                String prev = "";
                List<String> soldiersInCounty = new List<String>();
                foreach (countySoldier c in countyIndex)
                {
                    if (c.county != prev)
                    {
                        soldiersInCounty.Sort();
                        foreach (String str in soldiersInCounty)
                        {
                            file.WriteLine("    " + str);
                        }
                        soldiersInCounty.Clear();
                        file.WriteLine(c.county + " County:");
                        prev = c.county;
                    }
                    soldiersInCounty.Add(c.soldierName.bookString());
                    //file.WriteLine(c.soldierName.bookString());
                }
                foreach (String str in soldiersInCounty)
                {
                    file.WriteLine("    " + str);
                }


                spouseStrings.Sort();
                file.WriteLine();

                file.WriteLine("Spouse Index:");

                foreach (String str in spouseStrings)
                {
                    file.WriteLine("    " + str);
                }



                file.Close();
            }
            //texfile.Close();


        }

        private void menuStripItemPrintLatexBook_Click(object sender, EventArgs e)
        {

            StreamWriter texfile; //NEW
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();//NEW

            List<String> spouseStrings = new List<String>();
            List<countySoldier> countyIndex = new List<countySoldier>();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";//NEW
            saveFileDialog1.FilterIndex = 2;//NEW
            saveFileDialog1.RestoreDirectory = true;//NEW

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//NEW
            {
                texfile = new StreamWriter(@saveFileDialog1.FileName.ToString());//NEW



                //StreamWriter file = new StreamWriter(@path + "book.txt");
                // StreamWriter texfile = new StreamWriter(@path + "book.tex");
                List<Soldier> soldiersToPrint = new database(databaseFile).Soldiers();
                soldiersToPrint.Sort();


                texfile.WriteLine("\\documentclass{article}");
                texfile.WriteLine("\\usepackage{fullpage}");
                texfile.WriteLine("\\usepackage{multicol}");
                texfile.WriteLine("\\begin{document}");

                foreach (Soldier s in soldiersToPrint)
                {
                    //NAME
                    //file.WriteLine("#" + s.soldierName.bookString() + "#");
                    texfile.WriteLine("\\noindent \\textbf{" + s.soldierName.bookString() + "}\n");

                    //BORN:
                    if (s.birthDate.day == 0 && s.birthDate.month == 0 && s.birthDate.year == 0) //no date
                    {
                        if (s.birthLocation.ToString() != "")
                        {
                            //file.WriteLine("Born: " + s.birthLocation.ToString());
                            texfile.WriteLine("Born: " + s.birthLocation.ToString() + "\n");
                        }
                        //else nothing.  no born info
                    }
                    else
                    {
                        if (s.birthLocation.ToString() != "")
                        {
                            // file.WriteLine("Born: " + s.birthDate.BookString() + " in " + s.birthLocation.ToString());
                            texfile.WriteLine("Born: " + s.birthDate.BookString() + " in " + s.birthLocation.ToString() + "\n");
                        }
                        else
                        {
                            //file.WriteLine("Born: " + s.birthDate.BookString());
                            texfile.WriteLine("Born: " + s.birthDate.BookString() + "\n");
                        }
                    }

                    //DIED:
                    if (s.deathDate.day == 0 && s.deathDate.month == 0 && s.deathDate.year == 0) //no date
                    {
                        if (s.deathLocation.ToString() != "")
                        {
                            //file.WriteLine("Died: " + s.deathLocation.ToString());
                            texfile.WriteLine("Died: " + s.deathLocation.ToString() + "\n");
                        }
                        //else nothing.  no born info
                    }
                    else
                    {
                        if (s.deathLocation.ToString() != "")
                        {
                            //file.WriteLine("Died: " + s.deathDate.BookString() + " in " + s.deathLocation.ToString());
                            texfile.WriteLine("Died: " + s.deathDate.BookString() + " in " + s.deathLocation.ToString() + "\n");
                        }
                        else
                        {
                            //file.WriteLine("Died: " + s.deathDate.BookString());
                            texfile.WriteLine("Died: " + s.deathDate.BookString() + "\n");
                        }
                    }

                    //BURIED:
                    if (s.cemetery != "" || s.cemeteryLocation.ToString() != "" || s.cemeteryLatitude != "" || s.cemeteryLongitude != "")
                    {
                        //file.Write("Buried: " + s.cemetery + " " + s.cemeteryLocation.ToString());  //latitude and longitude
                        texfile.Write("Buried: " + s.cemetery + " " + s.cemeteryLocation.ToString());
                        if (s.cemeteryLatitude != "")
                        {
                            //file.Write(" Latitude: " + s.cemeteryLatitude);
                            texfile.Write(" Latitude: " + s.cemeteryLatitude);
                        }
                        if (s.cemeteryLongitude != "")
                        {
                            //file.Write(" Longitude: " + s.cemeteryLongitude);
                            texfile.Write(" Longitude: " + s.cemeteryLongitude);
                        }
                        //file.WriteLine();
                        texfile.WriteLine("\n");

                    }

                    //#####################################
                    //String indexCounty;
                    if (s.cemeteryLocation.county != "")
                    {
                        if (s.cemeteryLocation.isIllinoisCounty())
                            countyIndex.Add(new countySoldier(s.soldierName, s.cemeteryLocation.county));
                    }
                    else if (s.deathLocation.county != "")
                    {
                        if (s.deathLocation.isIllinoisCounty())
                            countyIndex.Add(new countySoldier(s.soldierName, s.deathLocation.county));
                    }

                    if (s.residences.Count > 0)
                    {
                        //file.WriteLine("Residences: ");
                        texfile.WriteLine("Residences:\n");
                        foreach (residence r in s.residences)
                        {
                            //file.WriteLine("    " + r.ToString());
                            texfile.WriteLine("    " + r.ToString() + "\n");
                        }
                    }

                    if (s.spouses.Count > 0)
                    {
                        //file.WriteLine("Spouses: ");
                        texfile.WriteLine("Spouses:\n");
                        foreach (spouse sp in s.spouses)
                        {
                            //file.WriteLine("    " + sp.ToString());
                            texfile.WriteLine("    " + sp.ToString() + "\n");
                            spouseStrings.Add(sp.name.bookString() + "(" + s.soldierName.bookString() + ")"); //spousePrint
                        }
                    }
                    if (s.children.Count > 0)
                    {
                        //file.WriteLine("Children: ");
                        texfile.WriteLine("Children: \n");
                        foreach (child c in s.children)
                        {
                            //file.WriteLine("    " + c.ToString());
                            texfile.WriteLine("    " + c.ToString() + "\n");
                        }
                    }
                    if (s.serviceAddedText != "" || s.servicePositions.Count > 0 || s.serviceSuperiors.Count > 0 || s.serviceTroops.Count > 0)
                    {
                        //file.WriteLine("Service: " + s.serviceAddedText);
                        texfile.WriteLine("Service: " + s.serviceAddedText + "\n");
                        if (s.servicePositions.Count > 0)
                        {
                            //file.WriteLine("    Positions: ");
                            texfile.WriteLine("    Positions: \n");
                            foreach (String p in s.servicePositions)
                            {
                                //file.WriteLine("        " + p);
                                texfile.WriteLine("        " + p + "\n");
                            }
                        }
                        if (s.serviceTroops.Count > 0)
                        {
                            //file.WriteLine("    Troops:");
                            texfile.WriteLine("    Troops: \n");
                            foreach (String t in s.serviceTroops)
                            {
                                //file.WriteLine("        " + t);
                                texfile.WriteLine("        " + t + "\n");
                            }
                        }
                        if (s.serviceSuperiors.Count > 0)
                        {
                            //file.WriteLine("    Superiors:");
                            texfile.WriteLine("    Superiors: \n");
                            foreach (String sup in s.serviceSuperiors)
                            {
                                //file.WriteLine("        " + sup);
                                texfile.WriteLine("        " + sup + "\n");
                            }
                        }
                    }

                    if (s.pensionNumber != "" || s.pensionText != "")
                    {
                        //file.WriteLine("Pension: " + s.pensionNumber + " " + s.pensionText);
                        texfile.WriteLine("Pension: " + s.pensionNumber + " " + s.pensionText + "\n");
                    }
                    if (s.markerText != "")
                    {
                        //file.WriteLine("Marker: " + s.markerText);
                        texfile.WriteLine("Marker: " + s.markerText + "\n");
                    }

                    if (s.addedText != "")
                    {
                        //file.WriteLine("Additional Info: " + s.addedText);
                        texfile.WriteLine("Additional Info: " + s.addedText + "\n");
                    }

                    if (s.sources != "")
                    {
                        //file.WriteLine("Sources: " + s.sources);
                        texfile.WriteLine("Sources: " + s.sources + "\n");
                    }


                    //indexes



                }

                texfile.WriteLine("County Index:\n");
                countyIndex.Sort();
                String prev = "";
                List<String> soldiersInCounty = new List<String>();
                foreach (countySoldier c in countyIndex)
                {
                    if (c.county != prev)
                    {
                        soldiersInCounty.Sort();
                        foreach (String str in soldiersInCounty)
                        {
                            texfile.WriteLine(str + "\n");
                        }
                        soldiersInCounty.Clear();
                        texfile.WriteLine(c.county + " County:\n");
                        prev = c.county;
                    }
                    soldiersInCounty.Add(c.soldierName.bookString());
                    //texfile.WriteLine(c.soldierName.bookString()+"\n");
                }
                foreach (String str in soldiersInCounty)
                {
                    texfile.WriteLine(str + "\n");
                }



                spouseStrings.Sort();

                texfile.WriteLine("Spouse Index:\n");

                foreach (String str in spouseStrings)
                {
                    texfile.WriteLine(str+"\n");
                }



                texfile.WriteLine("\\end{document}");

                //file.Close();
                texfile.Close();
            }


        }

        private void menuStripItemOpenDatabase_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "s3db Files (*.s3db)|*.s3db";
            browseFile.Title = "Browse s3db files";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {
                //txtBrowse.Text = browseFile.FileName;
                SoldiersForm secondaryDatabase = new SoldiersForm(browseFile.FileName.ToString());
                secondaryDatabase.Show();
                secondaryDatabase.buttonSubmitToMaster.Show();
                secondaryDatabase.menuStripItemOpenDatabase.Enabled = false;
                secondaryDatabase.Text = "Secondary Database - " + browseFile.FileName.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "File Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuStripItemCreateDatabase_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();//NEW

            saveFileDialog1.Filter = "s3db files (*.s3db)|*.s3db";//NEW
            //saveFileDialog1.FilterIndex = 1;//NEW
            saveFileDialog1.RestoreDirectory = true;//NEW

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//NEW
            {
                String path = new database().path;
                System.IO.File.Copy(path + "soldierdb_template.s3db", saveFileDialog1.FileName.ToString(), true);
            }

            try
            {
                //txtBrowse.Text = browseFile.FileName;
                SoldiersForm secondaryDatabase = new SoldiersForm(saveFileDialog1.FileName.ToString());
                secondaryDatabase.Show();
                secondaryDatabase.buttonSubmitToMaster.Show();
                secondaryDatabase.menuStripItemOpenDatabase.Enabled = false;
                secondaryDatabase.Text = "Secondary Database - " + saveFileDialog1.FileName.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "File Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        //buttons

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            DetailsForm soldierForm = new DetailsForm( (Soldier)listViewSoldiers.SelectedItems[0].Tag , false,this);
            soldierForm.Show();
        }

        private void buttonAddSoldier_Click(object sender, EventArgs e)
        {
            //DetailsForm soldierForm = new DetailsForm(new Soldier() , true,this);
            DetailsForm soldierForm = new DetailsForm(this);
            soldierForm.Show();
        }

        private void buttonRemoveSoldier_Click(object sender, EventArgs e)
        {
            new database(databaseFile).removeSoldier((Soldier)listViewSoldiers.SelectedItems[0].Tag);
            menuStripViewSoldierList_Click(null, null);
        }

        private void buttonSubmitToMaster_Click(object sender, EventArgs e)
        {
            database master = new database();
            foreach (ListViewItem lvi in listViewSoldiers.Items)
            {
                Soldier newSoldier = (Soldier)lvi.Tag;
                newSoldier.id = master.findNewSoldierID();
                foreach (spouse sps in newSoldier.spouses)
                {
                    sps.id = -sps.id;   
                }
                foreach (child c in newSoldier.children)
                {
                    c.soldierID = newSoldier.id;
                    c.spouseID = -c.spouseID;
                }
                foreach (spouse sps in newSoldier.spouses)
                {
                    Int32 tempID = sps.id;
                    sps.id = master.findNewSpouseID();
                    foreach (child c in newSoldier.children)
                    {
                        if (c.spouseID == tempID)
                        {
                            c.spouseID = sps.id;
                        }
                    }
                }

                master.addSoldier(newSoldier);

                foreach (spouse s in newSoldier.spouses)
                {
                    master.addSpouse(s, newSoldier.id);
                }


                foreach (child c in newSoldier.children)
                {
                    master.addChild(c, newSoldier.id);
                }


                foreach (residence r in newSoldier.residences)
                {
                    master.addResidence(r, newSoldier.id);
                }


                foreach (String r in newSoldier.servicePositions)
                {
                    master.addRank(r, newSoldier.id);
                }


                foreach (String s in newSoldier.serviceSuperiors)
                {
                    master.addSuperior(s, newSoldier.id);
                }


                foreach (String t in newSoldier.serviceTroops)
                {
                    master.addTroop(t, newSoldier.id);
                }

                

            }
            this.Close();
        }

        private void buttonCreateDuplicate_Click(object sender, EventArgs e)
        {
            DetailsForm soldierForm = new DetailsForm((Soldier)listViewSoldiers.SelectedItems[0].Tag, true, this);
            soldierForm.Show();
        }

        //sorting and filtering

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            listViewSoldiers.Items.Clear();
            List<Soldier> printSoldiers = new database().Soldiers();

            String[] words = textBoxFilter.Text.Split(' ');
            bool containsAll;

            foreach (Soldier s in printSoldiers)
            {
                containsAll = true;
                foreach (String w in words)
                {
                    w.ToLower();
                    if (!s.filter(w))
                    {
                        containsAll = false;
                        break;
                    }
                }
                if(containsAll)
                    s.printToListView(listViewSoldiers);
            }
            
        }

        private void listViewSoldiers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewSoldiers.Sort();
        }

        private void menuStripItemAdvancedSearch_Click(object sender, EventArgs e)
        {
            SearchForm newSearch = new SearchForm(this);
            newSearch.Show();
        }











    }
}
