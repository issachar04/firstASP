using Microsoft.AspNetCore.Mvc;
using firstASP.Models;

namespace firstASP.Controllers
{
    // Gets data from an OUTSIDE website (an API) and shows it on our page
    public class PostsController : Controller
    {
        private readonly HttpClient _http;

        // HttpClient is the tool that lets our site call other websites
        public PostsController(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            // The outside website's address (a free practice API, no key needed)
            var url = "https://jsonplaceholder.typicode.com/posts";

            try
            {
                // Ask the website for its data and turn the JSON into a list of Posts
                var posts = await _http.GetFromJsonAsync<List<Post>>(url) ?? new List<Post>();

                // Only show the first 10 so the page isn't too long
                return View(posts.Take(10).ToList());
            }
            catch (Exception)
            {
                // If the website is down or there's no internet, show a message instead of crashing
                ViewBag.Error = "Could not load data from the outside website. Try again later.";
                return View(new List<Post>());
            }
        }
    }
}
