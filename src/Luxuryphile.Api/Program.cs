using Luxuryphile.Api.Services;
using Luxuryphile.Api.Services.Pdf;
using Luxuryphile.Print;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

//REST
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//GRPC
builder.Services.AddGrpc();
builder.Services.AddTransient<IPdfService, PdfService>();
builder.Services.AddTransient<ContractPdfService, ContractPdfService>();

var app = builder.Build();

//SWAGGER
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/",
    () =>
        "Hello from Luxuryphile.API");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();