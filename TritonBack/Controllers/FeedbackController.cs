using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedback feedbackPost;
        public FeedbackController(IFeedback feedback)
        {
            feedbackPost = feedback;
        }

        [HttpPost("/feedback")]
        public async Task<ActionResult<FeedbackModel>> FeedbackPost(FeedbackModel feedback)
        {
            var response = await feedbackPost.PostFeedback(feedback);

            
            return Ok(response);
        }
    }
}
