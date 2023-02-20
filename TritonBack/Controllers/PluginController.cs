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
        private readonly IWebHostEnvironment _environment;

        public PluginController(IPlugin plugin, IWebHostEnvironment environment)
        {
            this.plugin = plugin;
            _environment = environment;
        }




        [HttpGet("/getPlugin")]
        public async Task<ActionResult<List<PluginModel>>> GetPlugin()
        {


            var response = await plugin.GetPlugin();

            return response;
        }

        [HttpGet("/getPlugin/{id}")]


        public async Task<ActionResult<PluginModel>> GetPluginById(int id)
        {
            var response = await plugin.GetPluginById(id);
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


        public async Task<ActionResult<PluginModel>> CreatePlugin([FromForm]PluginModelDtO pluginModel)
        {


            var response = await plugin.CreatePlugin(pluginModel);

            //var img = await PostImg(pluginModel.ImgFile);


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
            await plugin.DeletePlugin(id);

            return Ok();
        }


    }
}
