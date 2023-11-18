﻿using TaikoGreenTestServer.Utils;

namespace TaikoGreenTestServer.Controllers.AmAuth;

public class MuchaController : BaseController<MuchaController>
{
    private const string MuchaUrl = "https://192.168.1.4:54430";
    [HttpPost("/mucha_front/boardauth.do")]
    public ContentResult BoardAuth([FromForm] MuchaUpdateCheckRequest request)
    {
        Logger.LogInformation("Mucha request: {Request}", request.Stringify());
        var serverTime = DateTime.Now.ToString("yyyyMMddHHmm");
        var utcServerTime = DateTime.UtcNow.ToString("yyyyMMddHHmm");
        var response = new Dictionary<string, string>
        {
            { "RESULTS", "001" },
            { "AREA_0", "008" },
            { "AREA_0_EN", "" },
            { "AREA_1", "009" },
            { "AREA_1_EN", "" },
            { "AREA_2", "010" },
            { "AREA_2_EN", "" },
            { "AREA_3", "011" },
            { "AREA_3_EN", "" },
            { "AREA_FULL_0", "" },
            { "AREA_FULL_0_EN", "" },
            { "AREA_FULL_1", "" },
            { "AREA_FULL_1_EN", "" },
            { "AREA_FULL_2", "" },
            { "AREA_FULL_2_EN", "" },
            { "AREA_FULL_3", "" },
            { "AREA_FULL_3_EN", "" },
            { "AUTH_INTERVAL", "86400" },
            { "CHARGE_URL", $"{MuchaUrl}/charge/" },
            { "COUNTRY_CD", "JPN" },
            { "DONGLE_FLG", "1" },
            { "EXPIRATION_DATE", "null" },
            { "FILE_URL", $"{MuchaUrl}/file/" },
            { "FORCE_BOOT", "0" },
            { "PLACE_ID", request.PlaceId ?? "" },
            { "PREFECTURE_ID", "14" },
            { "SERVER_TIME", serverTime },
            { "UTC_SERVER_TIME", utcServerTime },
            { "SHOP_NAME", "NAMCO" },
            { "SHOP_NAME_EN", "NAMCO" },
            { "SHOP_NICKNAME", "W" },
            { "SHOP_NICKNAME_EN", "W" },
            { "URL_1", $"{MuchaUrl}/url1/" },
            { "URL_2", $"{MuchaUrl}/url2/" },
            { "URL_3", $"{MuchaUrl}/url3/" },
            { "USE_TOKEN", "0" },
            { "CONSUME_TOKEN", "0" },
        };
        var formOutput = FormUtils.ToFormOutput(response);
        return Content(formOutput);
    }

    [HttpPost("/mucha_front/updatacheck.do")]
    public ContentResult UpdateCheck(MuchaBoardAuthRequest request)
    {
        // TODO: Figure out how to pass mucha check properly
        var response = new Dictionary<string, string>
        {
            { "RESULTS", "001" },
            //{ "UPDATE_VER_1", request.GameVersion ?? "S1110JPN13.02" },
            { "UPDATE_URL_1", $"{MuchaUrl}/updUrl1/" },
            { "UPDATE_SIZE_1", "20" },
            { "UPDATE_CRC_1", "00000000" },
            { "CHECK_URL_1", $"{MuchaUrl}/checkUrl/" },
            { "CHECK_SIZE_1", "20" },
            { "CHECK_CRC_1", "00000000" },
            { "EXE_VER_1", request.GameVersion ?? "S1110JPN13.02" },
            { "INFO_SIZE_1", "0" },
            { "COM_SIZE_1", "0" },
            { "COM_TIME_1", "0" },
            { "LAN_INFO_SIZE_1", "0" },
            { "USER_ID", "1" },
            { "PASSWORD", "1" },
            { "EXE_VER", request.GameVersion ?? "S1110JPN13.02" },
        };
        Logger.LogInformation("Request is {Request}", request.Stringify());
        var formOutput = FormUtils.ToFormOutput(response);
        return Content(formOutput);
    }
}