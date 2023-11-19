namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/selfbest.php")]
[ApiController]
public class SelfBestController : BaseController<SelfBestController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public async Task<IActionResult> SelfBest([FromBody] SelfBestRequest request)
    {
        Logger.LogInformation("SelfBest request : {Request}", request.Stringify());

        var response = new SelfBestResponse
        {
            Result = 1,
            Level = request.Level
        };
        
        return Ok(response);
    }
}