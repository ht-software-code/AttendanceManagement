using System.Text;
using AttendanceManagement.Server.Services;
using Data.DbContexts;
using Data.Entities;
using Library;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApiService.Common.Const;

// Shift-JIS使用許可
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// ログトレース設定
var loggerPrefix = builder.Configuration["LoggerPrefix"] ?? "AttendanceManagement";

// Logger を初期化
Logger.Initialize(loggerPrefix);

// サービス登録
builder.Services.AddControllers();

// EF Core登録
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

// ユーザ認証サービス登録（Identity）
builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();

int tokenLockoutTimeSpanDay = int.Parse(builder.Configuration["TokenLockoutTimeSpanDay"] ?? "1");

// Identity設定
builder.Services.Configure<IdentityOptions>(options =>
{
    // パスワード設定
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 1;

    // ロックアウト設定
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // ユーザー設定
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    options.User.RequireUniqueEmail = false;

    // サインインの設定
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

// 認証トークン取得
var tokenKey = builder.Configuration["JwtSettings:TokenKey"];
if (string.IsNullOrWhiteSpace(tokenKey))
{
    throw new ArgumentNullException(nameof(tokenKey));
}

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

// 認証JWTトークン設定
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(opt =>
               {
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = key,
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero
                   };
               });

// 認証サービス登録
builder.Services.AddScoped<AuthServiceJWT>();

// CORS登録
var corsOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        if (corsOrigins != null && corsOrigins.Length > 0)
        {
            policy.WithOrigins(corsOrigins)
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithExposedHeaders(CustomHeaderPrefixes.AuthToken.HeaderName);
        }
        else
        {
            // 設定がなければ全て許可
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithExposedHeaders(CustomHeaderPrefixes.AuthToken.HeaderName);
        }
    });
});

WebApplication app = builder.Build();

// 認証ミドルウェア有効
app.UseRouting();

// CORS有効
app.UseCors("AllowFrontend");
// app.UseCors("AllowAll");

// 認証・承認ミドルウェアを有効化（JWT認証に必須）
app.UseAuthentication();
app.UseAuthorization();

// 静的ファイルの既定ファイル有効化
app.UseDefaultFiles();
app.MapStaticAssets();

//// HTTP 要求を HTTPS にリダイレクト
// app.UseHttpsRedirection();

// ルーティング登録
app.MapControllers();

// ファイルの提供
app.MapFallbackToFile("/index.html");

app.Run();