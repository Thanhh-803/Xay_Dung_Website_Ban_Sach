using Game.Model.Entities;
using Game.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UsersController : Controller
    {
        
        private UsersRepository usersRepo;
        public UsersController()
        {
            usersRepo = new UsersRepository();
        }
        public IActionResult Index()
        {
            var users = usersRepo.GetAll().ToList();
            return View(users);
        }
        
    }
}
