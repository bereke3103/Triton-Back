using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PluginController : ControllerBase
    {
        private readonly IPlugin plugin;

        public PluginController(IPlugin plugin)
        {
            this.plugin = plugin;
        }

        [HttpGet("/getPlugin")]

        public async Task<ActionResult<List<PluginModel>>> GetPlugin()
        {
            var response = await plugin.GetPlugin();
            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }


        [HttpPost("/createPlugin")]

        public async Task<ActionResult<PluginModel>> CreatePlugin(PluginModelDtO pluginModel)
        {
            var response = await plugin.CreatePlugin(pluginModel);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPut("/updatePlugin/{id}")]

        public async Task<ActionResult<PluginModel>> UpdatePlugin(int id, PluginModelDtO pluginModel)
        {
            var response = await plugin.UpdatePlugin(id, pluginModel);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpDelete("/deletePlugin/{id}")]
        public async Task<ActionResult> DeletePlugin(int id)
        {
            var response = plugin.DeletePlugin(id);

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
