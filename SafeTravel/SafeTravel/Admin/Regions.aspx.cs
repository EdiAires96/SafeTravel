using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;

namespace SafeTravel.Admin
{
    public partial class Regions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddRegion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRegion");
        }
        public IQueryable GetRegion()
        {
            var _db = new data();
            IQueryable query = _db.Region;
            return query;
        }
    }
}