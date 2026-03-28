using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashboard.ViewComponents.AdminlayoutViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
