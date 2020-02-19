using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;
using SafeTravel.Logic;
using System.Data;

namespace SafeTravel.Medic
{
    public partial class MedicAddPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["PatientID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["PatientID"]);
                    if (id > 0)
                    {
                        var _db = new data();
                        var query = _db.Patient;
                        var r = query.Where(p => p.patient_id == id).FirstOrDefault();
                        PatientName.Text = r.p_name;
                        PatientAddress.Text = r.p_address;
                        PatientDate.Text = Convert.ToString(r.date_of_birth);
                        PatientNumberHealth.Text = Convert.ToString(r.number_health);
                        PatientEmail.Text = r.p_email;
                        PatientPhoneNumber.Text = Convert.ToString(r.phone_number);
                        PatientJob.Text = r.job;
                        PatientNaturality.Text = r.naturality;
                        PatientFinancialNumber.Text = Convert.ToString(r.financial_number);
                        /*
                        if (r.genre.Equals("M"))
                        {
                            CheckM.;
                        }
                        if (r.genre.Equals("F"))
                        {
                            CheckF.;
                        }
                        */


                    }
                }
            }

            if (Request.QueryString["patientID"] != null)
            {
                String s = Request.QueryString["patientID"];
                int patient_id = int.Parse(s);

                DataTable tableDiag = new DataTable();

                tableDiag = new DataTable();
                tableDiag.Columns.Add(new DataColumn("id", typeof(string)));
                tableDiag.Columns.Add(new DataColumn("Diag", typeof(string)));
                tableDiag.Columns.Add(new DataColumn("date", typeof(string)));
                tableDiag.Columns.Add(new DataColumn("regions", typeof(string)));

                data data = new data();
                var apps = data.Appointment.Where(b => b.patient_id == patient_id & b.diagnostic_id != null).ToList();
                if (apps.Count > 0)
                {
                    div2.Visible = true;
                }
                foreach (Appointment a in apps)
                {
                    DataRow row = tableDiag.NewRow();
                    row["id"] = a.patient_id.ToString() + "," + a.appointment_id.ToString();
                    row["Diag"] = a.diagnostic_id.ToString();
                    row["date"] = a.a_date.ToShortDateString();

                    var trips = data.Trip.Where(b => b.diagnostic_id == a.diagnostic_id).ToList();
                    foreach (Trip t in trips)
                    {
                        var region = data.Region.Where(b => b.region_id == t.region_id).FirstOrDefault();
                        row["regions"] += region.r_name + " ";
                    }
                    tableDiag.Rows.Add(row);

                }

                ViewState["CurrentTable"] = tableDiag;
                GridViewDiagnostic.DataSource = tableDiag;
                GridViewDiagnostic.DataBind();
            }
        }
        public bool EditPatient(String name, String address, String date, String number_health, String phone_number, String email, String job, String naturality, String genre, String financial_number)
        {
            int id = Int32.Parse(Request.QueryString["PatientID"]);
            using (data _db = new data())
            {
                // Add product to DB.
                var r = _db.Patient.First(i => i.patient_id == id);
                r.p_email = name;
                r.p_address = address;
                date = date + " 00:00";
                r.date_of_birth = Convert.ToDateTime(date);
                r.number_health = Convert.ToInt32(number_health);
                r.phone_number = Convert.ToInt32(phone_number);
                r.p_email = email;
                r.job = job;
                r.naturality = naturality;
                r.genre = genre;
                r.financial_number = Convert.ToInt32(financial_number);



                _db.SaveChanges();
            }
            // Success.
            return true;
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientsList");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            AddPatients patients = new AddPatients();
            String genre = null;

            if (CheckM.Checked == true)
            {
                genre = "M";
            }
            if (CheckF.Checked == true)
            {
                genre = "F";
            }

            if (Request.QueryString["PatientID"] != null)
            {
                bool editSuccess = EditPatient(PatientName.Text, PatientAddress.Text, PatientDate.Text, PatientNumberHealth.Text, PatientPhoneNumber.Text, PatientEmail.Text, PatientJob.Text, PatientNaturality.Text, genre, PatientFinancialNumber.Text);
                if (editSuccess)
                {
                    // Reload the page.

                    Response.Redirect("PatientsList" + "?PatientEditAction=sucess");
                }
                else
                {
                    Response.Redirect("PatientsList" + "?PatientEditAction=fail");
                }
            }
            else
            {
                bool addSuccess = patients.AddPatient(PatientName.Text, PatientAddress.Text, PatientDate.Text, PatientNumberHealth.Text, PatientPhoneNumber.Text, PatientEmail.Text, PatientJob.Text, PatientNaturality.Text, genre, PatientFinancialNumber.Text);

                if (addSuccess)
                {
                    Response.Redirect("PatientsList");
                }

            }





        }
    }
}