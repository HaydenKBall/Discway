using Discway.Data.Context;
using Discway.Data.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Discway.Areas.League.Pages;

public class IndexModel : PageModel
{
    private readonly DiscwayContext _discwayContext;
    private readonly UserManager<User> _userManager;

    public IndexModel(DiscwayContext discwayContext, UserManager<User> userManager)
    {
        _discwayContext = discwayContext;
        _userManager = userManager;
    }

    [BindProperty]
    public List<Data.Dto.League> Leagues { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var currentUser = await _userManager.GetUserAsync(User);

        Leagues = _discwayContext.League.Where(x => x.AdminId == currentUser.Id).ToList();

        return Page();
    }
}

//return a list of leagues from the currently logged in user
// access to database
// access to current user
// Hints: ||
// Demerits: |