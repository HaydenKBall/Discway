using Discway.Data.Context;
using Discway.Data.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Discway.Areas.League.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly DiscwayContext _discwayContext;
        private readonly UserManager<User> _userManager;

        public DeleteModel(DiscwayContext discwayContext, UserManager<User> userManager)
        {
            _discwayContext = discwayContext;
            _userManager = userManager;
        }

        public Data.Dto.League League { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid leagueId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            // League/Delete?leagueId=asds2-asdasd-aaassdd-asd
            League = _discwayContext.League.SingleOrDefault(x => x.Id == leagueId);

            if (League != null && League.AdminId == currentUser.Id)
            {
                return Page();
            }

            return Redirect("./Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            League = League = _discwayContext.League.SingleOrDefault(x => x.Id == League.Id);

            _discwayContext.Remove(League);
            await _discwayContext.SaveChangesAsync();

            return Page();
        }
    }
}