using DatabaseThucHanh.Models;
using DatabaseThucHanh.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseThucHanh.Controllers
{
    public class CartController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();


        // Access the database (uncomment and set up based on your database context)
        // private readonly ApplicationDbContext db = new ApplicationDbContext();
        // private MyStoreEntities db = new MyStoreEntities();

        // Helper function to retrieve CartService with session
        private CartService GetCartService()
            {
                return new CartService(Session);
            }

            // Display the shopping cart view
            public ActionResult Index()
            {
                var cart = GetCartService().GetCart();
                return View(cart);
            }

            // Add product to the cart
            public ActionResult AddToCart(int id, int quantity = 1)
            {
                var product = db.Products.Find(id);
                if (product != null)
                {
                    var cartService = GetCartService();
                    cartService.GetCart().AddItem(
                        product.ProductID,
                        product.ProductImage,
                        product.ProductName,
                        product.ProductPrice,
                        quantity,
                        product.Category.CategoryName
                    );
                }
                return RedirectToAction("Index");
            }

            // Remove product from the cart by product ID
            public ActionResult RemoveFromCart(int id)
            {
                var cartService = GetCartService();
                cartService.GetCart().RemoveItem(id);
                return RedirectToAction("Index");
            }

            // Clear the entire cart
            public ActionResult ClearCart()
            {
                GetCartService().ClearCart();
                return RedirectToAction("Index");
            }

            // Update the quantity of a specific product
            [HttpPost]
            public ActionResult UpdateQuantity(int id, int quantity)
            {
                var cartService = GetCartService();
                cartService.GetCart().UpdateQuantity(id, quantity);
                return RedirectToAction("Index");
            }
        }
    }