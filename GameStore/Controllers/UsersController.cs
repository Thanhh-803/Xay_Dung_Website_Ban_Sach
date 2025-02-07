using Game.Model.Entities;
using Game.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class UsersController : Controller
    {
        private UsersRepository UsersRepo;
        
        public UsersController()
        {
            UsersRepo = new UsersRepository();
        }

        [HttpGet]
        [Route("DangKy")]
        public IActionResult DangKy()
        {
            return View();
        }
        private bool IsEmailExists(string email)
        {
            // Kiểm tra email trong cơ sở dữ liệu và trả về true nếu đã tồn tại
            var Check = UsersRepo.GetAll().FirstOrDefault(u => u.Email == email );
            return Check != null;
        }
        private int TinhTuoi(DateTime ngaySinh)
        {
            DateTime ngayHienTai = DateTime.Now;
            int tuoi = ngayHienTai.Year - ngaySinh.Year;

            // Kiểm tra nếu ngày sinh sau ngày hiện tại, giảm tuổi đi 1
            if (ngaySinh.Month > ngayHienTai.Month || (ngaySinh.Month == ngayHienTai.Month && ngaySinh.Day > ngayHienTai.Day))
            {
                tuoi -= 1;
            }

            return tuoi;
        }
        [HttpPost]

        [Route("DangKy")]
        public IActionResult DangKy(Users users)
        {
            if (string.IsNullOrEmpty(users.Username) || string.IsNullOrEmpty(users.Id) || string.IsNullOrEmpty(users.Email) || string.IsNullOrEmpty(users.Email) || string.IsNullOrEmpty(users.Password))
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin đăng ký");
                return View();
            }
            if (IsEmailExists(users.Email))
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại. Đăng ký bằng Email khác");
                return View();
            }
            
            // Kiểm tra tuổi của người dùng
            int tuoi = TinhTuoi(users.Age);
            //if (tuoi == 0)
            //{
            //    ModelState.AddModelError("", "Vui lòng nhập tuổi.");
            //    return View();
            //}
            if (tuoi <=  18 )
            {
                ModelState.AddModelError("", "Bạn chưa đủ tuổi để đăng ký. Bạn phải trên 18 tuổi.");
                return View();
            }
            if (tuoi >= 99)
            {
                ModelState.AddModelError("", " Bạn đã quá số tuổi quy định.");
                return View();
            }

            UsersRepo.Insert(users);
            return RedirectToAction("DangNhap", "Users");
        }

        private bool IsEmailExists(object email)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        
        [Route("DangNhap")]
        public IActionResult DangNhap()
        {
            return View();
        }

        public bool IsValidCredentials(string username, string password)
        {
            var user = UsersRepo.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }
        [HttpPost]
        [Route("DangNhap")]
        public IActionResult DangNhap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin đăng nhập");
                return View();
            }

            if (!IsValidCredentials(username, password))
            {
                ModelState.AddModelError("", "Thông tin đăng nhập không chính xác");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
