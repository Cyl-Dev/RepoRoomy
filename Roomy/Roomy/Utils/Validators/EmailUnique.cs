using Roomy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Utils.Validators
{
    public class EmailUnique : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
           
            using (RoomyDbContext db = new RoomyDbContext())
            {
                //var req = db.Users.Where(x => x.Mail == (string)value).SingleOrDefault();
                return !db.Users.Any(x => x.Mail == value.ToString() );
            }
                     
        }

    }
}

/*
 var dbProperties = db.getType().GetProperties();
 foreach(var item in dbProperties)
 }
    if (item.PropertyType.FullName.Contains(validationContext.ObjectType.Name)
    {
    
    }

 {

     
     */