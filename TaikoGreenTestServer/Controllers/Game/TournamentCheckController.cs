﻿namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/tournamentcheck.php")]
[ApiController]
public class TournamentCheckController : BaseController<TournamentCheckController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult TournamentCheck([FromBody] TournamentcheckRequest request)
    {
        Logger.LogInformation("TournamentCheck request : {Request}", request.Stringify());

        var response = new TournamentcheckResponse
        {
            Result = 1
        };

        return Ok(response);
    }
}