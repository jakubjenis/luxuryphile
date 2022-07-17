using Xunit;
using SelectPdf;

namespace Luxuryphile.Print;

/// <summary>
/// With select pdf community edition, we can create pdf documents from html
/// Need to convert docs to html - editable only in HTML
/// https://wkhtmltopdf.org/ alternative
/// </summary>
public class HtmlToPdfTests_SelectPdf
{
    [Fact]
    public void SelectPdf_ConvertSampleContract()
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
                MarginTop = 30
            }
        };

        converter.Options.DisplayFooter = true;
        converter.Footer.Height = 40;
        converter.Footer.DisplayOnFirstPage = true;
        converter.Footer.DisplayOnOddPages = true;
        converter.Footer.DisplayOnEvenPages = true;
        
        var text = new PdfTextSection(0, 15, "{page_number}/{total_pages}", new System.Drawing.Font("Calibri", 10))
        {
            HorizontalAlign = PdfTextHorizontalAlign.Center,
            VerticalAlign = PdfTextVerticalAlign.Middle
        };
        converter.Footer.Add(text);
        

        var html = File.ReadAllText("smlouva_converted.html");

        // create a new pdf document converting an url
        var doc = converter.ConvertHtmlString(html);
        
        // save pdf document
        doc.Save("smlouva_selectpdf.pdf");

        // close pdf document
        doc.Close();
    }
}