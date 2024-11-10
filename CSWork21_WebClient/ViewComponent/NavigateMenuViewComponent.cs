using Microsoft.AspNetCore.Mvc;

namespace CSWork21_WebClient.Component
{
    public class NavigateMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
