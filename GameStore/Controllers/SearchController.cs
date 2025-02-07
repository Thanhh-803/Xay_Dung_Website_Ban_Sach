using Game.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class SearchController : Controller
    {
        private SanPhamRepository sanPhamRepo;
        
        public SearchController()
        {
            sanPhamRepo= new SanPhamRepository();
        }
        public IActionResult Search(string keyword)
        {
            if (keyword == null)
            {
                return View("Index");
            }
            var productList = sanPhamRepo.GetAll().Where(p => p.Name.Contains(keyword)).ToList();
            return View(productList);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
