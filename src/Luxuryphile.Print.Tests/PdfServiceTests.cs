using FluentAssertions;

namespace Luxuryphile.Print.Tests;

public class PdfServiceTests
{
    [Fact]
    public async Task PdfService_GeneratePdf()
    {
        var service = new PdfService();
        var htmlTemplate = await File.ReadAllTextAsync("Templates/contract_simple.html");

        var doc = service.GeneratePdfDocument(htmlTemplate);
        
        await using var stream = new MemoryStream();
        doc.Save(stream);
        doc.DetachStream(); //do we need this?
        doc.Close();
        
        stream.Position = 0;

        //cannot use streamReader for binary data 
        await using var fileStream = File.Create("PdfService_GeneratePdf_Output.pdf");
        await stream.CopyToAsync(fileStream);
        fileStream.Close();

        var pdfContent = await File.ReadAllBytesAsync("PdfService_GeneratePdf_Output.pdf");
        pdfContent.Should().NotBeNullOrEmpty();
        pdfContent.Length.Should().BeGreaterThan(1000);
    }
}