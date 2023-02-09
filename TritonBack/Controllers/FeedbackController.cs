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

        [HttpPost("/feedbackPost")]
        public async Task<ActionResult<FeedbackModel>> FeedbackPost(FeedbackModel feedback)
        {
            var response = await feedbackPost.PostFeedback(feedback);

            
            return Ok(response);
        }

        [HttpGet("/feedbackGet")]
        public async Task<ActionResult<List<FeedbackModel>>> FeedbackGet()
        {
            var response = await feedbackPost.GetFeedback();

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
