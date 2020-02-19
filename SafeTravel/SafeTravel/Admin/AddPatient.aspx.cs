using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Logic;
using SafeTravel.Models;

namespace SafeTravel.Admin
{
    public partial class AddPatient : System.Web.UI.Page
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
        }
        public bool Add_Patient(String name, String address, String date, String number_health, String phone_number, String email, String job, String naturality, String genre, String financial_number)
        {
            var myPatient = new Models.Patient();
            myPatient.p_name = name;
            myPatient.p_address = address;
            date = date + " 00:00";
            myPatient.date_of_birth = Convert.ToDateTime(date);
            myPatient.number_health = Convert.ToInt64(number_health);
            myPatient.phone_number = Convert.ToInt32(phone_number);
            myPatient.p_email = email;
            myPatient.job = job;
            myPatient.naturality = naturality;
            myPatient.genre = genre;
            myPatient.financial_number = Convert.ToInt64(financial_number);

            using (data _db = new data())
            {
                //Add patient to database
                _db.Patient.Add(myPatient);
                _db.SaveChanges();
            }

            //Sucess
            return true;
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
                r.number_health =Convert.ToInt32(number_health);
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
            Response.Redirect("Patients");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            //AddPatients patients = new AddPatients();
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

                    Response.Redirect("Patients" + "?PatientEditAction=sucess");
                }
                else
                {
                    Response.Redirect("Patients" + "?PatientEditAction=fail");
                }
            }
            else
            {
                bool addSuccess = Add_Patient(PatientName.Text, PatientAddress.Text, PatientDate.Text, PatientNumberHealth.Text, PatientPhoneNumber.Text, PatientEmail.Text, PatientJob.Text, PatientNaturality.Text, genre, PatientFinancialNumber.Text);

                if (addSuccess)
                {
                    Response.Redirect("Patients");
                }

            }




            
        }
    }
}