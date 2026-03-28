using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashboard.ViewComponents.AdminlayoutViewComponents
{
    public class _AdminLayourSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
