using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly VisyLrnContext _context;
        private readonly UserManager<Account> _userManager;
        public HomeController(VisyLrnContext context, UserManager<Account> userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("InitDB")]
        public async Task<bool> InitDb(){
            return await _context.InitializeDB(_userManager);
        }
    }
} 