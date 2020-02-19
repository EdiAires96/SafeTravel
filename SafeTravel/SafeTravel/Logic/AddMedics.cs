using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeTravel.Models;

namespace SafeTravel.Logic
{
    public class AddMedics
    {
        public bool AddMedic(String name, String phone_number,String email, String ident, bool is_active )
        {
            var myMedic = new Models.Medic();
            myMedic.m_mame = name;
            myMedic.phone_number = Convert.ToInt32(phone_number);   
            myMedic.m_email = email;
            myMedic.ident = ident;
            myMedic.is_active = is_active;

            using( data _db = new data())
            {
                //Add medic to database
                _db.Medic.Add(myMedic);
                _db.SaveChanges();
  
            }
            

            //Sucess
            return true;
        }

    }
}