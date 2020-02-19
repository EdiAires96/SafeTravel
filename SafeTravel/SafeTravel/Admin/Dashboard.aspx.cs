using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;

namespace SafeTravel.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new data();
            var totalMedics = db.Medic.Count();
            TotalMedics.Text = Convert.ToString(totalMedics);

            var totalPharmacies = db.Pharmacy.Count();
            TotalPharmacies.Text = Convert.ToString(totalPharmacies);

            var totalPatients = db.Patient.Count();
            TotalPatients.Text = Convert.ToString(totalPatients);


        }
    }
}