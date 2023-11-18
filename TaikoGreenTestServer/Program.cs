using Serilog;
using TaikoGreenTestServer.Middlewares;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    builder.Services.AddControllers().AddProtoBufNet();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging(options =>
    {
        options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms, " +
                                  "request host: {RequestHost}";
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) => { diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value); };
    });

    app.Use(async (context, next) =>
    {
        await next();

        if (context.Response.StatusCode >= 400)
        {
            Log.Error("Unknown request from: {RemoteIpAddress}, method: {Method}, path: {Path}, code: {StatusCode}, " +
                      "content type: {ContentType}",
                      context.Connection.RemoteIpAddress,
                      context.Request.Method,
                      context.Request.Path,
                      context.Response.StatusCode,
                      context.Request.ContentType);
        }
    });
    app.MapControllers();
    app.UseWhen(
        context => context.Request.Path.StartsWithSegments("/sys/servlet/PowerOn", StringComparison.InvariantCulture),
        applicationBuilder => applicationBuilder.UseAllNetRequestMiddleware());
    app.UseWhen(context =>
                    context.Request.Path.StartsWithSegments("/v01r00", StringComparison.InvariantCulture) ||
                    context.Request.Path.StartsWithSegments("/v11r01", StringComparison.InvariantCulture),
                applicationBuilder => applicationBuilder.Use(
                    async (context, next) =>
                    {
                        // Check if the Content-Type header is missing
                        if (!context.Request.Headers.ContainsKey("Content-Type"))
                        {
                            // Set the Content-Type to 'application/x-protobuf'
                            context.Request.ContentType = "application/protobuf";
                        }

                        // Call the next delegate/middleware in the pipeline
                        await next();
                    }
                ));

    app.Run();
}
catch (Exception ex) when (ex.GetType().Name is not "HostAbortedException")
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}