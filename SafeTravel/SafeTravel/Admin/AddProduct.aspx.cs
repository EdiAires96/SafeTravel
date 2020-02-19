using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;

namespace SafeTravel.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["ProductID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["ProductID"]);
                    if (id > 0)
                    {
                        var _db = new data();
                        var query = _db.Product;
                        var r = query.Where(p => p.product_id == id).FirstOrDefault();
                        ProductName.Text = r.p_name;
                        ProductPrice.Text = Convert.ToString(r.price);
                        ProductInfo.Text = r.info;

                    }
                }
            }
        }
        public bool EditProduct(String name, String price,String info)
        {

            int id = Int32.Parse(Request.QueryString["ProductID"]);
            using (data _db = new data())
            {
                
                var r = _db.Product.First(i => i.product_id== id);
                r.p_name = name;
                r.price = Convert.ToDouble(price);
                r.info = info;

                _db.SaveChanges();
            }
            // Success.
            return true;
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products");
        }

        protected void Save_Click(object sender, EventArgs e)
        {

            bool active = true;
            if (CheckYes.Checked == true)
            {
                active = true;
            }
            if (CheckNo.Checked == true)
            {
                active = false;
            }

            if (Request.QueryString["ProductID"] != null)
            {
                bool editSuccess = EditProduct(ProductName.Text,ProductPrice.Text,ProductInfo.Text);
                if (editSuccess)
                {
                    // Reload the page.

                    Response.Redirect("Products" + "?ProductEditAction=sucess");
                }
                else
                {
                    Response.Redirect("Products" + "?ProductsEditAction=fail");
                }
            }
            else
            {
                    var myProduct = new Models.Product();
                    myProduct.p_name = ProductName.Text;
                    myProduct.price = Convert.ToDouble(ProductPrice.Text);
                    myProduct.info = ProductInfo.Text;
                    myProduct.is_active = active;

                    using (data _db = new data())
                    {
                        //Add product to database
                        _db.Product.Add(myProduct);
                        _db.SaveChanges();
                    }
                    Response.Redirect("Products");
            }
        }
    }
}