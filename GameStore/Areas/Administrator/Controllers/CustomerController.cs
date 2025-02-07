using Microsoft.AspNetCore.Mvc;
using Game.Model.Entities;
using Game.Repository;

namespace GameStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CustomerController : Controller
    {
        private CustomerRepository customerRepo;
        public CustomerController()
        {
            customerRepo = new CustomerRepository();
        }
        public IActionResult Index()
        {
            var khachHang = customerRepo.GetAll().ToList();
            return View(khachHang);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepo.Insert(customer);
                    return Redirect("/Administrator/Customer/Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Edit(int id) /*Tiếp nhận tham số Id*/
        {
            var customer = customerRepo.GetById(id);
            if (customer == null)
            {
                return NotFound();

            }
            return View(customer);// Truyen sang productCategory
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepo.Update(customer);/*Sử dụng model để tiếp nhận*/
                    return Redirect("/Administrator/Customer/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(customer);
        }
        public IActionResult Delete(int id)
        {
            customerRepo.Delete(id);
            return Redirect("/Administrator/Customer/Index");
        }

    }
}
