using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Content("<a href='/translate-service' target='_blank'>Start [Translate Service]</a>", "text/html");
});
app.MapGet("/translate-service", async () =>
{
    return await TranslateService.Start();
});

// app.MapPost("/callback", async (HttpContext context) =>
// {
//     string result = "";
//     try
//     {
//         using StreamReader reader = new(context.Request.Body);
//         char[] buf = new char[512];
//         int len = 0;
//         StringBuilder contentBuffer = new();
//         while ((len = await reader.ReadAsync(buf, 0, buf.Length)) > 0)
//         {
//             contentBuffer.Append(buf, 0, len);
//         }
//         result = contentBuffer.ToString();
//     }
//     catch (Exception e)
//     {
//         // handle exception
//         result = e.ToString();
//     }
//     return result;
// }
// );

app.UseStaticFiles();

app.Run("http://+:5000");