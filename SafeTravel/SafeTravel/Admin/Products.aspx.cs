using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;

namespace SafeTravel.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct");
        }
        public IQueryable GetProducts()
        {
            var _db = new data();
            IQueryable query = _db.Product;
            return query;
        }

    }
}