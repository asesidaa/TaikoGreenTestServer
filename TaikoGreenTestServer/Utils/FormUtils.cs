using System.Text;

namespace TaikoGreenTestServer.Utils;

public static class FormUtils
{
    public static string ToFormOutput(Dictionary<string, string> response)
    {
        var responseStr = new StringBuilder();
        foreach (var pair in response)
        {
            responseStr.Append(pair.Key)
                .Append('=')
                .Append(pair.Value)
                .Append('&');
        }

        return responseStr.ToString().TrimEnd('&');
    }
}