using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Web.UI2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.UI2.Controllers
{
    public class AdminController : Controller
    {
 
        public UserManager<ApplicationUser> myUserManager { get; set; }

        public AdminController() : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AdminController(  UserManager<ApplicationUser> userManager)
        {
            myUserManager = userManager;
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var Roles = myUserManager.Users.ToList<ApplicationUser>();
            return View(Roles);
        }

 
    }
}