using AlibabaCloud.SDK.Alimt20181012.Models;
using Tea;

public class TranslateService
{
    private static readonly string BASE_URL = "http://www.xxx.com";
    public static AlibabaCloud.SDK.Alimt20181012.Client CreateClient()
    {
        AlibabaCloud.OpenApiClient.Models.Config config = new()
        {
            AccessKeyId = "xxxxxx",
            AccessKeySecret = "xxxxxx",
            Endpoint = "mt.cn-hangzhou.aliyuncs.com"
        };
        return new AlibabaCloud.SDK.Alimt20181012.Client(config);
    }
    public static async Task<string> Start()
    {
        AlibabaCloud.SDK.Alimt20181012.Client client = CreateClient();
        AlibabaCloud.TeaUtil.Models.RuntimeOptions runtimeOptions = new();
        try
        {
            CreateDocTranslateTaskRequest createDocTranslateTaskRequest = new()
            {
                SourceLanguage = "en",
                TargetLanguage = "th",
                FileUrl = $"{BASE_URL}/i18n/en.json",
                //CallbackUrl = $"{BASE_URL}/callback",
            };
            runtimeOptions.Autoretry = true;
            runtimeOptions.MaxAttempts = 3;
            var response = await client.CreateDocTranslateTaskWithOptionsAsync(createDocTranslateTaskRequest, runtimeOptions);

            string docTaskId = response.Body.TaskId;
            GetDocTranslateTaskRequest getDocTranslateTaskRequest = new() { TaskId = docTaskId };
            var getDocTaskResponse = await client.GetDocTranslateTaskWithOptionsAsync(getDocTranslateTaskRequest, runtimeOptions);
            if (AlibabaCloud.TeaUtil.Common.EqualString(getDocTaskResponse.Body.Status, "translated"))
            {
                return AlibabaCloud.TeaUtil.Common.ToJSONString(getDocTaskResponse.ToMap());
            }
            else
            {
                return "Task fail";
            }
        }
        catch (TeaException error)
        {
            return error.Message + "-" + error.Data["Recommend"];
        }
        catch (Exception _error)
        {
            TeaException error = new(new Dictionary<string, object>
                {
                    { "message", _error.Message }
                });
            return error.Message + "-" + error.Data["Recommend"];
        }
    }
}
