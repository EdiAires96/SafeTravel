using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Text;
using Microsoft.AspNet.Identity;

namespace SafeTravel.Medic
{


    public partial class BuildKit : System.Web.UI.Page
    {
        public static List<string> list = new List<string>();
        public static List<int> quant_list = new List<int>();
        public static int patientId=-1;
        public static int appId=-1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["patientIdDiagnosticId"]!=null)
            {
                String s = Request.QueryString["patientIdDiagnosticId"];
                String[] sId = s.Split(',');
                int patientId = int.Parse(sId[0]);
                int appId = int.Parse(sId[1]);
            }

            string query = "SELECT * FROM Product";;
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection("data source=DESKTOP-C38TKIF\\SQLEXPRESS;initial catalog=db_travel_consultation;user id=sa;password=ubi;multipleactiveresultsets=True;application name=EntityFramework"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    sda.Fill(table);
                }
            }
            ViewState["myViewState"] = table;
           // GridView1.DataSource = table;
           // GridView1.DataBind();


            if (Request.QueryString["ProductID"] != null )
            {

                /*
                int id = Int32.Parse(Request.QueryString["ProductID"]);

                using (var context = new data())
               {
                    var _db = new data();
                    var query = _db.Product;
                    var r = query.Where(p => p.product_id == id).FirstOrDefault();
                */

                string name = (Request.QueryString["name"]);
                int quant = Convert.ToInt32(Request.QueryString["quantity"]);
                string action = (Request.QueryString["action"]);

                if(action.Equals("remove"))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (name.Equals(list[i]))
                        {
                            list.RemoveAt(i);
                            quant_list.RemoveAt(i);
                        }
                    }
                    if(list.Count==0)
                    {
                        DataGrid.Visible = false;
                        emptyKit.Visible = true;
                    }


                }
                if(action.Equals("add"))
                {

                    if (!list.Contains(name))
                    {
                        list.Add(name);
                        quant_list.Add(quant);
                    }
                    else
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (name.Equals(list[i]))
                            {
                                quant_list[i] = quant;

                                if(quant_list[i]==0)
                                {
                                    list.RemoveAt(i);
                                    quant_list.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                    DataTable socialEvents = new DataTable();
                    socialEvents.Columns.Add(new DataColumn("Name", typeof(string)));
                    socialEvents.Columns.Add(new DataColumn("Quantity", typeof(string)));
                    DataRow row;

                /*
                    foreach (string p in list)
                    {
                        row = socialEvents.NewRow();
                        row["Name"] = p;
                        socialEvents.Rows.Add(row);
 
                    }
                    */
                    for(int i=0;i<list.Count;i++)
                    {
                        row = socialEvents.NewRow();
                        row["Name"] = list[i];   
                        row["Quantity"] =quant_list[i];
                        socialEvents.Rows.Add(row);
                    }




                    DataView view = socialEvents.DefaultView;
                    if (list.Count() > 0)
                    {
                        DataGrid.Visible = true;
                        DataGrid.DataSource = view;
                        DataGrid.DataBind();
                        DataGrid.Style[HtmlTextWriterStyle.MarginLeft] = "20px";
                        DataGrid.Style[HtmlTextWriterStyle.TextAlign] = "center";
                    }

                //DropDownList1.Items.Clear();
                foreach (string prod in list)
                 {
                    DropDownList1.Items.Add(new ListItem(prod));      
                 }
           
               

               

              
            }
            else
            {
                DataGrid.Visible = false;
                emptyKit.Visible = true;
            }


        }

        public IQueryable GetProducts()
        {
            var _db = new data();
            IQueryable query = _db.Product;
            return query;
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (appId<0 && patientId<0)
            {
                data data = new data();
                Kit kit = new Kit();

                var email = User.Identity.GetUserName();
                var medic = data.Medic.Where(b => b.m_email.Equals(email)).FirstOrDefault();

                kit.medic_id = medic.medic_id;

                data.Kit.Add(kit);
                data.SaveChanges();

                int i = 0;
                foreach(String prod in list)
                {
                   
                }
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
        protected void row_command(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "add")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(TotalProducts.Rows[index]);
                // int id= Convert.ToInt32(rowValues["product_id"]);
                 string name = Convert.ToString(rowValues["p_name"]);

                TextBox quantityTextBox = new TextBox();
                quantityTextBox = (TextBox)TotalProducts.Rows[index].FindControl("howMany");
                int quantity = Convert.ToInt32(quantityTextBox.Text);

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Equals(lblDropItem.Text))
                    {
                        list.RemoveAt(i);
                    }
                }

                using (var context = new data())
                {
                    var _db = new data();
                    var query = _db.Product;
                    var r = query.Where(p => p.p_name.Equals(name)).FirstOrDefault();
                    int id = r.product_id;



                    StringBuilder pageUrl = new StringBuilder();
                    pageUrl.Append("BuildKit.aspx?productID=");
                    pageUrl.Append(id);
                    pageUrl.Append("&name=");
                    pageUrl.Append(name);
                    pageUrl.Append("&quantity=");
                    pageUrl.Append(quantity);
                    pageUrl.Append("&action=add");


                    Response.Redirect(pageUrl.ToString());
                }

            }


            if (e.CommandName == "remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(TotalProducts.Rows[index]);
                string name = Convert.ToString(rowValues["p_name"]);

                TextBox quantityTextBox = new TextBox();
                quantityTextBox = (TextBox)TotalProducts.Rows[index].FindControl("howMany");
                int quantity = Convert.ToInt32(quantityTextBox.Text);


                using (var context = new data())
                {
                    var _db = new data();
                    var query = _db.Product;
                    var r = query.Where(p => p.p_name.Equals(name)).FirstOrDefault();
                    int id = r.product_id;



                    StringBuilder pageUrl = new StringBuilder();
                    pageUrl.Append("BuildKit.aspx?productID=");
                    pageUrl.Append(id);
                    pageUrl.Append("&name=");
                    pageUrl.Append(name);
                    pageUrl.Append("&action=remove");

                    Response.Redirect(pageUrl.ToString());
                }

            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            
            string search = textSearch.Text.ToLower();
            if (ViewState["myViewState"] == null)
                return;

            DataTable dt = ViewState["myViewState"] as DataTable;
            DataTable dtNew = dt.Clone();
           
            foreach(DataRow row in dt.Rows)
            {
                if(row["p_name"].ToString().ToLower().Contains(search) )
                {
                    dtNew.Rows.Add(row.ItemArray);
                }
            }
            GridView1.DataSource = dtNew;
            GridView1.DataBind();
            GridView1.Visible = true;
            TotalProducts.Visible = false;
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            if (ViewState["myViewState"] == null)
                return;

            textSearch.Text = "";
            GridView1.Visible = false;
            TotalProducts.Visible = true;

        }
        protected void row_command2(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "add")
            {              
                int index = Convert.ToInt32(e.CommandArgument);
                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(GridView1.Rows[index]);
                string name = Convert.ToString(rowValues["p_name"]);
                TextBox quantityTextBox = new TextBox();
                quantityTextBox = (TextBox)GridView1.Rows[index].FindControl("howMany");
                int quantity = Convert.ToInt32(quantityTextBox.Text);

                using (var context = new data())
                {
                    var _db = new data();
                    var query = _db.Product;
                    var r = query.Where(p => p.p_name.Equals(name)).FirstOrDefault();
                    int id = r.product_id;

                    StringBuilder pageUrl = new StringBuilder();
                    pageUrl.Append("BuildKit.aspx?productID=");
                    pageUrl.Append(id);
                    pageUrl.Append("&name=");
                    pageUrl.Append(name);
                    pageUrl.Append("&quantity=");
                    pageUrl.Append(quantity);
                    pageUrl.Append("&action=add");
                    Response.Redirect(pageUrl.ToString());
                }
                
            }

            
            if (e.CommandName == "remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(TotalProducts.Rows[index]);
                string name = Convert.ToString(rowValues["p_name"]);

                TextBox quantityTextBox = new TextBox();
                quantityTextBox = (TextBox)TotalProducts.Rows[index].FindControl("howMany");
                int quantity = Convert.ToInt32(quantityTextBox.Text);


                using (var context = new data())
                {
                    var _db = new data();
                    var query = _db.Product;
                    var r = query.Where(p => p.p_name.Equals(name)).FirstOrDefault();
                    int id = r.product_id;



                    StringBuilder pageUrl = new StringBuilder();
                    pageUrl.Append("BuildKit.aspx?productID=");
                    pageUrl.Append(id);
                    pageUrl.Append("&name=");
                    pageUrl.Append(name);
                    pageUrl.Append("&action=remove");

                    Response.Redirect(pageUrl.ToString());
                }

            }
            
        }
        protected void AddNewKitProduct_Click(object sender, EventArgs e)
        {
            string name = newKitProduct.Text;
            int quant =Convert.ToInt32( newKitProductQuant.Text);

            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Equals(lblDropItem.Text))
                {
                    list.RemoveAt(i);
                }
            }
            

            list.Add(name);
            quant_list.Add(quant);

            DropDownList1.Items.Clear();
            foreach (string prod in list)
            {
                DropDownList1.Items.Add(new ListItem(prod));
            }

            newKitProduct.Text = "";
            newKitProductQuant.Text="";

            emptyKit.Visible = false;


            DataTable socialEvents = new DataTable();
            socialEvents.Columns.Add(new DataColumn("Name", typeof(string)));
            socialEvents.Columns.Add(new DataColumn("Quantity", typeof(string)));
            DataRow row;


            for (int i = 0; i < list.Count; i++)
            {
                row = socialEvents.NewRow();
                row["Name"] = list[i];
                row["Quantity"] = quant_list[i];
                socialEvents.Rows.Add(row);
            }


            DataView view = socialEvents.DefaultView;
            if (list.Count() > 0)
            {
                DataGrid.Visible = true;
                DataGrid.DataSource = view;
                DataGrid.DataBind();
                DataGrid.Style[HtmlTextWriterStyle.MarginLeft] = "20px";
                DataGrid.Style[HtmlTextWriterStyle.TextAlign] = "center";
            }


        }

        protected void RemoveKitProduct_Click(object sender, EventArgs e)
        {

            lblDropItem.Text = DropDownList1.SelectedItem.Text;

            
            for (int i = 0; i < list.Count; i++)
            {
                if (lblDropItem.Text.Equals(list[i]))
                {
                    list.RemoveAt(i);
                    quant_list.RemoveAt(i);

                }
            }

            if (list.Count == 0)
            {
                DataGrid.Visible = false;
                emptyKit.Visible = true;
            }
            else
            {

                DataTable socialEvents = new DataTable();
                socialEvents.Columns.Add(new DataColumn("Name", typeof(string)));
                socialEvents.Columns.Add(new DataColumn("Quantity", typeof(string)));
                DataRow row;


                for (int i = 0; i < list.Count; i++)
                {
                    row = socialEvents.NewRow();
                    row["Name"] = list[i];
                    row["Quantity"] = quant_list[i];
                    socialEvents.Rows.Add(row);
                }


                DataView view = socialEvents.DefaultView;
                if (list.Count() > 0)
                {
                    DataGrid.Visible = true;
                    DataGrid.DataSource = view;
                    DataGrid.DataBind();
                    DataGrid.Style[HtmlTextWriterStyle.MarginLeft] = "20px";
                    DataGrid.Style[HtmlTextWriterStyle.TextAlign] = "center";
                }
            }

            DropDownList1.Items.Clear();
            foreach (string prod in list)
            {
                DropDownList1.Items.Add(new ListItem(prod));
            }

        }


    }
}