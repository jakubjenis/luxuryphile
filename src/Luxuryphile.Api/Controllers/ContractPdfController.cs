using Luxuryphile.Api.Services.Pdf;
using Microsoft.AspNetCore.Mvc;

namespace Luxuryphile.Api.Controllers;

[ApiController]
[Route("contracts")]
public class ContractPdfController : ControllerBase
{
    private readonly ILogger<ContractPdfController> _logger;
    private readonly ContractPdfService _contractPdfService;

    public ContractPdfController(ILogger<ContractPdfController> logger, ContractPdfService contractPdfService)
    {
        _logger = logger;
        _contractPdfService = contractPdfService;
    }

    [HttpGet("{contractId}/pdf")]
    public async Task<IActionResult> Get([FromRoute] string contractId)
    {
        try
        {
            var stream = new MemoryStream();
            await _contractPdfService.GenerateContract(stream);
            stream.Position = 0;
            return File(stream, "application/pdf");
        }
        catch (Exception e)
        {
            throw;
        }
    }
}