using Microsoft.AspNet.Identity;
using SafeTravel.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SafeTravel.Pharmacy
{
    public partial class MakeOrder : System.Web.UI.Page
    {
        protected List<Product> list_products;
        protected List<string> names;
        protected List<string> list_prod = new List<string>();
        protected List<int> list_quant= new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["orderID"] != null)
            {
                int order_id = Convert.ToInt32(Request.QueryString["orderID"]);
                int pharmacy_id =Convert.ToInt32( Request.QueryString["pharmacyID"]);

                using (var context = new data())
                {
                    var _db = new data();
                    var query = _db.Order_Pharmacy.Where(p => p.order_id.Equals(order_id) && p.pharmacy_id.Equals(pharmacy_id)).ToList();

                    TextBox1.Visible = false;
                    TextBox2.Visible = false;

                    TextBoxOrderDate.Text = query[0].order_date.ToString().Replace("00:00:00", "");
                    TextBoxDeliveryDate.Text = query[0].delivery_date.ToString().Replace("00:00:00", "");
                    TextBoxOrderDate.Visible = true;
                    TextBoxDeliveryDate.Visible = true;

                    //esconder a listbox e adicionar produtos a gridview para mostrar

                    lblListBox.Visible = false;
                    ListBoxProducts.Visible = false;

                    DataTable table = new DataTable();          
                    table.Columns.Add(new DataColumn("p_name", typeof(string)));
                    table.Columns.Add(new DataColumn("quantity", typeof(int)));

                   // List<string> namesOfProducts = new List<string>();
                    
                    foreach(Order_Pharmacy order in query)
                    {
                        var prod = _db.Product.Where(p => p.product_id.Equals(order.product_id)).FirstOrDefault();
                        DataRow row = table.NewRow();
                        row["p_name"] = prod.p_name;
                        row["quantity"] = order.quantity;
                        table.Rows.Add(row);
                    }

                    GridViewSeeProducts.Visible = true;
                    GridViewSeeProducts.DataSource = table;
                    GridViewSeeProducts.DataBind();

                    if(query[0].info.Equals(""))
                    {
                        info.Visible = false;
                        lblInfo.Visible = false;
                    }
                    else
                    {
                        info.Text = query[0].info;
                        info.ReadOnly = true;
                    }

                    TextBoxOrderDate.ReadOnly = true;
                    TextBoxDeliveryDate.ReadOnly = true;

                    Cancel.Visible = false;
                    Save.Visible = false;
                    back.Visible = true;



                }


            }
            else
            {
                TextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                GridViewSeeProducts.Visible = false;
            }

            




        }
        public IQueryable GetProducts()
        {
            var _db = new data();
            IQueryable query = _db.Product.OrderBy(x=> x.p_name);
            return query;
        }
        
        protected void ListBoxProducts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            DataTable table = new DataTable();
            list_products = new List<Product>();

            table = (DataTable)ViewState["currentTable"];
            if (table == null)
            {
                table = new DataTable();
                table.Columns.Add(new DataColumn("product_id", typeof(string)));
                table.Columns.Add(new DataColumn("p_name", typeof(string)));

            }
            names = new List<string>();

            int i = 0;
            foreach (GridViewRow row in GridViewProducts.Rows)
            {
                Product p = new Product();
                p.p_name = row.Cells[1].Text;
                
                list_products.Add(p);
                names.Add(row.Cells[1].Text);
            }
            foreach (ListItem item in ListBoxProducts.Items)
            {
                if (item.Selected)
                {
                    DataRow row = table.NewRow();

                    row["product_id"] = item.Value;
                    row["p_name"] = item.Text;


                    i++;
                    table.Rows.Add(row);

                }

            }
            ViewState["CurrentTable"] = table;
            if (i != 0)
            {
                GridViewProducts.Visible = true;

                GridViewProducts.DataSource = table;
                GridViewProducts.DataBind();
            }
            else
            {
                GridViewProducts.Visible = false;
            }
            
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Orders");
        }

        protected void AddNewOrder_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < GridViewProducts.Rows.Count; i++)
            {
                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(GridViewProducts.Rows[i]);

                string name = Convert.ToString(rowValues["p_name"]);
                list_prod.Add(name);

                TextBox quantityTextBox = new TextBox();
                quantityTextBox = (TextBox)GridViewProducts.Rows[i].FindControl("howMany");
                int quantity= Convert.ToInt32(quantityTextBox.Text);
                list_quant.Add(quantity);
            }
            //string n = list_prod[0];
            //  int y = list_quant[0];

            // Save the order data in BD
            List<int> list_ids = new List<int>();

            string  mail = User.Identity.GetUserName();
            using (var context = new data())
            {
                var _db = new data();
                var query = _db.Pharmacy;
                var r = query.Where(p => p.email.Equals(mail)).FirstOrDefault();
                int id_pharmacy = r.pharmacy_id;

                foreach(String s in list_prod)
                {
                    var query2 = _db.Product;
                    var r2 = query2.Where(p=> p.p_name.Equals(s)).FirstOrDefault();
                    list_ids.Add(r2.product_id);
                }


                var list_order_pharmacy = _db.Order_Pharmacy.ToList();
                int new_order_id;
                if (list_order_pharmacy.Count==0)
                {
                     new_order_id = 1;
                }
                else
                {
                    new_order_id = list_order_pharmacy.Last().order_id+1;
                }
               

                
                int i = 0;

                foreach(int id in list_ids)
                {
                    var newOrder = new Order_Pharmacy();
                    newOrder.order_id = new_order_id;
                    newOrder.pharmacy_id = id_pharmacy;
                    newOrder.order_date= DateTime.Parse(TextBox1.Text); 
                    newOrder.delivery_date = DateTime.Parse(TextBox2.Text);
                    newOrder.info = info.Text;
                    newOrder.product_id = id;
                    newOrder.quantity = list_quant[i];
                    newOrder.isDelivered = 0;
                    i++;

                    _db.Order_Pharmacy.Add(newOrder);
                    _db.SaveChanges();
                }
                Response.Redirect("Orders");



            }







        }
        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }
    }
}