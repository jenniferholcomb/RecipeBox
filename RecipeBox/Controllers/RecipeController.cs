using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public RecipesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db) //connects UserManager to class
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Recipe> userRecipes = _db.Recipes
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToList();
      return View(userRecipes);
    }

    [Authorize]
    public ActionResult Edit()
    {
      return View();
    }

  }
}