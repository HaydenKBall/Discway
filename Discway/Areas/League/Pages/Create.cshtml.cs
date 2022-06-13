using Discway.Data.Context;
using Discway.Data.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Discway.Areas.League.Pages;

[Authorize]
public class CreateModel : PageModel
{
    private readonly DiscwayContext _discwayContext;
    private readonly UserManager<User> _userManager;

    public CreateModel(DiscwayContext context, UserManager<User> userManager)
    {
        _discwayContext = context;
        _userManager = userManager;
    }

    [BindProperty]
    public Data.Dto.League League { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        League = new Data.Dto.League();

        var currentUser = await _userManager.GetUserAsync(User);

        League.AdminId = currentUser.Id;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            _discwayContext.League.Add(League);
            await _discwayContext.SaveChangesAsync();

            return Redirect("./Index");
        }

        return Page();
    }
}