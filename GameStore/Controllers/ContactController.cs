using Game.Model.Entities;
using Game.Repository;
using GameStore.Areas.Administrator.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace GameStore.Controllers
{
    public class ContactController : Controller
    {
        private CustomerRepository customerRepo;
        public ContactController()
        {
            customerRepo = new CustomerRepository();
        }

        
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("LienHe")]
        public IActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        [Route("LienHe")]
        public IActionResult Lienhe(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Email) )
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
                return View();
            }
            customerRepo.Insert(customer);
            return RedirectToAction("Success");
            //if (ModelState.IsValid)
            //{
            //    // Thực hiện xử lý gửi liên hệ, ví dụ: gửi email, lưu vào cơ sở dữ liệu, v.v.
            //    // ...

            //    // Chuyển hướng về trang thành công hoặc hiển thị thông báo thành công
            //    customerRepo.Insert(customer);
            //    return RedirectToAction("Success");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
            //}

            return View("Index", customer);
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
