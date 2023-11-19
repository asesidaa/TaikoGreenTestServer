namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/rewardexecution.php")]
[ApiController]
public class RewardExecutionController : BaseController<RewardExecutionController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult RewardCardCheck([FromBody] RewardexecutionRequest request)
    {
        Logger.LogInformation("RewardItem request : {Request}", request.Stringify());

        var response = new RewardexecutionResponse
        {
            Result = 1
        };

        return Ok(response);
    }
}