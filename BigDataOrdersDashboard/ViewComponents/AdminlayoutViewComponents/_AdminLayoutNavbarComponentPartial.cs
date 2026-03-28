using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashboard.ViewComponents.AdminlayoutViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
