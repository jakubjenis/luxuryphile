using Luxuryphile.Print;

namespace Luxuryphile.Api.Services.Pdf;

public class ContractPdfService
{
    private readonly IPdfService _pdfService;

    public ContractPdfService(IPdfService pdfService)
    {
        _pdfService = pdfService;
    }
    
    public async Task<Stream> GenerateContract(Stream stream)
    {
        var htmlTemplate = await File.ReadAllTextAsync("Templates/contract_template.html");
        var document = _pdfService.GeneratePdfDocument(htmlTemplate);
        document.Save(stream);
        document.DetachStream();
        document.Close();

        return stream;
    }
}