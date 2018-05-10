using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class FoodPreference
    {
        [Key]
        public int FoodPreferenceId { get; set; }
        public string FoodPreferenceName { get; set; }

    }
}
