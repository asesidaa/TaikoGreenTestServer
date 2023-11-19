namespace TaikoGreenTestServer.Controllers.Game;

[ApiController]
[Route("/v11r01/chassis/recommend.php")]
public class RecommendController : BaseController<RecommendController>
{
    public IActionResult GetRecommend([FromBody] RecommendRequest request)
    {
        Logger.LogInformation("Recommend request: {Request}", request.Stringify());
        var response = new RecommendResponse
        {
            Result = 1
        };
        return Ok(response);
    }
}