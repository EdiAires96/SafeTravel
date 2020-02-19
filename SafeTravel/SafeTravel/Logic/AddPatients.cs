using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafeTravel.Models;

namespace SafeTravel.Logic
{
    public class AddPatients
    {
        public bool AddPatient(String name,String address, String date, String number_health, String phone_number, String email, String job, String naturality, String genre, String financial_number)
        {
            var myPatient = new Models.Patient();
            myPatient.p_name = name;
            myPatient.p_address = address;
            date = date + " 00:00";
            myPatient.date_of_birth = Convert.ToDateTime(date);
            myPatient.number_health = Convert.ToInt64(number_health);
            myPatient.phone_number = Convert.ToInt32(phone_number);
            myPatient.p_email = email;
            myPatient.job = job;
            myPatient.naturality = naturality;
            myPatient.genre = genre;
            myPatient.financial_number = Convert.ToInt64(financial_number);

            using (data _db = new data())
            {
                //Add patient to database
                _db.Patient.Add(myPatient);
                _db.SaveChanges();
            }

            //Sucess
            return true;
        }
    }
}