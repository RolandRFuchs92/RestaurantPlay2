using System.Web.Mvc;

namespace RestaurantPlay2.Areas.ImageCarousel
{
    public class ImageCarouselAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ImageCarousel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ImageCarousel_default",
                "ImageCarousel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}