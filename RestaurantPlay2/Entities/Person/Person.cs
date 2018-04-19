using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Entities.Person
{
    public class COREPerson
    {
        [Key]
        public int COREPersonID { get; set; }
        public string COREPersonName { get; set; }
        public string COREPersonSurname { get; set; }
        public string COREPersonMobile { get; set; }
        public DateTime? COREPersonDateOfBirth { get; set; }
        public int? COREPersonAddressID { get; set; }
    }
}