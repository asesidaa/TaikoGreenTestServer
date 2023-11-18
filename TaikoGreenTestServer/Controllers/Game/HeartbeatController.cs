namespace TaikoGreenTestServer.Controllers.Game;

[ApiController]
[Route("/v11r01/chassis/heartbeat.php")]
public class HeartbeatController : BaseController<HeartbeatController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult HeartBeat([FromBody] HeartBeatRequest request)
    {
        Logger.LogInformation("Heartbeat request: {Request}", request.Stringify());
        var response = new HeartBeatResponse
        {
            Result = 1,
            ComSvrStat = 1,
            GameSvrStat = 1,
            BnidSvrStat = 1,
            BanacoinStat = 1
        };

        return Ok(response);
    }
}