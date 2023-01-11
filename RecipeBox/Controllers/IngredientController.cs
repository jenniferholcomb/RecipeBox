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
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public IngredientsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db) //connects UserManager to class
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      // Recipe thisRecipe = _db.Recipes
      //         .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View();
    }

    [HttpPost]
    public ActionResult Create(Ingredient ingredient, int RecipeId)
    {
      // ViewBag.RecipeId // ?
      _db.Ingredients.Add(ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


    // [HttpPost]
    // public async Task<ActionResult> Create(Item item, int CategoryId)
    // {
    //   if (!ModelState.IsValid)
    //   {
    //     ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name"); // would not need this here because we are going straight into adding ingredients
    //     return View(item);
    //   }
    //   else
    //   {
    //     string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //     ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    //     item.User = currentUser;
    //     _db.Items.Add(item);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    //   }
    // }

    // public ActionResult AddToRecipe(int id)
    // {
    //   Recipe thisRecipe = _db.Recipes
    //       .Include(recipe => recipe.JoinIngredients)
    //       .ThenInclude(join => join.Ingredient)
    //       .FirstOrDefault(recipe => recipe.RecipeId == id);
    //   return View(thisRecipe);
    // }
    
    public ActionResult Edit(int id)
    {
      Ingredient thisIngredient = _db.Ingredients
          .FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost]
    public ActionResult Edit(Ingredient ingredient)
    {
      _db.Ingredients.Update(ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id );
      _db.Ingredients.Remove(thisIngredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId)
    // {
    //   IngredientRecipe joinEntry = _db.IngredientRecipes.FirstOrDefault(entry => entry.IngredientRecipeId == joinId);
    //   _db.IngredientRecipes.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}