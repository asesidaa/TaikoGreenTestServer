using System.Buffers.Binary;
using System.Text.Json;

namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/userdata.php")]
[ApiController]
public class UserDataController : BaseController<UserDataController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public async Task<IActionResult> GetUserData([FromBody] UserDataRequest request)
    {
        Logger.LogInformation("UserData request : {Request}", request.Stringify());
        // Create a byte array filled with 0xFF
        var byteArray = new byte[200];
        Array.Fill(byteArray, (byte)0xFF);
        
        var response = new UserDataResponse
        {
            Result = 1,
            ToneFlg = byteArray,
            TitleFlg = byteArray,
            HashReleaseSongFlg = byteArray,
            IsDevil = true,
            DispScoreType = 1,
            OptionFlg = Array.Empty<byte>(),
            DefaultOptionSetting = Array.Empty<byte>(),
            DifficultyPlayedCourse = 0,
            DifficultyPlayedStar = 0,
            IsChallengecompe = false,
            SongRecentCnt = 0,
            IsTojiru = false,
        };

        return Ok(response);
    }
}