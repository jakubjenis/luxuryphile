using IronPdf;
using Xunit;
using SelectPdf;

namespace Luxuryphile.Print;

/// <summary>
/// </summary>
public class HtmlToPdfTests_IronPdf
{
    [Fact]
    public void SelectPdf_ConvertSampleContract()
    {
        var renderer = new ChromePdfRenderer();
        renderer.RenderingOptions.HtmlFooter = new IronPdf.HtmlHeaderFooter()
        {
 
            MaxHeight = 15, //millimeters
            HtmlFragment = "<center><i>{page} of {total-pages}<i></center>",
            DrawDividerLine = true
        };
        
        
        var html = File.ReadAllText("smlouva_converted.html");
        var pdf = renderer.RenderHtmlAsPdf(html);
        pdf.SaveAs("smlouva_ironpdf.pdf");
    }
}