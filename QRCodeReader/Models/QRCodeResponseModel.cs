using System.Collections.Generic;

namespace QRCodeReader.Models
{
    /// <summary>
    /// Model for QR code API response
    /// </summary>
    public class QRCodeResponseModel
    {
        public string Type;
        public IEnumerable<QRCodeDataModel> Symbol;

        public QRCodeResponseModel()
        {
            Symbol = new List<QRCodeDataModel>();
        }
    }
}
