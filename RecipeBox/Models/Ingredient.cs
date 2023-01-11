using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string Measurement { get; set; }
    public Recipe Recipe { get; set; }
  }
}