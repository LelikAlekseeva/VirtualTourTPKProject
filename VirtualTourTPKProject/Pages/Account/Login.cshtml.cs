using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace VirtualTourTPKProject.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        [Required(ErrorMessage = "Укажите электронную почту")]
        [EmailAddress(ErrorMessage = "Введите корректную электронную почту")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        public bool RememberMe { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _signInManager.PasswordSignInAsync(
                Email,
                Password,
                RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded)
                return RedirectToPage("/Admin/Index");

            ModelState.AddModelError(
                string.Empty,
                "Не удалось войти. Проверьте электронную почту и пароль.");

            return Page();
        }
    }
}
