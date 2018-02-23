namespace ConsoleApp1
{
    using System;
    using System.Drawing;

    using Spire.Pdf;
    using Spire.Pdf.Graphics;

    public class Program
    {
        public static string outputPath = @"C:\Users\danie\Downloads\out.pdf";

        public static string imagePath = @"C:\Users\danie\Downloads\Capture.PNG";

        public static void Main(string[] args)
        {
            try
            {
                SpireConvertToPdf();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("done");
            Console.Read();
        }

        private static void SpireConvertToPdf()
        {
            PdfDocument doc = new PdfDocument();
            doc.CompressionLevel = PdfCompressionLevel.Best;
            PdfImage image = PdfImage.FromFile(imagePath);
            double percent = 0.8;
            float w = (int)(image.Width*percent);
            float h = (int)(image.Height*percent);
            PdfPageBase page = doc.Pages.Add(new SizeF(w, h), new PdfMargins(0, 0, 0, 0));
            page.Canvas.DrawImage(image, 100000, 0, 0, w, h);
            doc.SaveToFile(outputPath);
        }
    }
}
