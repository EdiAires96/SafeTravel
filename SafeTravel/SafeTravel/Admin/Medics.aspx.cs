using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using SafeTravel.Models;

namespace SafeTravel.Admin
{
    public partial class Medics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable GetMedics()
        {
            var _db = new data();
            IQueryable query = _db.Medic;
            return query;
        }

        protected void AddMedic_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMedic?MedicID=0");
        }

       
    }
}