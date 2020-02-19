using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeTravel.Models;

namespace SafeTravel.Logic
{
    public class AddPharmacies
    {
        public bool AddPharmacy(String name,String address,String phone_number, String email, String ident, bool is_active )
        {
            var myPharmacy = new Models.Pharmacy();
            myPharmacy.p_name = name;
            myPharmacy.adress = address;
            myPharmacy.phone_number = Convert.ToInt32(phone_number);
            myPharmacy.email = email;
            myPharmacy.ident = ident;
            myPharmacy.is_active = is_active;

            using (data _db = new data())
            {
                //Add pharmacy to database
                _db.Pharmacy.Add(myPharmacy);
                _db.SaveChanges();
            }

            //Sucess
            return true;
        }
    }
}