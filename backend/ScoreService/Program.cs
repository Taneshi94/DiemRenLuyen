using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Đọc Connection String kết nối Database riêng của từng service
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// (Ví dụ: builder.Services.AddDbContext<EventDbContext>(options => options.UseSqlServer(connectionString));)

// 2. Cấu hình JWT Authentication (Chỉ để VALIDATE token do AuthServer cấp)
// Lưu ý: Key này phải GIỐNG HỆT Secret Key ở AuthServer để có thể giải mã được token.
var jwtSecret = builder.Configuration["JwtSettings:Secret"] ?? "q8z!s9$vB&x#mP2*fL5%tY7@wE4*uH1^jK3(dN6)pA0-zX8?cV";
var key = Encoding.UTF8.GetBytes(jwtSecret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"] ?? "DiemRenLuyenAuthServer",
        ValidAudience = builder.Configuration["JwtSettings:Audience"] ?? "DiemRenLuyenClient",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. Kích hoạt Middleware bảo mật
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();