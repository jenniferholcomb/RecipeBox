using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Instructions { get; set; }
    public string Ingredients { get; set; }
    [Range(1, 5, ErrorMessage = "Must be a rating between 1 .. 5")]
    public int Rating { get; set; } //required
    public ApplicationUser User { get; set; }
    public List<RecipeTag> JoinEntities { get; }
    public List<IngredientRecipe> JoinIngredients { get; set; }
  }
}