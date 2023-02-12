using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoisingController : ControllerBase
    {

        private readonly IChoising choising;

        public ChoisingController(IChoising choising)
        {
            this.choising = choising;
        }

        [HttpGet("/getChoising")]

        public async Task<ActionResult<List<ChoisingModel>>> GetChoisingModel()
        {
            var response = await choising.GetChoisingModel();
            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("/getChoising/{id}")]

        public async Task<ActionResult<ChoisingModel>> GetChoisingById(int id)
        {
            var response = await choising.GetChoisingModelById(id);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost("/createChoising")]

        public async Task<ActionResult<ChoisingModel>> CreateChoisingModel(ChoisingModel choisingModel)
        {
            var response = await choising.CreateChoisingModel(choisingModel);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPut("/updateChoising/{id}")]

        public async Task<ActionResult<ChoisingModel>> UpdateChoisingModel(int id, ChoisingModel choisingModel)
        {
            var response = await choising.UpdateChoisingModel(id, choisingModel);

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
