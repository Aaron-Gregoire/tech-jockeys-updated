using Microsoft.AspNetCore.Mvc;
using TechJockeys.Data;
using TechJockeys.Models;

namespace TechJockeys.Controllers
{
    public class StoreController : Controller
    {
        // shared db conn
        private readonly ApplicationDbContext _context;

        // constructor w/db conn dependency
        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // fetch category data from db
            var categories = _context.Category.OrderBy(c => c.Name).ToList();

            // load view and pass the category list
            return View(categories);
        }

        //this method returns a page with the products belonging to that categoty
        public IActionResult ByCategory(int id)
        {

            // error handle if id missing => redirect to Store index so user can choose a category
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            //retrieve list of products from the db
            var products = _context.Product
                                   .Where(p => p.CategoryId == id)
                                   .OrderBy(p => p.Name)
                                   .ToList();

            //retreve category name to show on the page in the title
            var category = _context.Category.Find(id);
            //redirect to index if catrgory not found
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            // use id param to find category
            // use ViewData dictionary to show selected category name in heading
            //since category is nullable use question mark will make this value empty on runtime if null
            ViewData["Category"] = $"Showing all {category?.Name}";
     
            return View(products);
        }
         
        //post method to add product to cart
        [HttpPost]
        public IActionResult AddToCart( [FromForm] int ProductId, [FromForm] int Quantity)
        {
            //TODO: get userId or generate temp id for not logged in user

            //get product price

            //create new cart method 

            //redirect to cart view to show the users cart
            return RedirectToAction("Cart");
        }
    }
}
