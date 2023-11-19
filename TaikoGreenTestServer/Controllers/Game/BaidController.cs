using TaikoGreenTestServer.Utils;

namespace TaikoGreenTestServer.Controllers.Game;

[ApiController]
[Route("/v11r01/chassis/baidcheck.php")]
public class BaidController : BaseController<BaidController>
{

    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult GetBaid([FromBody] BAIDRequest request)
    {
        Logger.LogInformation("Baid request: {Request}", request.Stringify());
        var response = new BAIDResponse
        {
            Result = 1,
            PlayerType = 0,
            Baid = 1,
            MydonName = "Test",
            Title = "Test",
            TitleplateId = 1,
            ColorFace = 1,
            ColorBody = 1,
            ColorLimb = 1,
            AryCostumedata = new BAIDResponse.CostumeData
            {
                Costume1 = 0,
                Costume2 = 0,
                Costume3 = 0,
                Costume4 = 0,
                Costume5 = 0
            },
            CostumeFlg1 = Array.Empty<byte>(),
            CostumeFlg2 = Array.Empty<byte>(),
            CostumeFlg3 = Array.Empty<byte>(),
            CostumeFlg4 = Array.Empty<byte>(),
            CostumeFlg5 = Array.Empty<byte>(),
            LastPlayDatetime = DateTime.Today.ToString(Constants.DATE_TIME_FORMAT),
            GotDanMax = 0,
            GotDanFlg = Array.Empty<byte>(),
            GotDanextraFlg = Array.Empty<byte>(),
            DefaultToneSetting = 1,
            TotalGetDonmedal = 9999,
            TotalGetKatsumedal = 9999,
            TotalUseDonmedal = 0,
            TotalUseKatsumedal = 0,
            DispDanType = 1,
            IsPublish = true,
            CardOwnNum = 1,
            Personid = "1"
        };
        return Ok(response);
    }
}