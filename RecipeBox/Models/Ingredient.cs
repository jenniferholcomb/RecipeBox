using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public string Measurement { get; set; }
    public List<IngredientRecipe> JoinIngredients { get; set; }
  }
}