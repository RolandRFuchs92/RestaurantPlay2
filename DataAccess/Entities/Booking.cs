using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
		public class Booking
		{
				[Key]
				public int BookingId { get; set; }
				public string BookingName { get; set; }
				public string BookingMobileNumber { get; set; }
				public string BookingEmailAddress { get; set; }
				public int BookingHeadCount { get; set; }
				public string BookingComments { get; set; }
				public int BookingOccasionId { get; set; }
				public bool IsConfirmed { get; set; }
				public bool IsCanceled { get; set; }
				public DateTime CreatedOn { get; set; }
				public DateTime BookingDate { get; set; }
		}
}
