﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//This class is basically a copy of the details soldier, but trimmed down
namespace Soldiers
{
    public partial class SearchForm : Form
    {
        public Soldier detailsSoldier;
        public SoldiersForm parentForm;
        public String databaseFile = "";

        public SearchForm(SoldiersForm parent)
        {
            detailsSoldier = new Soldier();
            parentForm = parent;
            databaseFile = parent.databaseFile;
            InitializeComponent();
            setupForm();
        }

        public void setupForm()
        {
            listViewSpouses.View = View.Details;
            listViewSpouses.GridLines = true;
            listViewSpouses.FullRowSelect = true;
            listViewChildren.View = View.Details;
            listViewChildren.GridLines = true;
            listViewChildren.FullRowSelect = true;
            listViewSuperiors.View = View.Details;
            listViewSuperiors.GridLines = true;
            listViewSuperiors.FullRowSelect = true;
            listViewResidences.View = View.Details;
            listViewResidences.GridLines = true;
            listViewResidences.FullRowSelect = true;
            listViewTroops.View = View.Details;
            listViewTroops.GridLines = true;
            listViewTroops.FullRowSelect = true;
            listViewPositions.View = View.Details;
            listViewPositions.GridLines = true;
            listViewPositions.FullRowSelect = true;

            listViewSpouses.Items.Clear();
            listViewSpouses.Columns.Clear();
            listViewSpouses.Columns.Add("Spouse Name", 100);
            listViewSpouses.Columns.Add("Marriage Date", 100);
            listViewSpouses.Columns.Add("Marriage Location", 100);

            listViewChildren.Items.Clear();
            listViewChildren.Columns.Clear();
            listViewChildren.Columns.Add("Child Name", 100);

            listViewResidences.Items.Clear();
            listViewResidences.Columns.Clear();

            listViewResidences.Columns.Add("Location", 100);
            listViewResidences.Columns.Add("Move in Date", 100);
            listViewResidences.Columns.Add("Move out Date", 100);

            listViewPositions.Items.Clear();
            listViewPositions.Columns.Clear();
            listViewPositions.Columns.Add("Position", 100);

            listViewTroops.Items.Clear();
            listViewTroops.Columns.Clear();
            listViewTroops.Columns.Add("Troop", 100);

            listViewSuperiors.Items.Clear();
            listViewSuperiors.Columns.Clear();
            listViewSuperiors.Columns.Add("Superior Name", 100);

            comboBoxBirthDay.SelectedIndex = 0;
            comboBoxBirthMonth.SelectedIndex = 0;
            comboBoxBirthYear.SelectedIndex = 0;
            comboBoxDeathDay.SelectedIndex = 0;
            comboBoxDeathMonth.SelectedIndex = 0;
            comboBoxDeathYear.SelectedIndex = 0;
            comboBoxMarriageDay.SelectedIndex = 0;
            comboBoxMarriageMonth.SelectedIndex = 0;
            comboBoxMarriageYear.SelectedIndex = 0;
            comboBoxMoveInDay.SelectedIndex = 0;
            comboBoxMoveInMonth.SelectedIndex = 0;
            comboBoxMoveInYear.SelectedIndex = 0;
            comboBoxMoveOutDay.SelectedIndex = 0;
            comboBoxMoveOutMonth.SelectedIndex = 0;
            comboBoxMoveOutYear.SelectedIndex = 0;

            buttonAddChild.Enabled = false;
            buttonAddPosition.Enabled = false;
            buttonAddResidence.Enabled = false;
            buttonAddSpouse.Enabled = false;
            buttonAddSuperior.Enabled = false;
            buttonAddTroop.Enabled = false;
            buttonUpdateChild.Enabled = false;
            buttonUpdatePosition.Enabled = false;
            buttonUpdateResidence.Enabled = false;
            buttonUpdateSpouse.Enabled = false;
            buttonUpdateSuperior.Enabled = false;
            buttonUpdateTroop.Enabled = false;
            buttonRemoveChild.Enabled = false;
            buttonRemovePosition.Enabled = false;
            buttonRemoveResidence.Enabled = false;
            buttonRemoveSpouse.Enabled = false;
            buttonRemoveSuperior.Enabled = false;
            buttonRemoveTroop.Enabled = false;

            comboBoxMother.Enabled = false;
        }

        //buttons

        //buttons

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //THIS NOW DOES SEARCHING.  DOES NOT ADD TO DATABASE
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            database db = new database(databaseFile);

            detailsSoldier.soldierName.first = textBoxSoldierFirstName.Text;
            detailsSoldier.soldierName.middle = textBoxSoldierMiddleName.Text;
            detailsSoldier.soldierName.last = textBoxSoldierLastName.Text;
            detailsSoldier.soldierName.maiden = textBoxSoldierMaidenName.Text;
            detailsSoldier.birthDate.day = comboDaytoInt(comboBoxBirthDay);
            detailsSoldier.birthDate.month = comboMonthtoInt(comboBoxBirthMonth);
            detailsSoldier.birthDate.year = comboYeartoInt(comboBoxBirthYear);
            detailsSoldier.birthLocation.city = textBoxBirthCity.Text;
            detailsSoldier.birthLocation.county = comboBoxBirthCounty.Text;
            detailsSoldier.birthLocation.state = textBoxBirthState.Text;
            detailsSoldier.birthLocation.country = textBoxBirthCountry.Text;
            detailsSoldier.deathDate.day = comboDaytoInt(comboBoxDeathDay);
            detailsSoldier.deathDate.month = comboMonthtoInt(comboBoxDeathMonth);
            detailsSoldier.deathDate.year = comboYeartoInt(comboBoxDeathYear);
            detailsSoldier.deathLocation.city = textBoxDeathCity.Text;
            detailsSoldier.deathLocation.county = comboBoxDeathCounty.Text;
            detailsSoldier.deathLocation.state = textBoxDeathState.Text;
            detailsSoldier.deathLocation.country = textBoxDeathCountry.Text;
            detailsSoldier.cemetery = textBoxCemetery.Text;
            detailsSoldier.cemeteryLatitude = textBoxLatitude.Text;
            detailsSoldier.cemeteryLongitude = textBoxLongitude.Text;
            detailsSoldier.cemeteryLocation.city = textBoxCemeteryCity.Text;
            detailsSoldier.cemeteryLocation.county = comboBoxCemeteryCounty.Text;
            detailsSoldier.cemeteryLocation.state = textBoxCemeteryState.Text;
            detailsSoldier.cemeteryLocation.country = textBoxCemeteryCountry.Text;
            detailsSoldier.serviceAddedText = textBoxService.Text;
            detailsSoldier.residenceAddedText = textBoxResidenceAddedText.Text;

            List<String> newPositionList = new List<String>();
            foreach (ListViewItem lvi in listViewPositions.Items)
            {
                newPositionList.Add((String)lvi.Tag);
            }
            detailsSoldier.servicePositions = newPositionList;

            List<String> newTroopList = new List<String>();
            foreach (ListViewItem lvi in listViewTroops.Items)
            {
                newTroopList.Add((String)lvi.Tag);
            }
            detailsSoldier.serviceTroops = newTroopList;

            List<String> newSuperiorsList = new List<String>();
            foreach (ListViewItem lvi in listViewSuperiors.Items)
            {
                newSuperiorsList.Add((String)lvi.Tag);
            }
            detailsSoldier.serviceSuperiors = newSuperiorsList;

            detailsSoldier.pensionNumber = textBoxPension.Text;
            detailsSoldier.pensionText = textBoxPensionDetails.Text;

            List<spouse> newSpouseList = new List<spouse>();
            foreach (ListViewItem lvi in listViewSpouses.Items)
            {
                //if (((spouse)lvi.Tag).id > 0)
                //    newSpouseList.Add((spouse)lvi.Tag);
                //else
                //{
                //    Int32 tempID = ((spouse)lvi.Tag).id;
                //    ((spouse)lvi.Tag).id = db.findNewSpouseID();
                //    foreach (ListViewItem childItem in listViewChildren.Items)
                //    {
                //        if (((child)childItem.Tag).spouseID == tempID)
                //        {
                //            ((child)childItem.Tag).spouseID = ((spouse)lvi.Tag).id;
                //        }
                //    }
                    newSpouseList.Add((spouse)lvi.Tag);
                //}
            }
            detailsSoldier.spouses = newSpouseList;

            List<child> newChildrenList = new List<child>();
            foreach (ListViewItem lvi in listViewChildren.Items)
            {
                newChildrenList.Add((child)lvi.Tag);
            }
            detailsSoldier.children = newChildrenList;

            List<residence> newResidenceList = new List<residence>();
            foreach (ListViewItem lvi in listViewResidences.Items)
            {
                newResidenceList.Add((residence)lvi.Tag);
            }
            detailsSoldier.residences = newResidenceList;

            detailsSoldier.markerText = textBoxMarker.Text;
            detailsSoldier.addedText = textBoxExtra.Text;
            detailsSoldier.sources = textBoxSources.Text;

            //detailsSoldier is compiled
            //search now
            parentForm.setupListviewForSoldierObjectPrint();
            foreach (Soldier s in db.Soldiers())
            {
                if( s.soldierName.first.ToLower().Contains(detailsSoldier.soldierName.first.ToLower()) &&
                    s.soldierName.middle.ToLower().Contains(detailsSoldier.soldierName.middle.ToLower()) &&
                    s.soldierName.last.ToLower().Contains(detailsSoldier.soldierName.last.ToLower()) &&
                    s.soldierName.maiden.ToLower().Contains(detailsSoldier.soldierName.maiden.ToLower()) &&
                    (detailsSoldier.birthDate.day==0 ? true : detailsSoldier.birthDate.day==s.birthDate.day) &&
                    (detailsSoldier.birthDate.month==0 ? true : detailsSoldier.birthDate.month==s.birthDate.month) &&
                    (detailsSoldier.birthDate.year==0 ? true : detailsSoldier.birthDate.year==s.birthDate.year) &&
                    s.birthLocation.city.ToLower().Contains(detailsSoldier.birthLocation.city.ToLower()) &&
                    s.birthLocation.county.ToLower().Contains(detailsSoldier.birthLocation.county.ToLower()) &&
                    s.birthLocation.country.ToLower().Contains(detailsSoldier.birthLocation.country.ToLower()) &&
                    s.birthLocation.state.ToLower().Contains(detailsSoldier.birthLocation.state.ToLower()) &&
                    (detailsSoldier.deathDate.day==0 ? true : detailsSoldier.deathDate.day==s.deathDate.day) &&
                    (detailsSoldier.deathDate.month==0 ? true : detailsSoldier.deathDate.month==s.deathDate.month) &&
                    (detailsSoldier.deathDate.year==0 ? true : detailsSoldier.deathDate.year==s.deathDate.year) &&
                    s.deathLocation.city.ToLower().Contains(detailsSoldier.deathLocation.city.ToLower()) &&
                    s.deathLocation.county.ToLower().Contains(detailsSoldier.deathLocation.county.ToLower()) &&
                    s.deathLocation.country.ToLower().Contains(detailsSoldier.deathLocation.country.ToLower()) &&
                    s.deathLocation.state.ToLower().Contains(detailsSoldier.deathLocation.state.ToLower()) &&
                    s.cemetery.ToLower().Contains(detailsSoldier.cemetery.ToLower()) &&
                    s.cemeteryLatitude.ToLower().Contains(detailsSoldier.cemeteryLatitude.ToLower()) &&
                    s.cemeteryLongitude.ToLower().Contains(detailsSoldier.cemeteryLongitude.ToLower()) &&
                    s.cemeteryLocation.city.ToLower().Contains(detailsSoldier.cemeteryLocation.city.ToLower()) &&
                    s.cemeteryLocation.county.ToLower().Contains(detailsSoldier.cemeteryLocation.county.ToLower()) &&
                    s.cemeteryLocation.country.ToLower().Contains(detailsSoldier.cemeteryLocation.country.ToLower()) &&
                    s.cemeteryLocation.state.ToLower().Contains(detailsSoldier.cemeteryLocation.state.ToLower()) &&
                    s.pensionNumber.ToLower().Contains(detailsSoldier.pensionNumber.ToLower())
                    )
                    {
                        bool valid = true;
                        String[] serviceWords = detailsSoldier.serviceAddedText.Split(' ');
                        foreach (String str in serviceWords)
                        {
                            if (!s.serviceAddedText.ToLower().Contains(str.ToLower()))
                            {
                                valid = false;
                                break;
                            }
                        }
                        
                        String[] residenceWords = detailsSoldier.residenceAddedText.Split(' ');
                        foreach (String str in residenceWords)
                        {
                            if (!s.residenceAddedText.ToLower().Contains(str.ToLower()))
                            {
                                valid = false;
                                break;
                            }
                        }
                        String[] markerWords = detailsSoldier.markerText.Split(' ');
                        foreach (String str in markerWords)
                        {
                            if (!s.markerText.ToLower().Contains(str.ToLower()))
                            {
                                valid = false;
                                break;
                            }
                        }
                        String[] pensionWords = detailsSoldier.pensionText.Split(' ');
                        foreach (String str in pensionWords)
                        {
                            if (!s.pensionText.ToLower().Contains(str.ToLower()))
                            {
                                valid = false;
                                break;
                            }
                        }
                        String[] sourcesWords = detailsSoldier.sources.Split(' ');
                        foreach (String str in sourcesWords)
                        {
                            if (!s.sources.ToLower().Contains(str.ToLower()))
                            {
                                valid = false;
                                break;
                            }
                        }
                        String[] addedWords = detailsSoldier.addedText.Split(' ');
                        foreach (String str in addedWords)
                        {
                            if (!s.addedText.ToLower().Contains(str.ToLower()))
                            {
                                valid = false;
                                break;
                            }
                        }
                        foreach (spouse sps in detailsSoldier.spouses)
                        {
                            bool found = false;
                            foreach (spouse sps2 in s.spouses)
                            {
                                if(sps2.name.first.ToLower().Contains(sps.name.first.ToLower()) &&
                                    sps2.name.middle.ToLower().Contains(sps.name.middle.ToLower()) &&
                                    sps2.name.last.ToLower().Contains(sps.name.last.ToLower()) &&
                                    sps2.name.maiden.ToLower().Contains(sps.name.maiden.ToLower()) &&
                                    sps2.marriageLocation.city.ToLower().Contains(sps.marriageLocation.city.ToLower()) &&
                                    sps2.marriageLocation.county.ToLower().Contains(sps.marriageLocation.county.ToLower()) &&
                                    sps2.marriageLocation.state.ToLower().Contains(sps.marriageLocation.state.ToLower()) &&
                                    sps2.marriageLocation.country.ToLower().Contains(sps.marriageLocation.country.ToLower()) &&
                                    (sps.marriageDate.day==0 ? true : sps.marriageDate.day==sps2.marriageDate.day) &&
                                    (sps.marriageDate.month==0 ? true : sps.marriageDate.month==sps2.marriageDate.month) &&
                                    (sps.marriageDate.year==0 ? true : sps.marriageDate.year==sps2.marriageDate.year)
                                    )
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                valid = false;
                                break;
                            }
                        }
                        foreach (child chld in detailsSoldier.children)
                        {
                            bool found = false;
                            foreach (child chld2 in s.children)
                            {
                                if (chld2.name.first.ToLower().Contains(chld.name.first.ToLower()) &&
                                    chld2.name.middle.ToLower().Contains(chld.name.middle.ToLower()) &&
                                    chld2.name.last.ToLower().Contains(chld.name.last.ToLower()) &&
                                    chld2.name.maiden.ToLower().Contains(chld.name.maiden.ToLower())
                                    )
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                valid = false;
                                break;
                            }
                        }
                        foreach (residence res in detailsSoldier.residences)
                        {
                            bool found = false;
                            foreach (residence res2 in s.residences)
                            {
                                if(res2.place.city.ToLower().Contains(res.place.city.ToLower()) &&
                                    res2.place.county.ToLower().Contains(res.place.county.ToLower()) &&
                                    res2.place.state.ToLower().Contains(res.place.state.ToLower()) &&
                                    res2.place.country.ToLower().Contains(res.place.country.ToLower()) &&
                                    (res.moveInDate.day == 0 ? true : res.moveInDate.day == res2.moveInDate.day) &&
                                    (res.moveInDate.month == 0 ? true : res.moveInDate.month == res2.moveInDate.month) &&
                                    (res.moveInDate.year == 0 ? true : res.moveInDate.year == res2.moveInDate.year) &&
                                    (res.moveOutDate.day == 0 ? true : res.moveOutDate.day == res2.moveOutDate.day) &&
                                    (res.moveOutDate.month == 0 ? true : res.moveOutDate.month == res2.moveOutDate.month) &&
                                    (res.moveOutDate.year == 0 ? true : res.moveOutDate.year == res2.moveOutDate.year)
                                    )
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                valid = false;
                                break;
                            }
                        }
                        foreach (String str in detailsSoldier.servicePositions)
                        {
                            bool found = false;
                            foreach (String str2 in s.servicePositions)
                            {
                                if (str2.ToLower().Contains(str.ToLower()))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                valid = false;
                                break;
                            }
                        }
                        foreach (String str in detailsSoldier.serviceTroops)
                        {
                            bool found = false;
                            foreach (String str2 in s.serviceTroops)
                            {
                                if (str2.ToLower().Contains(str.ToLower()))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                valid = false;
                                break;
                            }
                        }
                        foreach (String str in detailsSoldier.serviceSuperiors)
                        {
                            bool found = false;
                            foreach (String str2 in s.serviceSuperiors)
                            {
                                if (str2.ToLower().Contains(str.ToLower()))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                valid = false;
                                break;
                            }
                        }
                        
                        //finally, lets check if its valid, and if so, print it
                        if (valid)
                        {
                            s.printToListView(parentForm.listViewSoldiers);
                        }
                    }
            }


            //parentForm.menuStripViewSoldierList_Click(null, null);
            this.Close();
        }

        private void buttonAddPosition_Click(object sender, EventArgs e)
        {
            string[] newPos = { textBoxPosition.Text };
            ListViewItem newItem = new ListViewItem(newPos);
            newItem.Tag = textBoxPosition.Text;
            listViewPositions.Items.Add(newItem);

            //clear
            textBoxPosition.Clear();
        }

        private void buttonAddTroop_Click(object sender, EventArgs e)
        {
            string[] newTroop = { textBoxTroop.Text };
            ListViewItem newItem = new ListViewItem(newTroop);
            newItem.Tag = textBoxTroop.Text;
            listViewTroops.Items.Add(newItem);

            //clear
            textBoxTroop.Clear();
        }

        private void buttonAddSuperior_Click(object sender, EventArgs e)
        {
            string[] newSuperior = { textBoxSuperior.Text };
            ListViewItem newItem = new ListViewItem(newSuperior);
            newItem.Tag = textBoxSuperior.Text;
            listViewSuperiors.Items.Add(newItem);

            //clear
            textBoxSuperior.Clear();
        }

        private void buttonAddSpouse_Click(object sender, EventArgs e)
        {
            spouse newSpouse = new spouse();
            newSpouse.name.first = textBoxSpouseFirstName.Text;
            newSpouse.name.middle = textBoxSpouseMiddleName.Text;
            newSpouse.name.last = textBoxSpouseLastName.Text;
            newSpouse.name.maiden = textBoxSpouseMaidenName.Text;

            //assign temp id
            Int32 tempID = 0;
            bool found = false;
            while (!found)
            {
                tempID--;
                found = true;
                foreach (ListViewItem lvi in listViewSpouses.Items)
                {
                    if (((spouse)lvi.Tag).id == tempID)
                        found = false;
                }
            }
            newSpouse.id = tempID;

            //MessageBox.Show(tempID.ToString());

            newSpouse.marriageDate.day = comboDaytoInt(comboBoxMarriageDay);
            newSpouse.marriageDate.month = comboMonthtoInt(comboBoxMarriageMonth);
            newSpouse.marriageDate.year = comboYeartoInt(comboBoxMarriageYear);
            newSpouse.marriageLocation.city = textBoxMarriageCity.Text;
            newSpouse.marriageLocation.county = comboBoxMarriageCounty.Text;
            newSpouse.marriageLocation.state = textBoxMarriageState.Text;
            newSpouse.marriageLocation.country = textBoxMarriageCountry.Text;

            string[] spouseLine = { newSpouse.name.ToString(), newSpouse.marriageDate.ToString(), newSpouse.marriageLocation.ToString() };
            ListViewItem newItem = new ListViewItem(spouseLine);
            newItem.Tag = newSpouse;
            listViewSpouses.Items.Add(newItem);

            //clear
            textBoxSpouseFirstName.Clear();
            textBoxSpouseLastName.Clear();
            textBoxSpouseMiddleName.Clear();
            textBoxSpouseMaidenName.Clear();
            textBoxMarriageCity.Clear();
            textBoxMarriageCountry.Clear();
            comboBoxMarriageCounty.Text="";
            textBoxMarriageState.Clear();
            comboBoxMarriageDay.SelectedIndex = 0;
            comboBoxMarriageMonth.SelectedIndex = 0;
            comboBoxMarriageYear.SelectedIndex = 0;
        }

        private void buttonAddChild_Click(object sender, EventArgs e)
        {
            child c = new child();
            c.name.first = textBoxChildFirstName.Text;
            c.name.middle = textBoxChildMiddleName.Text;
            c.name.last = textBoxChildLastName.Text;
            c.name.maiden = textBoxChildMaidenName.Text;
            try
            {
                c.spouseID = ((comboMother)comboBoxMother.SelectedItem).mother.id;
            }
            catch
            {
                c.spouseID = 0;
            }


            string[] childLine = { c.ToString() };
            ListViewItem newItem = new ListViewItem(childLine);
            newItem.Tag = c;
            listViewChildren.Items.Add(newItem);

            //clear
            textBoxChildFirstName.Clear();
            textBoxChildLastName.Clear();
            textBoxChildMaidenName.Clear();
            textBoxChildMiddleName.Clear();
            //comboBoxMother.SelectedIndex = 0;
        }

        private void buttonAddResidence_Click(object sender, EventArgs e)
        {
            residence newResidence = new residence();
            newResidence.place.city = textBoxResidenceCity.Text;
            newResidence.place.county = comboBoxResidenceCounty.Text;
            newResidence.place.state = textBoxResidenceState.Text;
            newResidence.place.country = textBoxResidenceCountry.Text;
            newResidence.moveInDate.day = comboDaytoInt(comboBoxMoveInDay);
            newResidence.moveInDate.month = comboMonthtoInt(comboBoxMoveInMonth);
            newResidence.moveInDate.year = comboYeartoInt(comboBoxMoveInYear);
            newResidence.moveOutDate.day = comboDaytoInt(comboBoxMoveOutDay);
            newResidence.moveOutDate.month = comboMonthtoInt(comboBoxMoveOutMonth);
            newResidence.moveOutDate.year = comboYeartoInt(comboBoxMoveOutYear);

            string[] resLine = { newResidence.place.ToString(), newResidence.moveInDate.ToString(), newResidence.moveOutDate.ToString() };
            ListViewItem newItem = new ListViewItem(resLine);
            newItem.Tag = newResidence;
            listViewResidences.Items.Add(newItem);

            //clear
            textBoxResidenceCity.Clear();
            textBoxResidenceCountry.Clear();
            comboBoxResidenceCounty.Text="";
            textBoxResidenceState.Clear();
            comboBoxMoveInDay.SelectedIndex = 0;
            comboBoxMoveInMonth.SelectedIndex = 0;
            comboBoxMoveInYear.SelectedIndex = 0;
            comboBoxMoveOutDay.SelectedIndex = 0;
            comboBoxMoveOutMonth.SelectedIndex = 0;
            comboBoxMoveOutYear.SelectedIndex = 0;

        }

        private void buttonRemovePosition_Click(object sender, EventArgs e)
        {
            listViewPositions.Items.Remove(listViewPositions.SelectedItems[0]);

            //clear
            textBoxPosition.Clear();
        }

        private void buttonRemoveTroop_Click(object sender, EventArgs e)
        {
            listViewTroops.Items.Remove(listViewTroops.SelectedItems[0]);

            //clear
            textBoxTroop.Clear();
        }

        private void buttonRemoveSuperior_Click(object sender, EventArgs e)
        {
            listViewSuperiors.Items.Remove(listViewSuperiors.SelectedItems[0]);

            //clear
            textBoxSuperior.Clear();
        }

        private void buttonRemoveSpouse_Click(object sender, EventArgs e)
        {
            Int32 sID = ((spouse)listViewSpouses.SelectedItems[0].Tag).id;
            foreach (ListViewItem lvi in listViewChildren.Items)
            {
                if (((child)lvi.Tag).spouseID == sID)
                    ((child)lvi.Tag).spouseID = 0;
            }

            listViewSpouses.Items.Remove(listViewSpouses.SelectedItems[0]);

            //clear
            textBoxSpouseFirstName.Clear();
            textBoxSpouseLastName.Clear();
            textBoxSpouseMiddleName.Clear();
            textBoxSpouseMaidenName.Clear();
            textBoxMarriageCity.Clear();
            textBoxMarriageCountry.Clear();
            comboBoxMarriageCounty.Text="";
            textBoxMarriageState.Clear();
            comboBoxMarriageDay.SelectedIndex = 0;
            comboBoxMarriageMonth.SelectedIndex = 0;
            comboBoxMarriageYear.SelectedIndex = 0;


        }

        private void buttonRemoveChild_Click(object sender, EventArgs e)
        {
            listViewChildren.Items.Remove(listViewChildren.SelectedItems[0]);

            //clear
            textBoxChildFirstName.Clear();
            textBoxChildLastName.Clear();
            textBoxChildMaidenName.Clear();
            textBoxChildMiddleName.Clear();
            comboBoxMother.SelectedIndex = 0;
        }

        private void buttonRemoveResidence_Click(object sender, EventArgs e)
        {
            listViewResidences.Items.Remove(listViewResidences.SelectedItems[0]);

            //clear
            textBoxResidenceCity.Clear();
            textBoxResidenceCountry.Clear();
            comboBoxResidenceCounty.Text="";
            textBoxResidenceState.Clear();
            comboBoxMoveInDay.SelectedIndex = 0;
            comboBoxMoveInMonth.SelectedIndex = 0;
            comboBoxMoveInYear.SelectedIndex = 0;
            comboBoxMoveOutDay.SelectedIndex = 0;
            comboBoxMoveOutMonth.SelectedIndex = 0;
            comboBoxMoveOutYear.SelectedIndex = 0;
        }

        private void buttonUpdatePosition_Click(object sender, EventArgs e)
        {
            
            buttonAddPosition_Click(null, null);
            listViewPositions.Items.RemoveAt(listViewPositions.SelectedIndices[0]);
        }

        private void buttonUpdateTroop_Click(object sender, EventArgs e)
        {
            
            buttonAddTroop_Click(null, null);
            listViewTroops.Items.RemoveAt(listViewTroops.SelectedIndices[0]);
        }

        private void buttonUpdateSuperior_Click(object sender, EventArgs e)
        {
            
            buttonAddSuperior_Click(null, null);
            listViewSuperiors.Items.RemoveAt(listViewSuperiors.SelectedIndices[0]);
        }

        private void buttonUpdateSpouse_Click(object sender, EventArgs e)
        {
            
            buttonAddSpouse_Click(null, null);
            listViewSpouses.Items.RemoveAt(listViewSpouses.SelectedIndices[0]);
        }

        private void buttonUpdateChild_Click(object sender, EventArgs e)
        {
            
            buttonAddChild_Click(null, null);
            listViewChildren.Items.RemoveAt(listViewChildren.SelectedIndices[0]);
        }

        private void buttonUpdateResidence_Click(object sender, EventArgs e)
        {
            
            buttonAddResidence_Click(null, null);
            listViewResidences.Items.RemoveAt(listViewResidences.SelectedIndices[0]);
        }

        //textbox checking

        private void textBoxPosition_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPosition.Text != "")
                buttonAddPosition.Enabled = true;
            else buttonAddPosition.Enabled = false;
        }

        private void textBoxTroop_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTroop.Text != "")
                buttonAddTroop.Enabled = true;
            else buttonAddTroop.Enabled = false;
        }

        private void textBoxSuperior_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSuperior.Text != "")
                buttonAddSuperior.Enabled = true;
            else buttonAddSuperior.Enabled = false;
        }

        private void textBoxSpouseFirstName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSpouseFirstName.Text == "" && textBoxSpouseLastName.Text == "")
                buttonAddSpouse.Enabled = false;
            else buttonAddSpouse.Enabled = true;
        }

        private void textBoxSpouseLastName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSpouseFirstName.Text == "" && textBoxSpouseLastName.Text == "")
                buttonAddSpouse.Enabled = false;
            else buttonAddSpouse.Enabled = true;
        }

        private void textBoxChildFirstName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxChildFirstName.Text != "")
                buttonAddChild.Enabled = true;
            else buttonAddChild.Enabled = false;
        }

        private void textBoxResidenceCity_TextChanged(object sender, EventArgs e)
        {
            if (textBoxResidenceCity.Text == "" && comboBoxResidenceCounty.Text == ""
                && textBoxResidenceState.Text == "" && textBoxResidenceCountry.Text == "")
                buttonAddResidence.Enabled = false;
            else buttonAddResidence.Enabled = true;
        }

        private void comboBoxResidenceCounty_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxResidenceCounty.Text.Contains("County") || comboBoxResidenceCounty.Text.Contains("county"))
                MessageBox.Show("Please exclude the word \"County\"");

            if (textBoxResidenceCity.Text == "" && comboBoxResidenceCounty.Text == ""
                && textBoxResidenceState.Text == "" && textBoxResidenceCountry.Text == "")
                buttonAddResidence.Enabled = false;
            else buttonAddResidence.Enabled = true;
        }

        private void textBoxResidenceState_TextChanged(object sender, EventArgs e)
        {
            if (
         textBoxResidenceState.Text.Contains("AL") ||
         textBoxResidenceState.Text.Contains("AK") ||
         textBoxResidenceState.Text.Contains("AS") ||
         textBoxResidenceState.Text.Contains("AZ") ||
         textBoxResidenceState.Text.Contains("AR") ||
         textBoxResidenceState.Text.Contains("CA") ||
         textBoxResidenceState.Text.Contains("CO") ||
         textBoxResidenceState.Text.Contains("CT") ||
         textBoxResidenceState.Text.Contains("DE") ||
         textBoxResidenceState.Text.Contains("FL") ||
         textBoxResidenceState.Text.Contains("GA") ||
         textBoxResidenceState.Text.Contains("HI") ||
         textBoxResidenceState.Text.Contains("ID") ||
         textBoxResidenceState.Text.Contains("IL") ||
         textBoxResidenceState.Text.Contains("IN") ||
         textBoxResidenceState.Text.Contains("IA") ||
         textBoxResidenceState.Text.Contains("KS") ||
         textBoxResidenceState.Text.Contains("KY") ||
         textBoxResidenceState.Text.Contains("LA") ||
         textBoxResidenceState.Text.Contains("ME") ||
         textBoxResidenceState.Text.Contains("MD") ||
         textBoxResidenceState.Text.Contains("MA") ||
         textBoxResidenceState.Text.Contains("MI") ||
         textBoxResidenceState.Text.Contains("MN") ||
         textBoxResidenceState.Text.Contains("MS") ||
         textBoxResidenceState.Text.Contains("MO") ||
         textBoxResidenceState.Text.Contains("MT") ||
         textBoxResidenceState.Text.Contains("NE") ||
         textBoxResidenceState.Text.Contains("NV") ||
         textBoxResidenceState.Text.Contains("NH") ||
         textBoxResidenceState.Text.Contains("NJ") ||
         textBoxResidenceState.Text.Contains("NM") ||
         textBoxResidenceState.Text.Contains("NY") ||
         textBoxResidenceState.Text.Contains("NC") ||
         textBoxResidenceState.Text.Contains("ND") ||
         textBoxResidenceState.Text.Contains("OH") ||
         textBoxResidenceState.Text.Contains("OK") ||
         textBoxResidenceState.Text.Contains("OR") ||
         textBoxResidenceState.Text.Contains("PW") ||
         textBoxResidenceState.Text.Contains("PA") ||
         textBoxResidenceState.Text.Contains("PR") ||
         textBoxResidenceState.Text.Contains("RI") ||
         textBoxResidenceState.Text.Contains("SC") ||
         textBoxResidenceState.Text.Contains("SD") ||
         textBoxResidenceState.Text.Contains("TN") ||
         textBoxResidenceState.Text.Contains("TX") ||
         textBoxResidenceState.Text.Contains("UT") ||
         textBoxResidenceState.Text.Contains("VT") ||
         textBoxResidenceState.Text.Contains("VA") ||
         textBoxResidenceState.Text.Contains("WA") ||
         textBoxResidenceState.Text.Contains("WV") ||
         textBoxResidenceState.Text.Contains("WI") ||
         textBoxResidenceState.Text.Contains("WY"))
            {
                MessageBox.Show("Please use full spelling of states");
            }

            if (textBoxResidenceCity.Text == "" && comboBoxResidenceCounty.Text == ""
                && textBoxResidenceState.Text == "" && textBoxResidenceCountry.Text == "")
                buttonAddResidence.Enabled = false;
            else buttonAddResidence.Enabled = true;
        }

        private void textBoxResidenceCountry_TextChanged(object sender, EventArgs e)
        {
            if (textBoxResidenceCity.Text == "" && comboBoxResidenceCounty.Text == ""
                && textBoxResidenceState.Text == "" && textBoxResidenceCountry.Text == "")
                buttonAddResidence.Enabled = false;
            else buttonAddResidence.Enabled = true;
        }

        private void comboBoxBirthCounty_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxBirthCounty.Text.Contains("County") || comboBoxBirthCounty.Text.Contains("county"))
                MessageBox.Show("Please exclude the word \"County\"");
        }

        private void comboBoxDeathCounty_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxDeathCounty.Text.Contains("County") || comboBoxDeathCounty.Text.Contains("county"))
                MessageBox.Show("Please exclude the word \"County\"");
        }

        private void comboBoxCemeteryCounty_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCemeteryCounty.Text.Contains("County") || comboBoxCemeteryCounty.Text.Contains("county"))
                MessageBox.Show("Please exclude the word \"County\"");
        }

        private void comboBoxMarriageCounty_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxMarriageCounty.Text.Contains("County") || comboBoxMarriageCounty.Text.Contains("county"))
                MessageBox.Show("Please exclude the word \"County\"");
        }

        private void textBoxBirthState_TextChanged(object sender, EventArgs e)
        {
            if (
                textBoxBirthState.Text.Contains("AL") ||
                textBoxBirthState.Text.Contains("AK") ||
                textBoxBirthState.Text.Contains("AS") ||
                textBoxBirthState.Text.Contains("AZ") ||
                textBoxBirthState.Text.Contains("AR") ||
                textBoxBirthState.Text.Contains("CA") ||
                textBoxBirthState.Text.Contains("CO") ||
                textBoxBirthState.Text.Contains("CT") ||
                textBoxBirthState.Text.Contains("DE") ||
                textBoxBirthState.Text.Contains("FL") ||
                textBoxBirthState.Text.Contains("GA") ||
                textBoxBirthState.Text.Contains("HI") ||
                textBoxBirthState.Text.Contains("ID") ||
                textBoxBirthState.Text.Contains("IL") ||
                textBoxBirthState.Text.Contains("IN") ||
                textBoxBirthState.Text.Contains("IA") ||
                textBoxBirthState.Text.Contains("KS") ||
                textBoxBirthState.Text.Contains("KY") ||
                textBoxBirthState.Text.Contains("LA") ||
                textBoxBirthState.Text.Contains("ME") ||
                textBoxBirthState.Text.Contains("MD") ||
                textBoxBirthState.Text.Contains("MA") ||
                textBoxBirthState.Text.Contains("MI") ||
                textBoxBirthState.Text.Contains("MN") ||
                textBoxBirthState.Text.Contains("MS") ||
                textBoxBirthState.Text.Contains("MO") ||
                textBoxBirthState.Text.Contains("MT") ||
                textBoxBirthState.Text.Contains("NE") ||
                textBoxBirthState.Text.Contains("NV") ||
                textBoxBirthState.Text.Contains("NH") ||
                textBoxBirthState.Text.Contains("NJ") ||
                textBoxBirthState.Text.Contains("NM") ||
                textBoxBirthState.Text.Contains("NY") ||
                textBoxBirthState.Text.Contains("NC") ||
                textBoxBirthState.Text.Contains("ND") ||
                textBoxBirthState.Text.Contains("OH") ||
                textBoxBirthState.Text.Contains("OK") ||
                textBoxBirthState.Text.Contains("OR") ||
                textBoxBirthState.Text.Contains("PW") ||
                textBoxBirthState.Text.Contains("PA") ||
                textBoxBirthState.Text.Contains("PR") ||
                textBoxBirthState.Text.Contains("RI") ||
                textBoxBirthState.Text.Contains("SC") ||
                textBoxBirthState.Text.Contains("SD") ||
                textBoxBirthState.Text.Contains("TN") ||
                textBoxBirthState.Text.Contains("TX") ||
                textBoxBirthState.Text.Contains("UT") ||
                textBoxBirthState.Text.Contains("VT") ||
                textBoxBirthState.Text.Contains("VA") ||
                textBoxBirthState.Text.Contains("WA") ||
                textBoxBirthState.Text.Contains("WV") ||
                textBoxBirthState.Text.Contains("WI") ||
                textBoxBirthState.Text.Contains("WY"))
            {
                MessageBox.Show("Please use full spelling of states");
            }


        }

        private void textBoxDeathState_TextChanged(object sender, EventArgs e)
        {
            if (
                    textBoxDeathState.Text.Contains("AL") ||
                    textBoxDeathState.Text.Contains("AK") ||
                    textBoxDeathState.Text.Contains("AS") ||
                    textBoxDeathState.Text.Contains("AZ") ||
                    textBoxDeathState.Text.Contains("AR") ||
                    textBoxDeathState.Text.Contains("CA") ||
                    textBoxDeathState.Text.Contains("CO") ||
                    textBoxDeathState.Text.Contains("CT") ||
                    textBoxDeathState.Text.Contains("DE") ||
                    textBoxDeathState.Text.Contains("FL") ||
                    textBoxDeathState.Text.Contains("GA") ||
                    textBoxDeathState.Text.Contains("HI") ||
                    textBoxDeathState.Text.Contains("ID") ||
                    textBoxDeathState.Text.Contains("IL") ||
                    textBoxDeathState.Text.Contains("IN") ||
                    textBoxDeathState.Text.Contains("IA") ||
                    textBoxDeathState.Text.Contains("KS") ||
                    textBoxDeathState.Text.Contains("KY") ||
                    textBoxDeathState.Text.Contains("LA") ||
                    textBoxDeathState.Text.Contains("ME") ||
                    textBoxDeathState.Text.Contains("MD") ||
                    textBoxDeathState.Text.Contains("MA") ||
                    textBoxDeathState.Text.Contains("MI") ||
                    textBoxDeathState.Text.Contains("MN") ||
                    textBoxDeathState.Text.Contains("MS") ||
                    textBoxDeathState.Text.Contains("MO") ||
                    textBoxDeathState.Text.Contains("MT") ||
                    textBoxDeathState.Text.Contains("NE") ||
                    textBoxDeathState.Text.Contains("NV") ||
                    textBoxDeathState.Text.Contains("NH") ||
                    textBoxDeathState.Text.Contains("NJ") ||
                    textBoxDeathState.Text.Contains("NM") ||
                    textBoxDeathState.Text.Contains("NY") ||
                    textBoxDeathState.Text.Contains("NC") ||
                    textBoxDeathState.Text.Contains("ND") ||
                    textBoxDeathState.Text.Contains("OH") ||
                    textBoxDeathState.Text.Contains("OK") ||
                    textBoxDeathState.Text.Contains("OR") ||
                    textBoxDeathState.Text.Contains("PW") ||
                    textBoxDeathState.Text.Contains("PA") ||
                    textBoxDeathState.Text.Contains("PR") ||
                    textBoxDeathState.Text.Contains("RI") ||
                    textBoxDeathState.Text.Contains("SC") ||
                    textBoxDeathState.Text.Contains("SD") ||
                    textBoxDeathState.Text.Contains("TN") ||
                    textBoxDeathState.Text.Contains("TX") ||
                    textBoxDeathState.Text.Contains("UT") ||
                    textBoxDeathState.Text.Contains("VT") ||
                    textBoxDeathState.Text.Contains("VA") ||
                    textBoxDeathState.Text.Contains("WA") ||
                    textBoxDeathState.Text.Contains("WV") ||
                    textBoxDeathState.Text.Contains("WI") ||
                    textBoxDeathState.Text.Contains("WY"))
            {
                MessageBox.Show("Please use full spelling of states");
            }
        }

        private void textBoxMarriageState_TextChanged(object sender, EventArgs e)
        {
            if (
                     textBoxMarriageState.Text.Contains("AL") ||
                     textBoxMarriageState.Text.Contains("AK") ||
                     textBoxMarriageState.Text.Contains("AS") ||
                     textBoxMarriageState.Text.Contains("AZ") ||
                     textBoxMarriageState.Text.Contains("AR") ||
                     textBoxMarriageState.Text.Contains("CA") ||
                     textBoxMarriageState.Text.Contains("CO") ||
                     textBoxMarriageState.Text.Contains("CT") ||
                     textBoxMarriageState.Text.Contains("DE") ||
                     textBoxMarriageState.Text.Contains("FL") ||
                     textBoxMarriageState.Text.Contains("GA") ||
                     textBoxMarriageState.Text.Contains("HI") ||
                     textBoxMarriageState.Text.Contains("ID") ||
                     textBoxMarriageState.Text.Contains("IL") ||
                     textBoxMarriageState.Text.Contains("IN") ||
                     textBoxMarriageState.Text.Contains("IA") ||
                     textBoxMarriageState.Text.Contains("KS") ||
                     textBoxMarriageState.Text.Contains("KY") ||
                     textBoxMarriageState.Text.Contains("LA") ||
                     textBoxMarriageState.Text.Contains("ME") ||
                     textBoxMarriageState.Text.Contains("MD") ||
                     textBoxMarriageState.Text.Contains("MA") ||
                     textBoxMarriageState.Text.Contains("MI") ||
                     textBoxMarriageState.Text.Contains("MN") ||
                     textBoxMarriageState.Text.Contains("MS") ||
                     textBoxMarriageState.Text.Contains("MO") ||
                     textBoxMarriageState.Text.Contains("MT") ||
                     textBoxMarriageState.Text.Contains("NE") ||
                     textBoxMarriageState.Text.Contains("NV") ||
                     textBoxMarriageState.Text.Contains("NH") ||
                     textBoxMarriageState.Text.Contains("NJ") ||
                     textBoxMarriageState.Text.Contains("NM") ||
                     textBoxMarriageState.Text.Contains("NY") ||
                     textBoxMarriageState.Text.Contains("NC") ||
                     textBoxMarriageState.Text.Contains("ND") ||
                     textBoxMarriageState.Text.Contains("OH") ||
                     textBoxMarriageState.Text.Contains("OK") ||
                     textBoxMarriageState.Text.Contains("OR") ||
                     textBoxMarriageState.Text.Contains("PW") ||
                     textBoxMarriageState.Text.Contains("PA") ||
                     textBoxMarriageState.Text.Contains("PR") ||
                     textBoxMarriageState.Text.Contains("RI") ||
                     textBoxMarriageState.Text.Contains("SC") ||
                     textBoxMarriageState.Text.Contains("SD") ||
                     textBoxMarriageState.Text.Contains("TN") ||
                     textBoxMarriageState.Text.Contains("TX") ||
                     textBoxMarriageState.Text.Contains("UT") ||
                     textBoxMarriageState.Text.Contains("VT") ||
                     textBoxMarriageState.Text.Contains("VA") ||
                     textBoxMarriageState.Text.Contains("WA") ||
                     textBoxMarriageState.Text.Contains("WV") ||
                     textBoxMarriageState.Text.Contains("WI") ||
                     textBoxMarriageState.Text.Contains("WY"))
            {
                MessageBox.Show("Please use full spelling of states");
            }
        }

        //listview changes

        private void listViewPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPositions.SelectedItems.Count == 1)
            {
                buttonUpdatePosition.Enabled = true;
                buttonRemovePosition.Enabled = true;

                //load data
                textBoxPosition.Text = listViewPositions.SelectedItems[0].Tag.ToString();
            }
            else
            {
                buttonUpdatePosition.Enabled = false;
                buttonRemovePosition.Enabled = false;

                //load data
                textBoxPosition.Text = "";
            }


        }

        private void listViewTroops_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTroops.SelectedItems.Count == 1)
            {
                buttonUpdateTroop.Enabled = true;
                buttonRemoveTroop.Enabled = true;

                //load data
                textBoxTroop.Text = listViewTroops.SelectedItems[0].Tag.ToString();
            }
            else
            {
                buttonUpdateTroop.Enabled = false;
                buttonRemoveTroop.Enabled = false;

                //load data
                textBoxTroop.Text = "";
            }


        }

        private void listViewSuperiors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSuperiors.SelectedItems.Count == 1)
            {
                buttonUpdateSuperior.Enabled = true;
                buttonRemoveSuperior.Enabled = true;

                //load data
                textBoxSuperior.Text = listViewSuperiors.SelectedItems[0].Tag.ToString();
            }
            else
            {
                buttonUpdateSuperior.Enabled = false;
                buttonRemoveSuperior.Enabled = false;

                //load data
                textBoxSuperior.Text = "";
            }


        }

        private void listViewSpouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSpouses.SelectedItems.Count == 1)
            {
                buttonUpdateSpouse.Enabled = true;
                buttonRemoveSpouse.Enabled = true;
                //load info
                textBoxSpouseFirstName.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).name.first;
                textBoxSpouseMiddleName.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).name.middle;
                textBoxSpouseLastName.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).name.last;
                textBoxSpouseMaidenName.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).name.maiden;
                comboBoxMarriageDay.SelectedIndex = ((spouse)listViewSpouses.SelectedItems[0].Tag).marriageDate.day;
                comboBoxMarriageMonth.SelectedIndex = ((spouse)listViewSpouses.SelectedItems[0].Tag).marriageDate.month;
                comboBoxMarriageYear.SelectedItem = ((spouse)listViewSpouses.SelectedItems[0].Tag).marriageDate.year.ToString();
                textBoxMarriageCity.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).marriageLocation.city;
                comboBoxMarriageCounty.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).marriageLocation.county;
                textBoxMarriageState.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).marriageLocation.state;
                textBoxMarriageCountry.Text = ((spouse)listViewSpouses.SelectedItems[0].Tag).marriageLocation.country;
            }
            else
            {
                buttonUpdateSpouse.Enabled = false;
                buttonRemoveSpouse.Enabled = false;
                //load info
                textBoxSpouseFirstName.Text = "";
                textBoxSpouseMiddleName.Text = "";
                textBoxSpouseLastName.Text = "";
                textBoxSpouseMaidenName.Text = "";
                comboBoxMarriageDay.SelectedIndex = 0;
                comboBoxMarriageMonth.SelectedIndex = 0;
                comboBoxMarriageYear.SelectedItem = 0;
                textBoxMarriageCity.Text = "";
                comboBoxMarriageCounty.Text = "";
                textBoxMarriageState.Text = "";
                textBoxMarriageCountry.Text = "";
            }


        }

        private void listViewChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewChildren.SelectedItems.Count == 1)
            {
                buttonUpdateChild.Enabled = true;
                buttonRemoveChild.Enabled = true;

                //load info
                textBoxChildFirstName.Text = ((child)listViewChildren.SelectedItems[0].Tag).name.first;
                textBoxChildMiddleName.Text = ((child)listViewChildren.SelectedItems[0].Tag).name.middle;
                textBoxChildLastName.Text = ((child)listViewChildren.SelectedItems[0].Tag).name.last;
                textBoxChildMaidenName.Text = ((child)listViewChildren.SelectedItems[0].Tag).name.maiden;
                //load mother into combobox
                Int32 motherID = ((child)listViewChildren.SelectedItems[0].Tag).spouseID;
                for (int i = 0; i < comboBoxMother.Items.Count; i++)
                    if (((comboMother)comboBoxMother.Items[i]).mother.id == motherID)
                        comboBoxMother.SelectedIndex = i;
            }
            else
            {
                buttonUpdateChild.Enabled = false;
                buttonRemoveChild.Enabled = false;

                //load info
                textBoxChildFirstName.Text = "";
                textBoxChildMiddleName.Text = "";
                textBoxChildLastName.Text = "";
                textBoxChildMaidenName.Text = "";
                //load mother into combobox
                comboBoxMother.SelectedIndex = 0;
            }


        }

        private void listViewResidences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResidences.SelectedItems.Count == 1)
            {
                buttonUpdateResidence.Enabled = true;
                buttonRemoveResidence.Enabled = true;

                //load info
                textBoxResidenceCity.Text = ((residence)listViewResidences.SelectedItems[0].Tag).place.city;
                comboBoxResidenceCounty.Text = ((residence)listViewResidences.SelectedItems[0].Tag).place.county;
                textBoxResidenceState.Text = ((residence)listViewResidences.SelectedItems[0].Tag).place.state;
                textBoxResidenceCountry.Text = ((residence)listViewResidences.SelectedItems[0].Tag).place.country;
                comboBoxMoveInDay.SelectedItem = ((residence)listViewResidences.SelectedItems[0].Tag).moveInDate.day;
                comboBoxMoveInMonth.SelectedItem = ((residence)listViewResidences.SelectedItems[0].Tag).moveInDate.month;
                comboBoxMoveInYear.SelectedItem = ((residence)listViewResidences.SelectedItems[0].Tag).moveInDate.year.ToString();
                comboBoxMoveOutDay.SelectedItem = ((residence)listViewResidences.SelectedItems[0].Tag).moveOutDate.day;
                comboBoxMoveOutMonth.SelectedItem = ((residence)listViewResidences.SelectedItems[0].Tag).moveOutDate.month;
                comboBoxMoveOutYear.SelectedItem = ((residence)listViewResidences.SelectedItems[0].Tag).moveOutDate.year.ToString();
            }
            else
            {
                buttonUpdateResidence.Enabled = false;
                buttonRemoveResidence.Enabled = false;

                //load info
                textBoxResidenceCity.Text = "";
                comboBoxResidenceCounty.Text = "";
                textBoxResidenceState.Text = "";
                textBoxResidenceCountry.Text = "";
                comboBoxMoveInDay.SelectedItem = 0;
                comboBoxMoveInMonth.SelectedItem = 0;
                comboBoxMoveInYear.SelectedItem = 0;
                comboBoxMoveOutDay.SelectedItem = 0;
                comboBoxMoveOutMonth.SelectedItem = 0;
                comboBoxMoveOutYear.SelectedItem = 0;
            }


        }

        private void tabControlInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //helper

        public Int32 comboDaytoInt(ComboBox convertBox)
        {
            if (convertBox.SelectedItem.Equals("??"))
                return 0;
            else return Convert.ToInt32(convertBox.SelectedItem);
        }

        public Int32 comboYeartoInt(ComboBox convertBox)
        {
            if (convertBox.SelectedItem.Equals("????"))
                return 0;
            else return Convert.ToInt32(convertBox.SelectedItem);
        }

        public Int32 comboMonthtoInt(ComboBox convertBox)
        {
            if (convertBox.SelectedItem.Equals("January"))
                return 1;
            if (convertBox.SelectedItem.Equals("February"))
                return 2;
            if (convertBox.SelectedItem.Equals("March"))
                return 3;
            if (convertBox.SelectedItem.Equals("April"))
                return 4;
            if (convertBox.SelectedItem.Equals("May"))
                return 5;
            if (convertBox.SelectedItem.Equals("June"))
                return 6;
            if (convertBox.SelectedItem.Equals("July"))
                return 7;
            if (convertBox.SelectedItem.Equals("August"))
                return 8;
            if (convertBox.SelectedItem.Equals("September"))
                return 9;
            if (convertBox.SelectedItem.Equals("October"))
                return 10;
            if (convertBox.SelectedItem.Equals("November"))
                return 11;
            if (convertBox.SelectedItem.Equals("December"))
                return 12;
            return 0;
        }











 
    }
}
