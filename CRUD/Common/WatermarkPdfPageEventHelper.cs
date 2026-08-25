using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CRUD.Common
{
    public class WatermarkPdfPageEventHelper : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte under = writer.DirectContentUnder;

            // image path
            string imagePath = HttpContext.Current.Server.MapPath("~/images/logo-big.png");
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);

            //  image size
            float width = document.PageSize.Width * 0.7f;   // 70% of page width
            float height = document.PageSize.Height * 0.7f; // 70% of page height
            img.ScaleToFit(width, height);

            // Set position (centered)
            float x = (document.PageSize.Width - img.ScaledWidth) / 2;
            float y = (document.PageSize.Height - img.ScaledHeight) / 2;
            img.SetAbsolutePosition(x, y);

            // Set transparency
            PdfGState gstate = new PdfGState { FillOpacity = 0.30f }; // 15% opacity
            under.SaveState();
            under.SetGState(gstate);

            under.AddImage(img);

            under.RestoreState();
        }
    }
}