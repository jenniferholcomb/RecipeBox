using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Tag
  {
    public int TagId { get; set; }
    public string Category { get; set; }
    public List<RecipeTag> JoinEntities { get; }
  }
}