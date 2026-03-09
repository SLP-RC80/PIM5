using PIMEventosTI.Services;

var builder = WebApplication.CreateBuilder(args);

// registrar controllers
builder.Services.AddControllers();

// registrar services
builder.Services.AddSingleton<EventoService>();
builder.Services.AddSingleton<InscricaoService>();
builder.Services.AddSingleton<CertificadoService>();

// habilitar documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger (documentação automática da API)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
