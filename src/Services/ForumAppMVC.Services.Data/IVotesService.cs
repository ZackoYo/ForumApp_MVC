using System.Threading.Tasks;

namespace ForumAppMVC.Services.Data
{
    public interface IVotesService
    {
        int GetVotes(int postId);

        /// <summary>
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <param name="isUpVote">If true - up vote, else - down vote.</param>
        /// <returns></returns>
        Task VoteAsync(int postId, string userId, bool isUpVote);
    }
}
