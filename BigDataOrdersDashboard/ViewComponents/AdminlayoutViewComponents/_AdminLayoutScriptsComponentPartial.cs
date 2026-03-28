using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashboard.ViewComponents.AdminlayoutViewComponents
{
    public class _AdminLayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
