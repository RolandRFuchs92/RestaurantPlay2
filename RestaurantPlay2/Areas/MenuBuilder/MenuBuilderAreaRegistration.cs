using System.Web.Mvc;

namespace RestaurantPlay2.Areas.MenuBuilder
{
    public class MenuBuilderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MenuBuilder";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MenuBuilder_default",
                "MenuBuilder/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}