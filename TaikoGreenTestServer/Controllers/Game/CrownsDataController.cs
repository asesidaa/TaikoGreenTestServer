using Microsoft.Extensions.Options;

namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/crownsdata.php")]
[ApiController]
public class CrownsDataController : BaseController<CrownsDataController>
{

    [HttpPost]
    [Produces("application/protobuf")]
    public async Task<IActionResult> CrownsData([FromBody] CrownsDataRequest request)
    {
        Logger.LogInformation("CrownsData request : {Request}", request.Stringify());

        var response = new CrownsDataResponse
        {
            Result = 1,
        };

        return Ok(response);
    }
}