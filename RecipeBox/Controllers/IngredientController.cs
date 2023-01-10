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
  [Authorize]
  public class IngredientController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public IngredientController(UserManager<ApplicationUser> userManager, RecipeBoxContext db) //connects UserManager to class
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult AddIngredient(int id)
    {
      Recipe thisRecipe = _db.Recipes
          .Include(recipe => recipe.JoinIngredients)
          .ThenInclude(join => join.Ingredient)
          .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

  }
}