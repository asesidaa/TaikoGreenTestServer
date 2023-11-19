namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/playresult.php")]
[ApiController]
public class PlayResultController : BaseController<PlayResultController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public async Task<IActionResult> UploadPlayResult([FromBody] PlayResultRequest request)
    {
        Logger.LogInformation("PlayResult request : {Request}", request.Stringify());
        var response = new PlayResultResponse
        {
            Result = 1
        };
        return Ok(response);
    }
}