using OCR.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            OcrEngine ocrEngine = new OcrEngine();

            var files = Directory.GetFiles("D:\\Plates\\");

            Console.WriteLine("{0} adet plaka sorgulanacak. Başlamak için bir enter basınız...", files.Length);

            Console.ReadLine();

            int truePlateCount = 0;

            int wrongPlateCount = 0;

            Stopwatch stopwatch = new Stopwatch();

            foreach (var file in files)
            {
                stopwatch.Reset();

                string fileName = Path.GetFileName(file).Remove(0, 1);

                var fileSplit = fileName.Split('.');

                string filePlateName = fileSplit[0];

                stopwatch.Start();

                string ocrResult = ocrEngine.DoOcr(file);

                stopwatch.Stop();

                Console.WriteLine("File : " + file + "\t Process Time : " + stopwatch.ElapsedMilliseconds + " ms" + "\tResult : " + ocrResult);

                if (ocrResult == filePlateName)
                {
                    truePlateCount++;
                }
                else
                {
                    wrongPlateCount++;
                }
            }

            Console.WriteLine("{0} adet plaka doğru tespit edildi...", truePlateCount);

            Console.WriteLine("{0} adet plaka yanlış tespit edildi...", wrongPlateCount);

            Console.ReadLine();
        }
    }
}
