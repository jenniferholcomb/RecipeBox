using System.ComponentModel.DataAnnotations;

namespace RecipeBox.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    [Required]  //THIS IS REQUIRED FOR CUSTOM FIELD
    [Display(Name = "Name")]
    public string Name { get; set; }
  }
}