namespace QRCodeReader.Helpers
{
    public static class Constants
    {
        public const string MAX_FILE_SIZE_PARAM_NAME = "MAX_FILE_SIZE";
        public const string FILE_PARAM_NAME = "file";
        public const int MAX_FILE_SIZE_VALUE = 1048576;
        public const string API_URL = @"http://api.qrserver.com/v1/read-qr-code/";

        public static class ConsoleMessages
        {
            public const string INSERT_FILE_PATH = "Please insert a file path: ";
            public const string ENCODED_TEXT_IS = "Text encoded in the QR code image is:\n{0}";
            public const string FILE_VALIDATION_FAILED = "File validation failed!";
            public const string SOMETHING_WENT_WRONG = "Something went wrong with QR code decoding!";
            public const string ERROR_OCCURRED = "The following error has occurred: {0}";
        }

        public static class FileExtensions
        {
            public const string PNG = ".png";
            public const string GIF = ".gif";
            public const string JPG = ".jpg";
            public const string JPEG = ".jpeg";
        }
    }
}
