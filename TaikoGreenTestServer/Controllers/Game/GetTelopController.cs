namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/gettelop.php")]
[ApiController]
public class GetTelopController : BaseController<GetTelopController>
{
    private const string DateTimeFormat = "yyyyMMddHHmmss";
    
    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult GetTelop([FromBody] GettelopRequest request)
    {
        Logger.LogInformation("GetTelop request : {Request}", request.Stringify());

        var startDateTime = DateTime.Now - TimeSpan.FromDays(999.0);
        var endDateTime = DateTime.Now + TimeSpan.FromDays(999.0);

        var response = new GettelopResponse
        {
            Result = 1,
            StartDatetime = startDateTime.ToString(DateTimeFormat),
            EndDatetime = endDateTime.ToString(DateTimeFormat),
            Telop = "Hello world",
            VerupNo = 2
        };

        return Ok(response);
    }
}