using Microsoft.AspNet.Identity;
using SafeTravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SafeTravel.Pharmacy
{
    public partial class PharmacyProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mail = User.Identity.GetUserName();
            using (var context = new data())
            {
                var _db = new data();
                var query = _db.Pharmacy;
                var r = query.Where(p => p.email.Equals(mail)).FirstOrDefault();
                int id_pharmacy = r.pharmacy_id;
                var list_prods = _db.Stock.Where(s => s.pharmacy_id.Equals(id_pharmacy)).ToList();

                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("p_name", typeof(string)));
                table.Columns.Add(new DataColumn("stock", typeof(int)));

                DataRow row;

                foreach(Stock s in list_prods)
                {  
                  var product= _db.Product.Where(p => p.product_id.Equals(s.product_id)).FirstOrDefault();

                    row = table.NewRow();
                    row["p_name"] = product.p_name;
                    row["stock"] = s.quantity;
                    table.Rows.Add(row);
                }
                DataView view = table.DefaultView;

                if(list_prods.Count !=0)
                {
                    GridProducts.DataSource = view;
                    GridProducts.DataBind();
                }
                else
                {
                    GridProducts.Visible = false;
                    emptyGrid.Visible = true;
                }


            }
        }
    }
}