using Microsoft.Extensions.Options;

namespace TaikoGreenTestServer.Controllers.Game;

[ApiController]
[Route("/v11r01/chassis/initialdatacheck.php")]
public class InitialDataCheckController : BaseController<InitialDataCheckController>
{
	[HttpPost]
	[Produces("application/protobuf")]
	public IActionResult InitialDataCheck([FromBody] InitialdatacheckRequest request)
	{
		Logger.LogInformation("Initial data check request: {Request}", request.Stringify());

		var response = new InitialdatacheckResponse
		{
			Result = 1,
			IsDanplay = true,
			IsClose = false,
			IsItemshop = false,
			IsGhostbattleplay = true
		};

		return Ok(response);
	}

}