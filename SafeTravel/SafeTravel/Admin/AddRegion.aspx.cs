using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;

namespace SafeTravel.Admin
{
    public partial class AddRegionaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["RegionID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["RegionID"]);
                    if (id > 0)
                    {
                        var _db = new data();
                        var query = _db.Region;
                        var r = query.Where(p => p.region_id == id).FirstOrDefault();
                        RegionName.Text = r.r_name;
                        Countrys.Text = r.countries;
                        Concerns.Text = r.precautions;
                        Description.Text = r.info;
                    }
                }
            }
            
            
            
        }
        public bool AddRegion(string RegionName, string Countries, string Precautions, string Info)
        {
            var myRegion = new Region();
            myRegion.r_name = RegionName;
            myRegion.countries = Countries;
            myRegion.precautions = Precautions;
            myRegion.info = Info;
            using (data _db = new data())
            {
                // Add product to DB.
                _db.Region.Add(myRegion);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
        public bool EditRegion(string RegionName, string Countries, string Precautions, string Info)
        {
            
            
            int id = Int32.Parse(Request.QueryString["RegionID"]);
            using (data _db = new data())
            {
                // Add product to DB.
                var r = _db.Region.First(i => i.region_id==id);
                r.r_name = RegionName;
                r.countries = Countries;
                r.precautions = Precautions;
                r.info = Info;
                
                _db.SaveChanges();
            }
            // Success.
            return true;
        }

        protected void AddRegionButtonClick(object sender,EventArgs e)
        {
            if (Request.QueryString["RegionID"] != null)
            {
                bool editSuccess = EditRegion(RegionName.Text, Countrys.Text, Concerns.Text, Description.Text);
                if (editSuccess)
                {
                    // Reload the page.

                    Response.Redirect("Regions" + "?RegionEditAction=sucess");
                }
                else
                {
                    Response.Redirect("Regions" + "?RegionEditAction=fail");
                }
            }
            else
            {
                bool addSuccess = AddRegion(RegionName.Text,Countrys.Text,Concerns.Text,Description.Text);
                if (addSuccess)
                {
                    // Reload the page.
                
                    Response.Redirect("Regions" + "?RegionAddAction=sucess");
                }
                else
                {
                    Response.Redirect("Regions" + "?RegionAddAction=fail");
                }
            }
            

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Regions");
        }
    }
}