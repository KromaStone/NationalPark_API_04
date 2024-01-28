using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_API.Model.ViewModel
{
    public class TrailVM
    {
        public Trail Trail { get; set; }
        public IEnumerable<SelectListItem> nationalParkList { get; set; }
    }
}
