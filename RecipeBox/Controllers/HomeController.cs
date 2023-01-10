using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{
  public class HomeController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Recipe[] recipes = _db.Recipes.ToArray();
      Tag[] tags = _db.Tags.ToArray();
      Dictionary<string,object[]> model = new Dictionary<string,object[]>();
      model.Add("recipes", recipes);
      model.Add("tags", tags);
      return View(model);
    }
  }
}