using Minimal_API.MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();  // 確保 API 探索器已啟用
builder.Services.AddSwaggerGen();  // 添加 Swagger 生成器

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalAPI");
        c.RoutePrefix = ""; // 確保 Swagger UI 從根 URL 加載
    });
}


app.MapUserEndpoints();
app.Run();
