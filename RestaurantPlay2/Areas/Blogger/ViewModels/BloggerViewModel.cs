using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.Blogger.ViewModels
{
		public class BloggerViewModel
		{
				public int Id { get; set; } = 0;
				public string ImagePath { get; set; } = "/Content/Images/OpenSandwichImage.jpg";
				public string Title { get; set; } = "Post Title";

				public string Author { get; set; } = "Some Person";

				public DateTime WritenOn { get; set; } = DateTime.Today;
				public string Intro { get; set; } = "Introduction text some stuff about something or the other...this is just place holder text, better yet lets use Lorem Ipsum like so Lorem ipsum dolor sit amet, consectetur adipisicing elit.Ducimus, vero, obcaecati, aut, error quam sapiente nemo saepe quibusdam sit excepturi nam quia corporis eligendi eos magni recusandae laborum minus inventore?";
				public string Body { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.";

				public string Remarks { get; set; } ="Finishing remarks, some random stuff about what was said above and i think we could do better...";
			 public string ClosingCaption { get; set; } = "--Some quote or catch phrase";
		}
}