using Minimal_API.MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();  // �T�O API �������w�ҥ�
builder.Services.AddSwaggerGen();  // �K�[ Swagger �ͦ���

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalAPI");
        c.RoutePrefix = ""; // �T�O Swagger UI �q�� URL �[��
    });
}


app.MapUserEndpoints();
app.Run();
