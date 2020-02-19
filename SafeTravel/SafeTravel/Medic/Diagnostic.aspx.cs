using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SafeTravel.Medic
{
    public partial class Diagnostic : System.Web.UI.Page
    {
        protected List<string> aux;
        protected List<Countries> lc;
        protected List<string> names;
        protected List<ListItem> lLI;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            aux = new List<string>();
            lc = new List<Countries>();
            names = new List<string>();
            String s="";

            if (!string.IsNullOrEmpty(Request.Form["bmotive"]))
            {
               
            }


            if (Request.QueryString["patientIdDiagnosticId"]!=null)
            {
                s = Request.QueryString["patientIdDiagnosticId"];
                String[] sIds = s.Split(',');
                int patientId = int.Parse(sIds[0]);
                int appoitmentId = int.Parse(sIds[1]);
                data data = new data();
                var app = data.Appointment.Where(b => b.appointment_id == appoitmentId).FirstOrDefault();
                if (app.diagnostic_id != null)
                {
                    var diag = data.Diagnostic.Where(b => b.diagnostic_id == app.diagnostic_id).FirstOrDefault();

                    tbBeginDate.Text = diag.begin_date.Value.ToShortDateString();
                    tbEndDate.Text = diag.end_date.Value.ToShortDateString();

                    String[] motives = diag.reason.Split(';');
                    foreach(String m in motives)
                    {
                        ListItem item = new ListItem(m, m);
                        item.Selected = true;
                        if (List_Motives.Items.Contains(item))
                        {
                            List_Motives.Items.FindByText(m).Selected = true;
                        }
                        else
                        {
                            List_Motives.Items.Add(item);
                        }
                    }

                    if (diag.isSmoker == 0)
                    {
                        no_smoker.Checked = true;
                    }
                    else
                    {
                        smoker.Checked = true;
                    }

                    if (diag.allergic != "")
                    {
                        allergic.Checked = true;
                        allergicChecked(this, EventArgs.Empty);
                        String[] allergies = diag.allergic.Split(';');
                        if (ListBoxAllergy.Items.Count == 0)
                        {
                            foreach (String a in allergies)
                            {
                                ListItem item = new ListItem(a, a);
                                item.Selected = true;
                                ListBoxAllergy.Items.Add(item);

                            }
                        }
                    }
                    else
                    {
                        no_allergic.Checked = true;
                    }

                    String[] aux = Regex.Split(diag.medicines, "/a;");
                    if (aux[0] != "")
                    {
                        medicines.Checked = true;
                        medicinesChecked(this, EventArgs.Empty);
                        String[] splitMedicines = aux[0].Split(';');
                        if (ListBoxMedicines.Items.Count == 0)
                        {
                            foreach (String m in splitMedicines)
                            {
                                ListItem item = new ListItem(m, m);
                                item.Selected = true;
                                ListBoxMedicines.Items.Add(item);

                            }
                        } 
                    }
                    else
                    {
                        no_medicines.Checked = true;
                    }
                    if (aux[1]!="")
                    {
                        anticoagulant.Checked = true;
                        anticoagulantChecked(this, EventArgs.Empty);
                        String[] splitAnticoag = aux[1].Split(';');
                        if (ListBoxAnticoagulant.Items.Count == 0)
                        {
                            foreach (String a in splitAnticoag)
                            {
                                ListItem item = new ListItem(a, a);
                                item.Selected = true;
                                ListBoxAnticoagulant.Items.Add(item);

                            }
                        }
                    }
                    else
                    {
                        no_anticoagulant.Checked = true;
                    }

                    String[] aux1 = Regex.Split(diag.health_condition, "/1;");
                    String[] sItems = null;
                    if (aux[0] != "")
                    {
                        CheckBox1.Checked = true;
                        cb1Changed(this, EventArgs.Empty);
                        sItems = aux1[0].Split(';');
                        if (ListBox1.Items.Count == 0)
                        {
                            foreach (String si in sItems)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBox1.Items.Add(item);

                            }
                        }
                    }
                    String[] aux2 = Regex.Split(aux1[1], "/2;");
                    sItems = null;
                    if (aux2[0] != "")
                    {
                        CheckBox2.Checked = true;
                        cb2Changed(this, EventArgs.Empty);
                        sItems = aux2[0].Split(';');
                        if (ListBox2.Items.Count == 0)
                        {
                            foreach (String si in sItems)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBox2.Items.Add(item);

                            }
                        }
                    }
                    String[] aux3 = Regex.Split(aux2[1], "/3;");
                    sItems = null;
                    if (aux3[0] != "")
                    {
                        CheckBox3.Checked = true;
                        cb3Changed(this, EventArgs.Empty);
                        sItems = aux3[0].Split(';');
                        if (ListBox3.Items.Count == 0)
                        {
                            foreach (String si in sItems)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBox3.Items.Add(item);

                            }
                        }
                    }
                    String[] aux4 = Regex.Split(aux3[1], "/4;");
                    sItems = null;
                    if (aux4[0] != "")
                    {
                        CheckBox4.Checked = true;
                        cb4Changed(this, EventArgs.Empty);
                        sItems = aux4[0].Split(';');
                        if (ListBox4.Items.Count == 0)
                        {
                            foreach (String si in sItems)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBox4.Items.Add(item);

                            }
                        }
                    }
                    String[] aux5 = Regex.Split(aux4[1], "/5;");
                    sItems = null;
                    if (aux5[0] != "")
                    {
                        CheckBox5.Checked = true;
                        cb5Changed(this, EventArgs.Empty);
                        sItems = aux5[0].Split(';');
                        if (ListBox5.Items.Count == 0)
                        {
                            foreach (String si in sItems)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBox5.Items.Add(item);

                            }
                        }
                    }
                    String[] aux6 = Regex.Split(aux5[1], "/6;");
                    sItems = null;
                    if (aux6[0] != "")
                    {
                        CheckBox6.Checked = true;
                        cb6Changed(this, EventArgs.Empty);
                        sItems = aux6[0].Split(';');
                        if (ListBox6.Items.Count == 0)
                        {
                            foreach (String si in sItems)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBox6.Items.Add(item);

                            }
                        }
                    }
                    String[] aux7 = Regex.Split(aux6[1], "/7;");
                    sItems = null;
                    if (aux7[0] != "")
                    {
                        CheckBox7.Checked = true;
                        cb7Changed(this, EventArgs.Empty);
                        sItems = aux7[0].Split(';');
                        if (ListBox7.Items.Count == 0)
                        {
                            foreach (String si in sItems)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBox7.Items.Add(item);

                            }
                        }
                    }
                    if (diag.surgery != "")
                    {
                        aux = null;
                        aux = diag.surgery.Split(';');
                        int i = 0;
                        Cirurgy.Checked = true;
                        cirurgyChecked(this, EventArgs.Empty);
                        foreach (String si in aux)
                        {
                            if (si != "")
                            {
                                sItems = null;
                                sItems = si.Split('/');
                                tbcirurgy.Text = sItems[0];
                                add_cirurgy_click(this, EventArgs.Empty);
                                TextBox tb = GridView2.Rows[i].Cells[1].FindControl("year") as TextBox;
                                tb.Text = sItems[1];
                                i++;
                            }
                        }
                    }
                    else
                    {
                        noCirurgy.Checked = true;
                    }

                    if (diag.recentSick != "")
                    {
                        sick.Checked = true;
                        sickChecked(this, EventArgs.Empty);
                        aux = null;
                        aux = diag.recentSick.Split(';');
                        if (ListBoxSick.Items.Count == 0)
                        {
                            foreach (String si in aux)
                            {
                                ListItem item = new ListItem(si, si);
                                item.Selected = true;
                                ListBoxSick.Items.Add(item);

                            }
                        }
                    }
                    else
                    {
                        no_sick.Checked = true;
                    }

                    if (diag.vaccines != "")
                    {
                        aux = null;
                        aux = diag.vaccines.Split(';');
                        int i = 0;
                        foreach (String si in aux)
                        {
                            if (si != "")
                            {
                                sItems = null;
                                sItems = Regex.Split(si, "//");
                                ListItem item = new ListItem(sItems[0], sItems[0]);
                                item.Selected = true;
                                if (ListBoxVaccines.Items.Contains(item))
                                {
                                    ListBoxVaccines.Items.FindByText(sItems[0]).Selected = true;
                                }
                                else
                                {
                                    ListBoxVaccines.Items.Add(item);
                                    tbVaccines.Text = sItems[0];
                                    addVaccineClick(this, EventArgs.Empty);
                                }
                            }
                        }
                        vaccineChanged(this, EventArgs.Empty);
                        foreach(String si in aux)
                        {
                            if (si != "")
                            {
                                sItems = null;
                                sItems = Regex.Split(si, "//");
                                TextBox tb = GridViewVaccines.Rows[i].Cells[1].FindControl("date") as TextBox;
                                tb.Text = sItems[1];
                                i++;
                            }
                         
                        }
                    }
                    else
                    {
                        noCirurgy.Checked = true;
                    }

                    if (diag.firstTime == 0)
                    {
                        noFirstTime.Checked = true;
                    }
                    else
                    {
                        fristTime.Checked = true;
                    }

                    if (diag.sickTravelling != "")
                    {
                        aux = null;
                        aux = diag.sickTravelling.Split(';');
                        int i = 0;
                        sickTraveling.Checked = true;
                        sickTravellingChecked(this, EventArgs.Empty);
                        foreach (String si in aux)
                        {
                            if (si != "")
                            {
                                sItems = null;
                                sItems = Regex.Split(si,"//");
                                tbSickTravelling.Text = sItems[0];
                                addSickTravellingClick(this, EventArgs.Empty);
                                TextBox tb = GridViewSickTravelling.Rows[i].Cells[1].FindControl("treatment") as TextBox;
                                tb.Text = sItems[1];
                                i++;
                            }
                        }
                    }
                    else
                    {
                        noSickTraveling.Checked = true;
                    }

                    if (diag.malaria != "")
                    {
                        malaria.Checked = true;
                        malariaChecked(this, EventArgs.Empty);
                        aux = null;
                        aux = diag.malaria.Split(';');
                        if (ListBoxMalaria.Items.Count == 0)
                        {
                            foreach (String a in aux)
                            {
                                ListItem item = new ListItem(a, a);
                                item.Selected = true;
                                ListBoxMalaria.Items.Add(item);

                            }
                        }
                    }
                    else
                    {
                        noMalaria.Checked = true;
                    }

                    var trips= data.Trip.Where(b => b.diagnostic_id == diag.diagnostic_id).ToList();
                    ListBoxRegions.DataBind();
                    foreach(Trip t in trips)
                    {
                        ListBoxRegions.Items.FindByValue(t.region_id.ToString()).Selected=true;

                    }
                    listBox1_SelectedIndexChanged(this, EventArgs.Empty);

                    foreach(Trip t in trips)
                    {
                        ListBoxCountries.Items.FindByText(t.country).Selected = true;
                    }
                    listBox2_SelectedIndexChanged(this,EventArgs.Empty);

                    int j = 0;
                    foreach(Trip t in trips)
                    {
                        if (t.destination != "")
                        {
                            TextBox tb = GridView1.Rows[j].Cells[2].FindControl("locals") as TextBox;
                            tb.Text = t.destination;
                        }
                        if (t.environment != "")
                        {
                            aux = null;
                            aux = t.environment.Split(';');
                            foreach(String a in aux)
                            {
                                if (a != "")
                                {
                                    CheckBox cb = GridView1.Rows[j].Cells[3].FindControl(a) as CheckBox;
                                    cb.Checked = true;
                                }
                            }
                        }
                        if (t.accommodation != "")
                        {
                            aux = null;
                            aux = t.accommodation.Split(';');
                            foreach(String a in aux)
                            {
                                if (a != "")
                                {
                                    ListBox lb = GridView1.Rows[j].FindControl("ListBoxAccomodation") as ListBox;
                                    ListItem item = new ListItem(a, a);
                                    item.Selected = true;
                                    if (lb.Items.Contains(item))
                                    {
                                        lb.Items.FindByText(a).Selected = true;
                                    }
                                    else
                                    {
                                        lb.Items.Add(item);
                                    }
                                }
                            }
                        }
                        if (t.activities != "")
                        {
                            aux = null;
                            aux = t.activities.Split(';');
                            foreach (String a in aux)
                            {
                                if (a != "")
                                {
                                    ListBox lb = GridView1.Rows[j].FindControl("ListBoxActivities") as ListBox;
                                    ListItem item = new ListItem(a, a);
                                    item.Selected = true;
                                    if (lb.Items.Contains(item))
                                    {
                                        lb.Items.FindByText(a).Selected = true;
                                    }
                                    else
                                    {
                                        lb.Items.Add(item);
                                    }
                                }
                            }
                        }
                        if (t.begin_date != null)
                        {
                            TextBox tb = GridView1.Rows[j].FindControl("checkin") as TextBox;
                            tb.Text = t.begin_date.Value.ToShortDateString();
                        }
                        if (t.end_date != null)
                        {
                            TextBox tb = GridView1.Rows[j].FindControl("checkout") as TextBox;
                            tb.Text = t.end_date.Value.ToShortDateString();
                        }
                        j++;
                    }
                }
            }
        }
        public IQueryable GetRegions()
        {
            var _db = new data();
            IQueryable query = _db.Region;
            return query;
        }


        protected void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            

            DataTable infoCountries = new DataTable();
            lc = new List<Countries>();

            infoCountries = (DataTable)ViewState["currentTable"];
            if (infoCountries == null)
            {
                infoCountries = new DataTable();
                infoCountries.Columns.Add(new DataColumn("id", typeof(string)));
                infoCountries.Columns.Add(new DataColumn("name", typeof(string)));
                infoCountries.Columns.Add(new DataColumn("checkin", typeof(string)));
                infoCountries.Columns.Add(new DataColumn("checkout", typeof(string)));
            }
            names = new List<string>();

            int i = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                Countries c = new Countries();
                c.name = row.Cells[1].Text;
                TextBox tb = row.Cells[2].FindControl("checkin") as TextBox;
                if (!tb.Text.Equals(""))
                {
                    c.checkin = DateTime.Parse(tb.Text);
                }
                else
                {
                    c.checkin = DateTime.MinValue;
                }

                
                tb = row.Cells[3].FindControl("checkout") as TextBox;

                if (!tb.Text.Equals(""))
                {
                    c.checkout = DateTime.Parse(tb.Text);
                }
                else
                {
                    c.checkout = DateTime.MinValue;
                }


                lc.Add(c);
                names.Add(row.Cells[1].Text);
            } 
            foreach (ListItem item in ListBoxCountries.Items)
            {
                if (item.Selected)
                {
                    DataRow row = infoCountries.NewRow();
                   
                    row["id"] = item.Value;
                    row["name"] = item.Text;

                    
                    i++;
                    infoCountries.Rows.Add(row);

                }

            }
            ViewState["CurrentTable"] = infoCountries;
            if (i != 0)
            {
                GridView1.Visible = true;

                GridView1.DataSource = infoCountries;
                GridView1.DataBind();
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        protected void add_cirurgy_click(object sender, System.EventArgs e)
        {
            DataTable cirurgies = new DataTable();

            if (ViewState["cirurgyTable"] != null)
            {
                cirurgies = ViewState["cirurgyTable"] as DataTable;
                
            }
            else
            {
                cirurgies.Columns.Add(new DataColumn("cirurgy", typeof(string)));
                cirurgies.Columns.Add(new DataColumn("year", typeof(string)));
            }

            DataRow row = cirurgies.NewRow();

            row["cirurgy"] = tbcirurgy.Text;
            cirurgies.Rows.Add(row);

            ViewState["cirurgyTable"] = cirurgies;

            GridView2.DataSource = cirurgies;
            tbcirurgy.Text = "";
            GridView2.DataBind();
        }
        protected void addSickTravellingClick(object sender, System.EventArgs e)
        {
            DataTable sickTravelling = new DataTable();

            if (ViewState["sickTravellingTable"] != null)
            {
                sickTravelling = ViewState["sickTravellingTable"] as DataTable;

            }
            else
            {
                sickTravelling.Columns.Add(new DataColumn("SickTravelling", typeof(string)));
                sickTravelling.Columns.Add(new DataColumn("treatment", typeof(string)));
            }

            DataRow row = sickTravelling.NewRow();

            row["SickTravelling"] = tbSickTravelling.Text;
            sickTravelling.Rows.Add(row);

            ViewState["sickTravellingTable"] = sickTravelling;

            GridViewSickTravelling.DataSource = sickTravelling;
            tbSickTravelling.Text = "";
            GridViewSickTravelling.DataBind();
        }

        protected void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            List<ListItem> l = new List<ListItem>();
            aux = new List<string>();
            foreach(ListItem item in ListBoxCountries.Items)
            {
                if (item.Selected)
                {
                    aux.Add(item.Text);
                }
                
            }
            int i = 0;
            foreach (ListItem item in ListBoxRegions.Items)
            {
                if (item.Selected)
                {
                    var _db = new data();
                    var id = int.Parse(item.Value);
                    var query = _db.Region.Where(b => b.region_id == id).FirstOrDefault();
                    string[] countries = query.countries.Split(';');
                    foreach (string n in countries)
                    {
                        ListItem country = new ListItem();
                        country.Text = n;
                        country.Value = i.ToString();
                        l.Add(country);
                        
                    }

                }

            }
            ListBoxCountries.DataSource = l;
            ListBoxCountries.DataBind();

            listBox2_SelectedIndexChanged(this, EventArgs.Empty);

        }
        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            
            foreach (string s in aux)
           {
                if (ListBoxCountries.Items.FindByText(s) != null)
                {
                    ListBoxCountries.Items.FindByText(s).Selected = true;
                }
           }
   
           

        }

        protected void DropDownList2_DataBound(object sender, EventArgs e)
        {
            foreach(GridViewRow row in GridView1.Rows)
            {
                if (names.Contains(row.Cells[1].Text))
                {
                    foreach(Countries c in lc)
                    {
                        if (c.name.Equals(row.Cells[1].Text))
                        {
                            TextBox tb = row.Cells[2].FindControl("checkin") as TextBox;
                            if (c.checkin!=DateTime.MinValue)
                            {
                                tb.Text = c.checkin.ToString();
                            }
                            tb = row.Cells[2].FindControl("checkout") as TextBox;
                            if (c.checkout != DateTime.MinValue)
                            {
                                tb.Text = c.checkout.ToString();
                            }
                            
                            break;
                        }
                    }
                }
            }
        }

        protected void add_motive_click(object sender, EventArgs e)
        {
            ListItem motive = new ListItem(others_motives.Text, others_motives.Text);
            motive.Selected=true;
            List_Motives.Items.Add(motive);
            others_motives.Text = "";
        }

        protected void add_allergy_click(object sender, EventArgs e)
        {
            ListItem allergy = new ListItem(tbAllergy.Text, tbAllergy.Text);
            allergy.Selected = true;
            ListBoxAllergy.Items.Add(allergy);
            tbAllergy.Text = "";
        }

        protected void add_medicine_click(object sender, EventArgs e)
        {
            ListItem medicine = new ListItem(tbMedicine.Text, tbMedicine.Text);
            medicine.Selected = true;
            ListBoxMedicines.Items.Add(medicine);
            tbMedicine.Text = "";
        }
        protected void add_anticoagulant_click(object sender, EventArgs e)
        {
            ListItem anticoagulant = new ListItem(tbAnticoagulant.Text, tbAnticoagulant.Text);
            anticoagulant.Selected = true;
            ListBoxAnticoagulant.Items.Add(anticoagulant);
            tbAnticoagulant.Text = "";
        }
        protected void addSickClick(object sender, EventArgs e)
        {
            ListItem sick = new ListItem(tbSick.Text, tbSick.Text);
            sick.Selected = true;
            ListBoxSick.Items.Add(sick);
            tbSick.Text = "";
        }
        protected void addMalariaClick(object sender, EventArgs e)
        {
            ListItem malaria = new ListItem(tbMalaria.Text, tbMalaria.Text);
            malaria.Selected = true;
            ListBoxMalaria.Items.Add(malaria);
            tbMalaria.Text = "";
        }
        protected void addAccomodationClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            TextBox tb = (TextBox)(gvr.Cells[5]).FindControl("tbAccomodation");
            ListItem accomodation = new ListItem(tb.Text, tb.Text);
            accomodation.Selected = true;
            ListBox lb = (ListBox)(gvr.Cells[5]).FindControl("ListBoxAccomodation");
            lb.Items.Add(accomodation);
            tb.Text = "";
        }

        protected void addActivitiesClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            TextBox tb = (TextBox)(gvr.Cells[5]).FindControl("tbActivities");
            ListItem accomodation = new ListItem(tb.Text, tb.Text);
            accomodation.Selected = true;
            ListBox lb = (ListBox)(gvr.Cells[5]).FindControl("ListBoxActivities");
            lb.Items.Add(accomodation);
            tb.Text = "";
        }

        protected void smokerChange(object sender, EventArgs e)
        {
            if (sender==no_smoker)
            {
                smoker.Checked= false;
            }
            else
            {
                no_smoker.Checked = false;
            }
        }
        protected void allergicChecked(object sender, EventArgs e)
        {
            if (sender == no_allergic)
            {
                allergic.Checked = false;
                div5.Visible = false;
            }
            else
            {
                no_allergic.Checked = false;
                div5.Visible = true;
            }
        }
        protected void medicinesChecked(object sender, EventArgs e)
        {
            if (sender == no_medicines)
            {
                medicines.Checked = false;
                div6.Visible = false;
            }
            else
            {
                no_medicines.Checked = false;
                div6.Visible = true;
            }
        }
        protected void anticoagulantChecked(object sender, EventArgs e)
        {
            if (sender == no_anticoagulant)
            {
                anticoagulant.Checked = false;
                div6_2.Visible = false;
            }
            else
            {
                no_anticoagulant.Checked = false;
                div6_2.Visible = true;
            }
        }
        protected void cb1Changed(object sender,EventArgs e)
        {
            if (CheckBox1.Checked)
                div7_1.Visible = true;
            else
                div7_1.Visible = false;
        }
        protected void cb2Changed(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
                div7_2.Visible = true;
            else
                div7_2.Visible = false;
        }
        protected void cb3Changed(object sender, EventArgs e)
        {
            if (CheckBox3.Checked)
                div7_3.Visible = true;
            else
                div7_3.Visible = false;
        }
        protected void cb4Changed(object sender, EventArgs e)
        {
            if (CheckBox4.Checked)
                div7_4.Visible = true;
            else
                div7_4.Visible = false;
        }
        protected void cb5Changed(object sender, EventArgs e)
        {
            if (CheckBox5.Checked)
                div7_5.Visible = true;
            else
                div7_5.Visible = false;
        }
        protected void cb6Changed(object sender, EventArgs e)
        {
            if (CheckBox6.Checked)
                div7_6.Visible = true;
            else
                div7_6.Visible = false;
        }
        protected void cb7Changed(object sender, EventArgs e)
        {
            if (CheckBox7.Checked)
                div7_7.Visible = true;
            else
                div7_7.Visible = false;
        }
        protected void cirurgyChecked(object sender, EventArgs e)
        {
            if (sender == noCirurgy)
            {
                Cirurgy.Checked = false;
                div8.Visible = false;
            }
            else
            {
                noCirurgy.Checked = false;
                div8.Visible = true;
            }
        }
        protected void sickChecked(object sender, EventArgs e)
        {
            if (sender == no_sick)
            {
                Cirurgy.Checked = false;
                div9.Visible = false;
            }
            else
            {
                no_sick.Checked = false;
                div9.Visible = true;
            }
        }
        protected void sickTravellingChecked(object sender, EventArgs e)
        {
            if (sender == noSickTraveling)
            {
                sickTraveling.Checked = false;
                div11.Visible = false;
            }
            else
            {
                noSickTraveling.Checked = false;
                div11.Visible = true;
            }
        }
        protected void malariaChecked(object sender, EventArgs e)
        {
            if (sender == noMalaria)
            {
                malaria.Checked = false;
                div12.Visible = false;
            }
            else
            {
                noMalaria.Checked = false;
                div12.Visible = true;
            }
        }
        protected void genreChecked(object sender, EventArgs e)
        {
            if (sender == male)
            {
                female.Checked = false;
                div13.Visible = false;
            }
            else
            {
                male.Checked = false;
                div13.Visible = true;
            }
        }
        protected void pillChecked(object sender, EventArgs e)
        {
            if (sender == noPill)
            {
                pill.Checked = false;
                div14.Visible = false;
            }
            else
            {
                noPill.Checked = false;
                div14.Visible = true;
            }
        }
        protected void infertilityChecked(object sender, EventArgs e)
        {
            if (sender == noInfertility)
            {
                infertility.Checked = false;
                div15.Visible = false;
            }
            else
            {
                noInfertility.Checked = false;
                div15.Visible = true;
            }
        }
        protected void pregnantChecked(object sender, EventArgs e)
        {
            if (sender == noPregnant)
            {
                pregnat.Checked = false;
                div16.Visible = false;
            }
            else
            {
                noPregnant.Checked = false;
                div16.Visible = true;
            }
        }
        protected void vaccineChanged(object sender, System.EventArgs e)
        {
            DataTable vaccines = new DataTable();

            
            vaccines.Columns.Add(new DataColumn("vaccine", typeof(string)));
            vaccines.Columns.Add(new DataColumn("date", typeof(string)));

            foreach(ListItem item in ListBoxVaccines.Items)
            {
                if(item.Text.Equals("Não sabe")&&item.Selected)
                {
                    vaccines = new DataTable();
                    
                    foreach(ListItem item2 in ListBoxVaccines.Items)
                    {
                        if(!item2.Text.Equals("Não sabe") && item2.Selected)
                        {
                            item2.Selected = false;
                        }
                    }
                    break;
                }
                if (item.Selected)
                {
                    DataRow row = vaccines.NewRow();

                    row["vaccine"] = item.Text;
                    vaccines.Rows.Add(row);
                }
            }

            ViewState["vaccineTable"] = vaccines;

            GridViewVaccines.DataSource = vaccines;
            GridViewVaccines.DataBind();
        }
        protected void addVaccineClick(object sender, EventArgs e)
        {
            ListItem vaccine = new ListItem(tbVaccines.Text, tbVaccines.Text);
            vaccine.Selected = true;
            ListBoxVaccines.Items.Add(vaccine);
            tbVaccines.Text = "";
            vaccineChanged(this, EventArgs.Empty);
        }

        protected void nextClick(object sender, EventArgs e)
        {
            var diag = new Models.Diagnostic();
            try
            {
                diag.begin_date = DateTime.Parse(tbBeginDate.Text);
                diag.end_date = DateTime.Parse(tbEndDate.Text);
            }
            catch (Exception)
            {
                
            }

            int i = 0;
            String s = "";
            foreach(ListItem item in List_Motives.Items)
            {
                if (item.Selected)
                {
                    i++;
                    s += item.Text + ";";
                }
            }
            diag.reason = s;

            s = "";
            for (i = 1; i < 8; i++)
            {
                CheckBox cb = up1.FindControl("CheckBox" + i) as CheckBox;
                if (cb.Checked)
                {
                    ListBox lb = up1.FindControl("ListBox" + i) as ListBox;
                    foreach(ListItem item in lb.Items)
                    {
                        if (item.Selected)
                        {
                            s += item.Text + ";";
                        }
                    }
                    s += "/" + i + ";";
                }
            }
            diag.health_condition = s;

            s = "";
            if (medicines.Checked)
            {
                foreach(ListItem item in ListBoxMedicines.Items)
                {
                    if (item.Selected)
                    {
                        s += item.Text + ";";
                    }
                }
                if (anticoagulant.Checked)
                {
                    s += "/a;";
                    foreach (ListItem item in ListBoxAnticoagulant.Items)
                    {
                        if (item.Selected)
                        {
                            s += item.Text + ";";
                        }
                    }
                }
            }
            diag.medicines = s;

            if (no_smoker.Checked)
            {
                diag.isSmoker = 0;
            }
            else
            {
                diag.isSmoker = 1;
            }

            if (noFirstTime.Checked)
            {
                diag.firstTime = 0;
            }
            else
            {
                diag.firstTime = 1;
            }

            s = "";
            if (allergic.Checked)
            {
                foreach(ListItem item in ListBoxAllergy.Items)
                {
                    if (item.Selected)
                    {
                        s += item.Text + ";";
                    }
                }
            }
            diag.allergic = s;

            s = "";
            if (Cirurgy.Checked)
            {
                foreach(GridViewRow row in GridView2.Rows)
                {
                    s += row.Cells[0].Text + "/";
                    TextBox tb = row.Cells[1].FindControl("year") as TextBox;
                    s += tb.Text + ";";
                }
            }
            diag.surgery = s;

            s = "";
            if (sick.Checked)
            {
                foreach(ListItem item in ListBoxSick.Items)
                {
                    if (item.Selected)
                    {
                        s += item.Text+";";
                    }
                } 

            }
            diag.recentSick = s;

            s = "";
            if (malaria.Checked)
            {
                foreach(ListItem item in ListBoxMalaria.Items)
                {
                    if (item.Selected)
                    {
                        s += item.Text + ";";
                    }
                }
            }
            diag.malaria = s;

            s = "";
            i = 0;
            foreach(ListItem item in ListBoxVaccines.Items)
            {
                if (item.Selected)
                {
                    s += item.Text + "//";
                    if(!item.Text.Equals("Não sabe"))
                    {
                        TextBox tb =GridViewVaccines.Rows[i].Cells[1].FindControl("date") as TextBox;
                        s += tb.Text + ";";
                        i ++;
                    }
                }
                
            }
            diag.vaccines = s;

            s = "";
            if (sickTraveling.Checked)
            {
                foreach(GridViewRow row in GridViewSickTravelling.Rows)
                {
                    s += row.Cells[0].Text + "//";
                    TextBox tb = row.Cells[1].FindControl("treatment") as TextBox;
                    s += tb.Text + ";";
                }
            }
            diag.sickTravelling = s;
            using (data _db = new data())
            {
                _db.Diagnostic.Add(diag);
                _db.SaveChanges();
            }


            data data = new data();
            foreach (ListItem item in ListBoxRegions.Items)
            {
                if (item.Selected)
                {
                    i = int.Parse(item.Value);
                    var r = data.Region.Where(b => b.region_id == i).FirstOrDefault();
                    i = 0;
                   
                    foreach(GridViewRow row in GridView1.Rows)
                    {
                        Trip trip = new Trip();
                        trip.region_id = int.Parse(item.Value);
                        trip.diagnostic_id = diag.diagnostic_id;
                        s = "";
                        s += row.Cells[1].Text;
                        if (r.countries.Contains(s))
                        {
                            trip.country = s;
                            s = "";
                            TextBox tb = row.Cells[2].FindControl("locals") as TextBox;
                            s += tb.Text;
                            trip.destination = s;
                            CheckBox cb = row.Cells[3].FindControl("rural") as CheckBox;
                            s = "";
                            if (cb.Checked)
                            {
                                s += "rural;";
                            }
                            cb = row.Cells[3].FindControl("urbano") as CheckBox;
                            if (cb.Checked)
                            {
                                s += "urbano;";
                            }
                            trip.environment = s;

                            s = "";
                            ListBox lb = row.Cells[4].FindControl("ListBoxAccomodation") as ListBox;
                            foreach (ListItem item2 in lb.Items)
                            {
                                if (item2.Selected)
                                {
                                    s += item2.Text + ";";
                                }
                            }
                            trip.accommodation = s;

                            s = "";
                            lb = row.Cells[5].FindControl("ListBoxActivities") as ListBox;
                            foreach (ListItem item2 in lb.Items)
                            {
                                if (item2.Selected)
                                {
                                    s += item2.Text + ";";
                                }
                            }
                            trip.activities = s;

                            s = "";
                            tb = row.Cells[6].FindControl("checkin") as TextBox;
                            s += tb.Text;
                            trip.begin_date = DateTime.Parse(s);
                            s = "";
                            tb = row.Cells[6].FindControl("checkout") as TextBox;
                            s += tb.Text;
                            trip.end_date = DateTime.Parse(s);

                            data.Trip.Add(trip);
                            data.SaveChanges();
                        }
                      
                    }
                }
            }

            s = Request.QueryString["patientIdDiagnosticId"];
            String[] sIds = s.Split(',');
            int patientId = int.Parse(sIds[0]);
            int appoitmentId = int.Parse(sIds[1]);
            var app = data.Appointment.Where(b => b.appointment_id==appoitmentId).FirstOrDefault();
            app.diagnostic_id = diag.diagnostic_id;
            data.SaveChanges();
           

            Response.Redirect("BuildKit?patientIdDiagnosticId="+s);
        }
        protected void cancelClick(object sender, EventArgs e)
        {
            Response.Redirect("Calendar");
        }

        protected void ButtonClick1(object sender,EventArgs e)
        {
            ListItem item = new ListItem(Text1.Value, Text1.Value);
            item.Selected = true;
            ListBox1.Items.Add(item);
            Text1.Value = "";

        }
        protected void ButtonClick2(object sender, EventArgs e)
        {
            ListItem item = new ListItem(Text2.Value, Text2.Value);
            item.Selected = true;
            ListBox2.Items.Add(item);
            Text2.Value = "";

        }
        protected void ButtonClick3(object sender, EventArgs e)
        {
            ListItem item = new ListItem(Text3.Value, Text3.Value);
            item.Selected = true;
            ListBox3.Items.Add(item);
            Text3.Value = "";

        }
        protected void ButtonClick4(object sender, EventArgs e)
        {
            ListItem item = new ListItem(Text4.Value, Text4.Value);
            item.Selected = true;
            ListBox4.Items.Add(item);
            Text4.Value = "";

        }
        protected void ButtonClick5(object sender, EventArgs e)
        {
            ListItem item = new ListItem(Text5.Value, Text5.Value);
            item.Selected = true;
            ListBox5.Items.Add(item);
            Text5.Value = "";

        }
        protected void ButtonClick6(object sender, EventArgs e)
        {
            ListItem item = new ListItem(Text6.Value, Text6.Value);
            item.Selected = true;
            ListBox6.Items.Add(item);
            Text6.Value = "";

        }
        protected void ButtonClick7(object sender, EventArgs e)
        {
            ListItem item = new ListItem(Text7.Value, Text7.Value);
            item.Selected = true;
            ListBox7.Items.Add(item);
            Text7.Value = "";

        }
    }   
}
