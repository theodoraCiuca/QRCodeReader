using QRCodeReader.Core;
using QRCodeReader.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace QRCodeReader
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(Constants.ConsoleMessages.INSERT_FILE_PATH);

            var path = Console.ReadLine();

            var decoder = new Decoder();

            if (File.Exists(path) && decoder.ValidateFileExtension(path) && decoder.ValidateFileSize(path))
            {
                var text = await decoder.DecodeQRCodeAsync(path);
                if (!String.IsNullOrEmpty(text))
                {
                    Console.WriteLine(Constants.ConsoleMessages.ENCODED_TEXT_IS, text);
                }
            }
            else
            {
                Console.WriteLine(Constants.ConsoleMessages.FILE_VALIDATION_FAILED);
            }

            Console.ReadLine();
        }
    }
}
