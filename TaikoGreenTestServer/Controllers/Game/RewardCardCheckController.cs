namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/rewardcardcheck.php")]
[ApiController]
public class RewardCardCheckController : BaseController<RewardCardCheckController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult RewardCardCheck([FromBody] RewardcardcheckRequest request)
    {
        Logger.LogInformation("RewardItem request : {Request}", request.Stringify());

        var response = new RewardcardcheckResponse
        {
            Result = 1
        };

        return Ok(response);
    }
}