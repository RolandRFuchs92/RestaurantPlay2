using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
		public class Booking
		{
			public int BookingId { get; set; }
			public string BookingMobileNumber { get; set; }
			public string BookingEmailAddress { get; set; }
			public int BookingHeadCount { get; set; }
			public string BookingComments { get; set; }
			public int BookingOccassion { get; set; }
			public bool IsConfirmed { get; set; }
			public bool IsCanceled { get; set; }
		}
}
