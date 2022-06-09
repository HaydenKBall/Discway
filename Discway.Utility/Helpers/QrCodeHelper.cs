using System.Drawing;
using System.Drawing.Imaging;
using Discway.Data.Context;
using Discway.Data.Dto;
using QRCoder;

namespace Discway.Utility.Helpers
{
    public static class QrCodeHelper
    {
        //string endPoint = 
        public static string CreateQrCode()
        {
            var generator = new PayloadGenerator.Url("https://github.com/codebude/QRCoder/");

            var payload = generator.ToString();

            var qrGenerator = new QRCodeGenerator();

            var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new QRCode(qrCodeData);

            var qrCodeAsBitmap = qrCode.GetGraphic(20);

            var bitmapArray = qrCodeAsBitmap.BitmapToByteArray();

            var qrString = $"data:image/png;base64, {Convert.ToBase64String(bitmapArray)}";

            return qrString;
        }

        public static Tag CreateTag(DiscwayContext context)
        {
            var tag = new Tag();

            tag.QrCode = CreateQrCode();

            tag.CreatedDate = DateTime.UtcNow;

            context.Tag.Add(tag);

            context.SaveChanges();

            return tag;
        }
    }

    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using var ms = new MemoryStream();

            bitmap.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }
    }
}
