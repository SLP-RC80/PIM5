using PIMEventosTI;
using PIMEventosTI.Services;

if (args.Length > 0 && args[0] == "console")
{
    ProgramConsole.RunConsole();
    return;
}

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddControllers();

builder.Services.AddSingleton<EventoService>();
builder.Services.AddSingleton<InscricaoService>();
builder.Services.AddSingleton<CertificadoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", () => "API PIMEventosTI rodando");

app.Run();
