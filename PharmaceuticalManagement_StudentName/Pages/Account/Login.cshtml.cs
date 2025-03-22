using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaceuticalManagement.Services;

namespace PharmaceuticalManagement_StudentName.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IStoreAccountService _storeAccountService;

        public LoginModel(IStoreAccountService storeAccountService)
        {
            _storeAccountService = storeAccountService;
        }
        [BindProperty]
        public string Email { get; set; } = default!;

        [BindProperty]
        public string Password { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var userAccount = await _storeAccountService.GetUserAccount(Email, Password);

                if (userAccount != null)
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, userAccount.EmailAddress),
                            new Claim(ClaimTypes.Role, userAccount.Role.ToString())
                        };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    Response.Cookies.Append("EmailAddress", userAccount.EmailAddress);
                    Response.Cookies.Append("Role", userAccount.Role.ToString());
                    Console.WriteLine(userAccount.Role.ToString());
                    return RedirectToPage("/MedicineInformations/Index");
                }
            }
            catch (Exception ex)
            {

            }

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ModelState.AddModelError("", "Login failure");
            return Page();
        }
    }
}
