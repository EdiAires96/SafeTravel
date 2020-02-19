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
using System.Text;
using System.Net.Mail;

namespace SafeTravel.Admin
{
    public partial class AddPharmacy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["PharmacyID"] != null)
                {
                    int id = Int32.Parse(Request.QueryString["PharmacyID"]);
                    if (id > 0)
                    {
                        var _db = new data();
                        var query = _db.Pharmacy;
                        var r = query.Where(p => p.pharmacy_id == id).FirstOrDefault();
                        PharmacyName.Text = r.p_name;
                        PharmacyAddress.Text = r.adress;
                        PharmacyPhoneNumber.Text = Convert.ToString(r.phone_number);
                        PharmacyEmail.Text = r.email;


                    }
                }
            }
        }
        public bool EditPharmacy(String name, String address, String phone_number, String email, String ident, bool active)
        {


            int id = Int32.Parse(Request.QueryString["PharmacyID"]);
            using (data _db = new data())
            {
                
                var r = _db.Pharmacy.First(i => i.pharmacy_id == id);
                r.p_name = name;
                r.adress = address;
                r.phone_number = Convert.ToInt32(phone_number);
                r.email = email;
                r.ident = ident;
                r.is_active = active;

                _db.SaveChanges();
            }
            // Success.
            return true;
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pharmacies");
        }
        /*
        public string CreatePassword()
        {
            int length = 6;
            int flagLow = 0;
            int flagBig = 0;
            int flagNumber = 0;

            String low = "abcdefghijklmnopqrstuvwxyz";
            String big = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String number = "1234567890";

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
            //Add Pharmacy data to DB
            AddPharmacies pharmacies = new AddPharmacies();

            bool active = true;
            if (CheckYes.Checked == true)
            {
                active = true;
            }
            if (CheckNo.Checked == true)
            {
                active = false;
            }

            if (Request.QueryString["PharmacyID"] != null)
            {
                bool editSuccess = EditPharmacy(PharmacyName.Text, PharmacyAddress.Text, PharmacyPhoneNumber.Text, PharmacyEmail.Text, "pharmacy", active);
                if (editSuccess)
                {
                    // Reload the page.

                    Response.Redirect("Pharmacies" + "?PharmacyEditAction=sucess");
                }
                else
                {
                    Response.Redirect("Pharmacies" + "?PharmacyEditAction=fail");
                }
            }
            else
            {

                bool addSucess = pharmacies.AddPharmacy(PharmacyName.Text, PharmacyAddress.Text, PharmacyPhoneNumber.Text, PharmacyEmail.Text, "pharmacy", active);
                if (addSucess)
                {
                    Models.ApplicationDbContext context = new ApplicationDbContext();
                    IdentityResult IdRoleResult;
                    IdentityResult IdUserResult;

                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleMgr = new RoleManager<IdentityRole>(roleStore);


                    if (!roleMgr.RoleExists("Pharmacy"))
                    {
                        IdRoleResult = roleMgr.Create(new IdentityRole { Name = "Pharmacy" });
                    }
                    
                    var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var appUser = new ApplicationUser
                    {
                        UserName = PharmacyEmail.Text,
                        Email = PharmacyEmail.Text
                    };

                    //string password = CreatePassword();
                    string password = GeneratePassword();
                    IdUserResult = userMgr.Create(appUser, password);
                    //IdUserResult = userMgr.Create(appUser, "Pa$$word1");

                    if (!userMgr.IsInRole(userMgr.FindByEmail(PharmacyEmail.Text).Id, "Pharmacy"))
                    {
                        IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(PharmacyEmail.Text).Id, "Pharmacy");
                    }

                    MailMessage mail = new MailMessage("SafeTravel@outlook.pt", PharmacyEmail.Text);
                    mail.Subject = "Registo na aplicação SafeTravel";
                    mail.Body = "A sua palavra-passe é : " + password;

                    SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = "SafeTravel@outlook.pt",
                        Password = "5080Admin"
                    };
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    Response.Redirect("Pharmacies");
                }
            }



            
        }
    }
}