var builder = WebApplication.CreateBuilder(args);

// Thêm YARP Reverse Proxy từ cấu hình appsettings.json
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Bật CORS để cho phép Angular app gọi API qua Gateway
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");
app.MapReverseProxy();

app.Run();