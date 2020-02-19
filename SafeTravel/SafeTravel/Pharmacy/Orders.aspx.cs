using Microsoft.AspNet.Identity;
using SafeTravel.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SafeTravel.Pharmacy
{
    public partial class Orders : System.Web.UI.Page
    {
        protected List<int> orders_ids = new List<int>();
        protected List<string> orders_dates = new List<string>();

        public static List<int> aux_orders_ids = new List<int>();
        public static List<string> aux_orders_dates = new List<string>();

        public static List<int> orders_received = new List<int>();
        public static List<string> received_dates = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Request.QueryString["id"] != null)
            {
                 
                int id =Convert.ToInt32(Request.QueryString["id"]);
                string date = Request.QueryString["date"];


                aux_orders_ids.Remove(id);
                //  aux_orders_dates.Remove(date);
                for (int i = 0; i < aux_orders_dates.Count; i++)
                {
                    if(aux_orders_dates[i].Contains(date))
                    {
                        aux_orders_dates.RemoveAt(i);
                    }
                }

                if(!orders_received.Contains(id))
                {
                    orders_received.Add(id);
                    received_dates.Add(date);
                }   
               


                DataTable table1 = new DataTable();
                table1.Columns.Add(new DataColumn("OrderID", typeof(int)));
                table1.Columns.Add(new DataColumn("DeliveryDate", typeof(string)));
                DataRow row;

                for (int i = 0; i < aux_orders_ids.Count; i++)
                {
                    row = table1.NewRow();
                    row["OrderID"] = aux_orders_ids[i];
                    row["DeliveryDate"] = aux_orders_dates[i];
                    table1.Rows.Add(row);
                }


                DataView view = table1.DefaultView;
                if (aux_orders_ids.Count() > 0)
                {
                
                    GridOrders.DataSource = view;
                    GridOrders.DataBind();
                    GridOrders.Style[HtmlTextWriterStyle.MarginLeft] = "20px";
                    GridOrders.Style[HtmlTextWriterStyle.TextAlign] = "center";
                }
                else
                {
                    GridOrders.Visible = false;
                }

                /////////////////////////////////////////////////////////////////////////

                /*
                for (int i = 0; i < orders_received.Count; i++)          
                {
                    using (var context = new data())
                    {
                        var _db = new data();
                        var orders = _db.Order_Pharmacy.ToList();

                        if(orders_received[i] == orders[i].order_id && orders[i].isDelivered==0)
                        {
                            orders_received.RemoveAt(i);
                        }
                    }
                }
                */
                DataTable table2 = new DataTable();
                table2.Columns.Add(new DataColumn("OrderID2", typeof(int)));
                table2.Columns.Add(new DataColumn("DeliveryDate2", typeof(string)));
                DataRow row2;


                for (int i = 0; i < orders_received.Count; i++)
                {
                    row2 = table2.NewRow();
                    row2["OrderID2"] = orders_received[i];
                    row2["DeliveryDate2"] = received_dates[i];
                    table2.Rows.Add(row2);
                }


                DataView view2 = table2.DefaultView;
                if (orders_received.Count() > 0)
                {

                    GridReceiveOrders.DataSource = view2;
                    GridReceiveOrders.DataBind();
                    GridReceiveOrders.Style[HtmlTextWriterStyle.MarginLeft] = "20px";
                    GridReceiveOrders.Style[HtmlTextWriterStyle.TextAlign] = "center";
                }
             
                
            
            }//if(Request.QueryString["name"] != null)

            else
            {
               
                string mail = User.Identity.GetUserName();

                using (var context = new data())
                {
                    var _db = new data();
                    var far = _db.Pharmacy.Where(p=>p.email.Equals(mail)).FirstOrDefault();
                    int id_pharmacy = far.pharmacy_id;
                    var query = _db.Order_Pharmacy.Where(r=>r.pharmacy_id.Equals(id_pharmacy) && r.isDelivered==0).ToList();
                    
                    
                    
                    foreach(Order_Pharmacy o in query)
                    {
                        orders_ids.Add(o.order_id);
                        orders_dates.Add(o.delivery_date.ToString());
                    }
                    orders_ids = orders_ids.Distinct().ToList();
                    orders_dates = orders_dates.Distinct().ToList();
                    
                   
                 }
                    orders_dates = (from c in orders_dates select c.Replace("00:00:00", "")).ToList();
                    aux_orders_ids = orders_ids.ToList();
                    aux_orders_dates = orders_dates.ToList();

                

                DataTable table1 = new DataTable();
                table1.Columns.Add(new DataColumn("OrderID", typeof(int)));
                table1.Columns.Add(new DataColumn("DeliveryDate", typeof(string)));
                
                DataRow row;

                for (int i = 0; i < orders_ids.Count; i++)
                {

                    row = table1.NewRow();
                    row["OrderID"] = orders_ids[i];
                    row["DeliveryDate"] = orders_dates[i];
                    table1.Rows.Add(row);
                }


                DataView view = table1.DefaultView;
                if (orders_ids.Count() > 0)
                {

                    GridOrders.DataSource = view;
                    GridOrders.DataBind();
                    GridOrders.Style[HtmlTextWriterStyle.MarginLeft] = "20px";
                    GridOrders.Style[HtmlTextWriterStyle.TextAlign] = "center";
                }
                else
                {
                    GridOrders.Visible = false;
                    emptyGrid.Visible = true;
                }
            }

        }

        protected void AddOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("MakeOrder");
        }


           protected void row_command(Object sender, GridViewCommandEventArgs e)
           {
               if (e.CommandName.Equals("add"))
               {
                    int index = Convert.ToInt32(e.CommandArgument);

                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(GridOrders.Rows[index]);
                    int order_id = Convert.ToInt32(rowValues["OrderID"]);
                    string date = Convert.ToString(rowValues["DeliveryDate"]);

                //Save the products order and theirs quantities
                List<int> prods_ids = new List<int>();
                List<int> prods_qtt = new List<int>();
                string mail = User.Identity.GetUserName();

                using (var context = new data())
                {
                    var _db = new data();
                    var far = _db.Pharmacy.Where(p => p.email.Equals(mail)).FirstOrDefault();
                    int id_pharmacy = far.pharmacy_id;

                    var query = _db.Order_Pharmacy.Where(p=>p.order_id.Equals(order_id)).ToList();
                    foreach(Order_Pharmacy o in query)
                    {
                        prods_ids.Add(o.product_id);
                        prods_qtt.Add(o.quantity);
                        _db.Order_Pharmacy.Where(p => p.order_id.Equals(o.order_id) && p.isDelivered == 0).FirstOrDefault().isDelivered = 1;
                        _db.SaveChanges();

                    }

                    //add stock
                    for (int i = 0; i < prods_ids.Count; i++)
                    {

                        int id = prods_ids[i];

                        //ta a dar erro aqui                                                                  
                        var prod_stock = _db.Stock.Where(s => s.pharmacy_id.Equals(id_pharmacy) && s.product_id.Equals(id)).FirstOrDefault();

                        if (prod_stock != null )
                        {
                            prod_stock.quantity = prod_stock.quantity + prods_qtt[i];
                            _db.SaveChanges();
                        }
                        else
                        {
                            Stock stock = new Stock();
                            stock.pharmacy_id = id_pharmacy;
                            stock.product_id = prods_ids[i];
                            stock.quantity = prods_qtt[i];

                            _db.Stock.Add(stock);
                            _db.SaveChanges();

                        }
                    }

                }


                    Response.Redirect("Orders.aspx?id="+ order_id +"&date="+date);
               }
            

        }
        protected void Link_Button_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            int order_id = Convert.ToInt32(row.Cells[1].Text);
            string mail = User.Identity.GetUserName();
            using (var context = new data())
            {
                var _db = new data();
                var far = _db.Pharmacy.Where(p => p.email.Equals(mail)).FirstOrDefault();
                int id_pharmacy = far.pharmacy_id;

                Response.Redirect("MakeOrder.aspx?orderID=" + order_id + "&pharmacyID=" + id_pharmacy);
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