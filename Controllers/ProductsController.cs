using Microsoft.AspNetCore.Mvc;
using firstASP.Data;
using firstASP.Models; 
namespace firstASP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // public IActionResult Index()
        // {
        //     var products = _db.Products.ToList();  // works just like _db.Users!
        //     return View(products);
        // }
        // Show the empty "Add" form
        public IActionResult Create()
        {
            return View();
        }
        // Save the new product when the form is submitted
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _db.Products.Add(product);   // put the new product into the table
            _db.SaveChanges();           // actually save it to the database
            return RedirectToAction("Index");   // go back to the list
        }
                // show the edit form
        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
        }

        // save the edit
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // delete the product
        public IActionResult Delete( int id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Index(string searchString)
{
    var products = _db.Products.AsQueryable();

    if (!string.IsNullOrEmpty(searchString))
    {
        products = products.Where(p => p.Name.Contains(searchString));
    }

    ViewData["searchString"] = searchString; // keep what they typed
    return View(products.ToList());
}
    }
}