using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;

namespace SafeTravel.Medic
{
    public partial class PatientsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void MedicAddPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicAddPatient");
        }
        public IQueryable GetPatients()
        {
            var _db = new data();
            IQueryable query = _db.Patient;
            return query;
        }
    }
}