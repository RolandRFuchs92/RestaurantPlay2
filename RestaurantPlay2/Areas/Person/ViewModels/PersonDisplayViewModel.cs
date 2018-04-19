using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantPlay2.Entities.Person;

namespace RestaurantPlay2.Areas.Person.ViewModels
{
    public class PersonDisplayViewModel
    {
        public string PersonName { get; set; }
        public List<COREPerson> Persons { get; set; }
    }
}