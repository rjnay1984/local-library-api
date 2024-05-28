var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddJwtBearer("Authentik");
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => new { Message = "Hello World!"});
app.MapGet("/protected", () => new { Message = "Protected route"}).RequireAuthorization();

app.Run();
