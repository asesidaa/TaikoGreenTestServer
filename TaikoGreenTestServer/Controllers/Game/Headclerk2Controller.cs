namespace TaikoGreenTestServer.Controllers.Game;

[ApiController]
[Route("/v11r01/chassis/headclerk2.php")]
public class Headclerk2Controller : BaseController<Headclerk2Controller>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult Headclerk2([FromBody] HeadClerk2Request request)
    {
        Logger.LogInformation("Headclerk2 request: {Request}", request.Stringify());
		
        var response = new HeadClerk2Response
        {
            Result = 1
        };

        return Ok(response);
    }
}