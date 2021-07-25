namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.VotesModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVoteService voteServices;

        public VotesController(
            UserManager<ApplicationUser> userManager,
            IVoteService voteServices)
        {
            this.userManager = userManager;
            this.voteServices = voteServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VoteResultsModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.voteServices.VoteAsync(userId, input.DiscussionId,  input.VoteType);
            var votesDto = this.voteServices.GetVoteResults(input.DiscussionId);

            return new VoteResultsModel
            {
                Likes = votesDto.Likes,
                Dislikes = votesDto.Dislikes,
            };
        }
    }
}
