namespace ConsoleApp1
{
    using System;
    using System.Drawing;

    using Spire.Pdf;
    using Spire.Pdf.Graphics;

    public class Program
    {
        public static string outputPath = @"C:\Users\danie\Desktop\out.pdf";

        public static string imagePath = @"C:\Users\danie\Desktop\Capture.PNG";

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
        }

        private static void SpireConvertToPdf()
        {
            PdfDocument doc = new PdfDocument();
            doc.CompressionLevel = PdfCompressionLevel.Best;
            PdfImage image = PdfImage.FromFile(imagePath);
            double percent = 0.77;
            float w = (int)(image.Width*percent);
            float h = (int)(image.Height*percent);
            PdfPageBase page = doc.Pages.Add(new SizeF(w, h), new PdfMargins(0, 0, 0, 0));
            page.Canvas.DrawImage(image, 100000, 0, 0, w+1, h);
            doc.SaveToFile(outputPath);
        }
    }
}
