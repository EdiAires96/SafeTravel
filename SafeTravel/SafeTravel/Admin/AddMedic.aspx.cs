using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SafeTravel.Logic;
using SafeTravel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Net.Mail;
using System.Text;

namespace SafeTravel.Admin
{
    public partial class AddMedic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["MedicID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["MedicID"]);
                    if (id > 0)
                    {
                        var _db = new data();
                        var query = _db.Medic;
                        var r = query.Where(p => p.medic_id == id).FirstOrDefault();

                        MedicName.Text = r.m_mame;
                        MedicPhoneNumber.Text = Convert.ToString(r.phone_number);
                        MedicEmail.Text = r.m_email;
                    }
                }
            }

        }
        public bool EditMedic(string MedicName, string MedicPhoneNumber, string MedicEmail,String ident, bool active)
        {


            int id = Int32.Parse(Request.QueryString["MedicID"]);
            using (data _db = new data())
            {
                
                var r = _db.Medic.First(i => i.medic_id == id);
                r.m_mame = MedicName;
                r.phone_number = Convert.ToInt32(MedicPhoneNumber);
                r.m_email = MedicEmail;
                r.is_active = active;
                r.ident = ident;

                _db.SaveChanges();
            }
            // Success.
            return true;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medics");
        }
        /*
        public string CreatePassword()
        {
            int length= 6;
            int flagLow = 0;
            int flagBig = 0;
            int flagNumber = 0;

            String low = "abcdefghijklmnopqrstuvwxyz";
            String big = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String number= "1234567890";

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            
            while (0 < length--)
            {
                var random = valid[rnd.Next(valid.Length)];
                if (low.Contains(random))
                    flagLow = 1;
                if (big.Contains(random))
                    flagBig = 1;
                if (number.Contains(random))
                    flagNumber = 1;

                res.Append(random);
            }

            if (flagLow == 1 && flagBig == 1 && flagNumber == 1)
                return res.ToString();
            else
               return CreatePassword();

        }
        */
        private string GeneratePassword()
        {

            bool requireDigit = true;
            bool requireLowercase = true;
            bool requireUppercase = true;

            string randomPassword = string.Empty;

            int passwordLength = 6;

            Random random = new Random();
            while (randomPassword.Length != passwordLength)
            {
                int randomNumber = random.Next(48, 122);  // >= 48 && < 122 
                if (randomNumber == 95 || randomNumber == 96) continue;  // != 95, 96 _'

                char c = Convert.ToChar(randomNumber);

                if (requireDigit)
                    if (char.IsDigit(c))
                        requireDigit = false;

                if (requireLowercase)
                    if (char.IsLower(c))
                        requireLowercase = false;

                if (requireUppercase)
                    if (char.IsUpper(c))
                        requireUppercase = false;

                randomPassword += c;
            }

            if (requireDigit)
                randomPassword += Convert.ToChar(random.Next(48, 58));  // 0-9

            if (requireLowercase)
                randomPassword += Convert.ToChar(random.Next(97, 123));  // a-z

            if (requireLowercase)
                randomPassword += Convert.ToChar(random.Next(65, 91));  // A-Z


            return randomPassword;
        }



        protected void Save_Click(object sender, EventArgs e)
        {
            //Add Medic data to database
            AddMedics medics = new AddMedics();

            bool active=true;
            if (CheckYes.Checked == true)
            {
                 active = true;
            }
            if (CheckNo.Checked == true)
            {
               active = false;
            }

            if (Request.QueryString["MedicID"] != "0")
            {
                bool editSuccess = EditMedic(MedicName.Text, MedicPhoneNumber.Text, MedicEmail.Text, "ident",active);
                if (editSuccess)
                {
                    // Reload the page.

                    Response.Redirect("Medics" + "?MedicEditAction=sucess");
                }
                else
                {
                    Response.Redirect("Medics" + "?MedicEditAction=fail");
                }
            }
            else
            {
                bool addSucess = medics.AddMedic(MedicName.Text, MedicPhoneNumber.Text, MedicEmail.Text, "medic", active);
                if (addSucess)
                {
                    Models.ApplicationDbContext context = new ApplicationDbContext();
                    IdentityResult IdRoleResult;
                    IdentityResult IdUserResult;

                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleMgr = new RoleManager<IdentityRole>(roleStore);


                    if (!roleMgr.RoleExists("Medic"))
                    {
                        IdRoleResult = roleMgr.Create(new IdentityRole { Name = "Medic" });
                    }

                    var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var appUser = new ApplicationUser()
                    {
                        UserName = MedicEmail.Text,
                        Email = MedicEmail.Text
                    };
                    
                    // String password = "Pass123";
                    string password = GeneratePassword();

                    IdUserResult = userMgr.Create(appUser, password);

                    if (!userMgr.IsInRole(userMgr.FindByEmail(MedicEmail.Text).Id, "Medic"))
                    {
                        IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(MedicEmail.Text).Id, "Medic");
                    }

                    /*
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    manager.Create(appUser,password);
                    manager.SendEmail(,"Registo na aplicação SafeTravel","A sua palavra-passe é : "+ password);
                   */

                    MailMessage mail = new MailMessage("SafeTravel@outlook.pt",MedicEmail.Text);
                    mail.Subject = "Registo na aplicação SafeTravel";
                    mail.Body = "A sua palavra-passe é : " + password;

                    SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com",587);
                    smtp.Credentials= new System.Net.NetworkCredential()
                    {
                        UserName = "SafeTravel@outlook.pt",
                        Password = "5080Admin"
                    };
                    smtp.EnableSsl = true;
                    smtp.Send(mail);


                    Response.Redirect("Medics");
                }

            }






        }
    }
}