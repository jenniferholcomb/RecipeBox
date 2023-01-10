using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RecipeBox.Models;
using RecipeBox.ViewModels;
using System.Threading.Tasks;

namespace RecipeBox.Controllers
{
  public class AccountController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager; //contains methods to create user
    private readonly SignInManager<ApplicationUser> _signInManager; //contains methods to let user signin

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RecipeBoxContext db) //dependency
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      ApplicationUser user = new ApplicationUser { };
      ViewBag.UserName = user.Name;
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)  //takes in user email and password as model
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        ApplicationUser user = new ApplicationUser { UserName = model.Email };  //create new applicationuser with email from form submission
        IdentityResult result = await _userManager.CreateAsync(user, model.Password); //creates user with provided password
        if (result.Succeeded) //checks to make sure password meets criteria
        {
          return RedirectToAction("Index");
        }
        else
        {
          foreach (IdentityError error in result.Errors)  //display error if password does not meet criteria
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded) 
        {
          return RedirectToAction("Index");
        }
        else
        {
          ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
          return View(model);
        }
      }
    }
  }
}