using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

DirectoryInfo directory = new DirectoryInfo("/Users/manuelfigueroa/Documents/CsharpProjects/PDFReader/PDFReader/pdf");
FileInfo[] files = directory.GetFiles();

for (var i = 0; i < files.Count(); i++)
{
    var path = files[i].DirectoryName + "/" + files[i].Name;
    //create path for new txt files
    var newFilePath = files[i].DirectoryName + "/" + files[i].Name.Replace(".pdf", ".txt");
    //PDF Content
    var ExtractedPDFString = ExtractTextFromPdf(path);

    //Create file and Write into file
    await File.WriteAllTextAsync(newFilePath, ExtractedPDFString);

    //Console.WriteLine(files[i].Name.Replace(".pdf", ""));

}


string ExtractTextFromPdf(string path)
{
    using (PdfReader reader = new PdfReader(path))
    {
        StringBuilder text = new StringBuilder();

        for (int i = 1; i <= reader.NumberOfPages; i++)
        {
            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
        }

        return text.ToString();
    }
}
