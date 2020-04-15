using Newtonsoft.Json;
using QRCodeReader.Helpers;
using QRCodeReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QRCodeReader.Core
{
    public class Decoder
    {
        private static readonly List<string> AllowedFileExtensions = new List<string>() {
            Constants.FileExtensions.PNG,
            Constants.FileExtensions.GIF,
            Constants.FileExtensions.JPG,
            Constants.FileExtensions.JPEG
        };

        /// <summary>
        /// Validates file extension constraint
        /// </summary>
        public bool ValidateFileExtension(string path) => AllowedFileExtensions.Contains(Path.GetExtension(path).ToLower());

        /// <summary>
        /// Validates file size constraint
        /// </summary>
        public bool ValidateFileSize(string path) => new FileInfo(path).Length < Constants.MAX_FILE_SIZE_VALUE;

        /// <summary>
        /// Decode QR code from specified file path
        /// </summary>
        /// <returns>Text data encoded in the QR code</returns>
        public async Task<string> DecodeQRCodeAsync(string path)
        {
            var result = new List<QRCodeResponseModel>();

            using (var httpClient = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(Constants.MAX_FILE_SIZE_VALUE.ToString()), Constants.MAX_FILE_SIZE_PARAM_NAME);
                formData.Add(new ByteArrayContent(File.ReadAllBytes(path)), Constants.FILE_PARAM_NAME, Path.GetFileName(path));

                var response = await httpClient.PostAsync(Constants.API_URL, formData);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(Constants.ConsoleMessages.SOMETHING_WENT_WRONG);
                    return null;
                }

                var data = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<QRCodeResponseModel>>(data);
            }

            if (result != null)
            {
                var decodedObject = result.First().Symbol.First();
                if (String.IsNullOrEmpty(decodedObject.Data) && !String.IsNullOrEmpty(decodedObject.Error))
                {
                    Console.WriteLine(Constants.ConsoleMessages.ERROR_OCCURRED, decodedObject.Error);
                }
                return decodedObject.Data;
            }

            return null;
        }
    }
}
