using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Models;
using System.Data;
using System.Drawing;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Web.Script.Services;
using System.Web.Services;

namespace SafeTravel.Medic
{ 
    

    public partial class Calendar : System.Web.UI.Page
    {
        private static string mail ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            mail = User.Identity.GetUserName();
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            using (var context = new data())
            {
                DateTime begin = Calendar1.SelectedDate.Date;
                DateTime end = Calendar1.SelectedDate.AddDays(1);
                var email = User.Identity.GetUserName();
                var medic = context.Medic.Where(b => b.m_email.Equals(email)).FirstOrDefault();
                var appoitments = context.Appointment.Where(b => b.a_date >= begin && b.a_date < end && b.medic_id == medic.medic_id);

                DataTable socialEvents = new DataTable();
                socialEvents.Columns.Add(new DataColumn("Time", typeof(string)));
                socialEvents.Columns.Add(new DataColumn("id", typeof(string)));
                socialEvents.Columns.Add(new DataColumn("Patient", typeof(string)));
                socialEvents.Columns.Add(new DataColumn("obs", typeof(string)));

                foreach(Appointment app in appoitments)
                {
                    string hour=app.a_date.Hour.ToString();
                    string minute=app.a_date.Minute.ToString();
                    DataRow row;
                    row = socialEvents.NewRow();
                    if (app.a_date.Hour >= 0 && app.a_date.Hour < 10)
                    {
                        hour = "0"+app.a_date.Hour;
                    }
                    if (app.a_date.Minute >= 0 && app.a_date.Minute < 10)
                    {
                        minute = "0" + app.a_date.Minute;
                    }
                    row["Time"] = hour + ":" + minute;
                    row["obs"] = app.obs;
                    if (app.patient_id != 0)
                    {
                        var patient = context.Patient.Where(b => b.patient_id == app.patient_id).FirstOrDefault();
                        row["Patient"] = patient.p_name;
                        row["id"] = patient.patient_id;

                    }
                    else
                    {
                        row["Patient"] = "(Não Registado)";
                    }
                    
                    socialEvents.Rows.Add(row);
                }
                DataView view = socialEvents.DefaultView;

                if (appoitments.Count() > 0)
                {
                    DataGrid1.Visible = true;
                    DataGrid1.DataSource = view;
                    DataGrid1.DataBind();
                    DataGrid1.Style[HtmlTextWriterStyle.MarginLeft] = "20px";
                    DataGrid1.Style[HtmlTextWriterStyle.TextAlign] = "center";
                }
                else
                {
                    DataGrid1.Visible = false;
                }
            }

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            using (var context = new data())
            {
                
                DateTime begin = e.Day.Date;
                DateTime end = e.Day.Date.AddDays(1);

                var email = User.Identity.GetUserName(); 
                var medic = context.Medic.Where(b => b.m_email.Equals(email)).FirstOrDefault();
                var appoitments = context.Appointment.Where(b => b.a_date >= begin && b.a_date < end && b.medic_id==medic.medic_id);
                int count = 0;

                foreach (Appointment row in appoitments)
                {
                    count++;
                    //Image image;
                    //image = new System.Web.UI.WebControls.Image();
                    //image.ImageUrl = "dot.gif";
                    //image.ToolTip = row["Description"].ToString();


                }
                if (count != 0)
                {
                    Label l=new Label();
                    l.Style[HtmlTextWriterStyle.MarginLeft] = "50px";
                   
                    e.Cell.Controls.Add(l);
                    l.Text = "(" + count + ")";
                    l.Font.Size=6;
                                      
                }
                if (count > 0 && count <= 5)
                    e.Cell.BackColor = Color.FromArgb(1, 144, 242, 80);
                if (count > 5 && count < 11)
                    e.Cell.BackColor = Color.FromArgb(1, 255, 219, 77);
                if (count > 10)
                    e.Cell.BackColor = Color.FromArgb(1, 255, 77, 77);

            }
        }
        
        public Boolean addAppoitment(String number,String name,String date)
        {
            var p = new Patient();
            var a = new Appointment();
            p.number_health = long.Parse( number);
            p.p_name = name;
            using (data _db = new data())
            {
                var aux = _db.Patient.Where(b => b.number_health == p.number_health).ToList();
                if (aux.Count() == 0)
                {
                    _db.Patient.Add(p);
                    _db.SaveChanges();
                }
                // Add product to DB.
                var patient = _db.Patient.Where(b => b.number_health == p.number_health).FirstOrDefault();
                var medic = _db.Medic.Where(b => b.m_email.Equals(mail)).FirstOrDefault();
                
                a.medic_id = medic.medic_id;
                a.patient_id = patient.patient_id;
                a.a_date = DateTime.Parse(date);
                var app = _db.Appointment.Where(b => b.a_date.Equals(a.a_date)).ToList();
                if(app.Count == 0)
                {
                    _db.Appointment.Add(a);
                    _db.SaveChanges();
                }
                else
                {
                    return false;
                }
                

            }
            return true;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            bool addSuccess =addAppoitment(tnumber.Text, tname.Text, tdate.Text);
            if (addSuccess)
            {
                // Reload the page.

                Response.Redirect("Calendar" + "?AppoitmentAddAction=sucess");
                lerror.Text = "";
            }
            else
            {
                lerror.Text = "Já tem Consulta para essa hora";
                lerror.DataBind();
                ModalPopupExtender1.Show();
                
            }
        }

        protected void tNumberChange(object sender, EventArgs e)
        {
            var n = tnumber.Text;
            try
            {
                long number = long.Parse(tnumber.Text);
                var _db = new data();
                var patient = _db.Patient.Where(b => b.number_health == number).ToList();
                if (patient.Count != 0)
                {
                    tname.Text = patient.ElementAt(0).p_name;
                    tname.ReadOnly = true;
                }
                else
                {
                    tname.ReadOnly = false;
                    tname.Text = "";
                }
            }
            catch(Exception)
            {
                
            }    
            
            
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void agendingClick(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            lerror.Text = "";
            tname.Text = "";
            tnumber.Text = "";
            tdate.Text = "DD/MM/AAAA";
            lerror.DataBind();
        }
    }
    
}