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
        private readonly IVotesService voteServices;

        public VotesController(
            UserManager<ApplicationUser> userManager,
            IVotesService voteServices)
        {
            this.userManager = userManager;
            this.voteServices = voteServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VoteResultsModel>> Post(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);

            var result = new VoteResultsModel();

            if (input.DiscussionId != default)
            {
                await this.voteServices.VoteDiscussionAsync(userId, input.DiscussionId, input.VoteType);
                var votesDto = this.voteServices.GetDiscussionVotes(input.DiscussionId);

                result.Likes = votesDto.Likes;
                result.Dislikes = votesDto.Dislikes;
            }
            else if (input.CommentId != default)
            {
                await this.voteServices.VoteCommensAsync(userId, input.CommentId, input.VoteType);
                var votesDto = this.voteServices.GetCommentVotes(input.CommentId);

                result.Likes = votesDto.Likes;
                result.Dislikes = votesDto.Dislikes;
            }

            return result;
        }
    }
}
