using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Controllers
{
    public class PageController : Controller
    {
        private PageRepository pageRepo;
        
        public PageController()
        {
            pageRepo= new PageRepository();
        }
        public IActionResult Index()
        {
            var page = pageRepo.GetAll().OrderByDescending(p => p.Id).ToList();
            return View(page);
        }
    }
}
