using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    namespace firstASP.Controllers
    {
        [Authorize]   // <-- only logged-in users can open this page
        public class UsersController : Controller
        {
            private readonly UserManager<IdentityUser> _userManager;

            // this "borrows" Identity's user manager so we can read users
            public UsersController(UserManager<IdentityUser> userManager)
            {
                _userManager = userManager;
            }

            public IActionResult Index()
            {
                var users = _userManager.Users.ToList();  // get ALL users
                return View(users);                       // send them to the page
            }
        }
    }