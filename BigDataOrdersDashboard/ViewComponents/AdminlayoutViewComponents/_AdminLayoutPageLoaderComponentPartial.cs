using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashboard.ViewComponents.AdminlayoutViewComponents
{
    public class _AdminLayoutPageLoaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
