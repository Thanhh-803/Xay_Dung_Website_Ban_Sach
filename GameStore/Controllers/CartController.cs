using Game.Repository;
using GameStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Game.Repository;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using Microsoft.CodeAnalysis;

namespace GameStore.Controllers
{
    public class CartController : Controller
    {
        private SanPhamRepository sanPhamRepo;
        public CartController()
        {
            sanPhamRepo = new SanPhamRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            
            List<CartItem> cart;
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)
            {
                cart = new List<CartItem>();
                cart.Add(new CartItem { DonHangSanPham = sanPhamRepo.GetById(id), SoLuong = 1 });
            }
            else //trong giỏ hàng đã có sản phẩm rồi
            {
                cart = (List<CartItem>)HttpContext.Session.Get<List<CartItem>>("Cart");
                CartItem cartItem = cart.SingleOrDefault(x => x.DonHangSanPham.Id == id);
                if (cartItem != null) //đã có sản phẩm này trong giỏ hàng rồi
                {
                    cartItem.SoLuong++;
                }
                else //chưa có sản phẩm này trogn giỏ hàng.
                {
                    cart.Add(new CartItem { DonHangSanPham = sanPhamRepo.GetById(id), SoLuong = 1 });
                }
            }
            //Cập nhật giỏ hàng
            HttpContext.Session.Set<List<CartItem>>("Cart", cart);
            //Trả về số lượng hàng trong giỏ
            return Json(new { total = cart.Sum(x => x.SoLuong) });
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult EndCheckout()
        {
            return View();
        }
    }
}
