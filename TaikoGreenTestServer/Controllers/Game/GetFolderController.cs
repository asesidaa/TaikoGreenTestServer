namespace TaikoGreenTestServer.Controllers.Game;

[Route("/v11r01/chassis/getfolder.php")]
[ApiController]
public class GetFolderController : BaseController<GetFolderController>
{
    [HttpPost]
    [Produces("application/protobuf")]
    public IActionResult GetFolder([FromBody] GetfolderRequest request)
    {
        Logger.LogInformation("GetFolder request : {Request}", request.Stringify());

        var response = new GetfolderResponse
        {
            Result = 1
        };

        foreach (var folderId in request.FolderIds)
        {
            var folderData = new GetfolderResponse.EventfolderData
            {
                FolderId = folderId,
                SongNoes = new uint[] {1,2,3},
                VerupNo = 1
            };
            response.AryEventfolderDatas.Add(folderData);
        }

        return Ok(response);
    }
}