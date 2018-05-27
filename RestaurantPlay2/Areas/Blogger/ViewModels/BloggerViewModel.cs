using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.Blogger.ViewModels
{
		public class BloggerViewModel
		{
				public BloggerViewModel()
				{
						Id = 0;
						ImagePath = "/Content/Images/OpenSandwichImage.jpg";
						Title = "Post Title";
						Author = "Some Person";
						WritenOn = DateTime.Today;
						Intro = "Introduction text some stuff about something or the other...this is just place holder text, better yet lets use Lorem Ipsum like so Lorem ipsum dolor sit amet, consectetur adipisicing elit.Ducimus, vero, obcaecati, aut, error quam sapiente nemo saepe quibusdam sit excepturi nam quia corporis eligendi eos magni recusandae laborum minus inventore?";
						Body = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.";
						Remarks = "Finishing remarks, some random stuff about what was said above and i think we could do better...";
						ClosingCaption = "--Some quote or catch phrase";

				}
				public int Id { get; set; } = 0;
				public string ImagePath { get; set; }
				public string Title { get; set; }
				public string Author { get; set; }
				public DateTime WritenOn { get; set; }
				public string Intro { get; set; }
				public string Body { get; set; }
				public string Remarks { get; set; }
				public string ClosingCaption { get; set; }
		}
}