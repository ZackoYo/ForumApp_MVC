using ForumAppMVC.Services.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ForumAppMVC.Data.Models;
using ForumAppMVC.Web.ViewModels.Votes;
using Microsoft.AspNetCore.Identity;

namespace ForumAppMVC.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService _votesService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            _votesService = votesService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel input)
        {
            var userId = _userManager.GetUserId(this.User);
            await _votesService.VoteAsync(input.PostId, userId, input.IsUpVote);
            var votes = _votesService.GetVotes(input.PostId);
            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
