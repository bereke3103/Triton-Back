using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PluginInformationsController : ControllerBase
    {


        private readonly IPluginInformations pluginInformations;

        public PluginInformationsController(IPluginInformations pluginInformations)
        {
            this.pluginInformations = pluginInformations;
        }

        [HttpGet("/getPluginInformations")]

        public async Task<ActionResult<List<PluginInformationModel>>> GetPluginInformations()
        {
            var response = await pluginInformations.GetPluginInformations();
            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }


        [HttpPost("/createPluginInformations")]

        public async Task<ActionResult<PluginInformationModel>> CreatePluginInformations(PluginInformationsModelDto model)
        {
            var response = await pluginInformations.CreatePluginInformations(model);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPut("/updatePluginInformations/{id}")]

        public async Task<ActionResult<PluginInformationModel>> UpdatePluginInformations(int id, PluginInformationsModelDto model)
        {
            var response = await pluginInformations.UpdatePluginInformations(id, model);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }


        [HttpDelete("/deletePluginInformations/{id}")]

        public async Task<ActionResult> DeletePluginInformations(int id)
        {
            var response = pluginInformations.DeletePluginInformations(id);

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
