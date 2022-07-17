using SelectPdf;

namespace Luxuryphile.Print;

public interface IPdfService
{
    PdfDocument GeneratePdfDocument(string htmlTemplate);
}

public class PdfService : IPdfService
{
    public PdfDocument GeneratePdfDocument(string htmlTemplate)
    {
        // instantiate a html to pdf converter object
        var converter = new HtmlToPdf
        {
            Options =
            {
                PdfPageSize = PdfPageSize.A4,
                PdfPageOrientation = PdfPageOrientation.Portrait,
                MarginBottom = 0,
                MarginLeft = 50,
                MarginRight = 50,
                MarginTop = 30,
                DisplayFooter = true
            },
            Footer =
            {
                Height = 40,
                DisplayOnFirstPage = true,
                DisplayOnOddPages = true,
                DisplayOnEvenPages = true
            }
        };

        var text = new PdfTextSection(0, 15, "{page_number}/{total_pages}", new System.Drawing.Font("Calibri", 10))
        {
            HorizontalAlign = PdfTextHorizontalAlign.Center,
            VerticalAlign = PdfTextVerticalAlign.Middle
        };
        converter.Footer.Add(text);

       // var html = File.ReadAllText("smlouva_converted.html");

        // create a new pdf document converting an url
        var doc = converter.ConvertHtmlString(htmlTemplate);

        return doc;
    }
}