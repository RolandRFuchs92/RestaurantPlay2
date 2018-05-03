using System.Web.Mvc;

namespace RestaurantPlay2.Areas.MenuCreator
{
    public class MenuCreatorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MenuCreator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MenuCreator_default",
                "MenuCreator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}