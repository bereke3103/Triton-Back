using Microsoft.AspNetCore.Mvc;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaqController : ControllerBase
    {
        private readonly IQuestionAnswer questionAnswer;

        public FaqController(IQuestionAnswer questionAnswer)
        {
            this.questionAnswer = questionAnswer;
        }

        [HttpGet("/getFaq")]

        public async Task<ActionResult<List<QuestionsModel>>> GetQuestionModel()
        {
            var response = await questionAnswer.GetQuestionModel();
            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("/getFaq/{id}")]

        public async Task<ActionResult<QuestionsModel>> GetQuestionModelById(int id)
        {
            var response = await questionAnswer.GetQuestionModelById(id);

            return Ok(response);
        }


        [HttpPost("/createFaq")]

        public async Task<ActionResult<QuestionsModel>> CreateQuestionModel(QuestionsModel questionsModel)
        {
            var response = await questionAnswer.CreateQuestionModel(questionsModel);

            if (response == null)
            {
                return BadRequest();
            } else
            {
                return Ok(response);
            }
        }

        [HttpPut("/updateFaq/{id}")]

        public async Task<ActionResult<QuestionsModel>> UpdateQuestionModel(int id, QuestionsModel questionsModel)
        {
            var response = await questionAnswer.UpdateQuestionModel(id, questionsModel);

            if (response == null)
            {
                return BadRequest();
            } else
            {
                return Ok(response);
            }
        }


        [HttpDelete("/deleteFaq/{id}")]

        public async Task<ActionResult> DeleteQuestionModel(int id) 
        {
            var response = questionAnswer.DeleteQuestionModel(id);

            if (response == null)
            {
                return Ok();
            }
            else
            {
               return BadRequest();
            }
        }
 
    }
}