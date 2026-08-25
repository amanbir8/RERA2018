using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Common
{
    public class PageNumberPdfPageEventHelper : WatermarkPdfPageEventHelper
    {
        private readonly bool _showPageNumber;

        public PageNumberPdfPageEventHelper(bool showPageNumber = true)
        {
            _showPageNumber = showPageNumber;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Existing watermark
            base.OnEndPage(writer, document);

            // Page number only if enabled
            if (!_showPageNumber)
                return;

            PdfContentByte canvas = writer.DirectContent;

            BaseFont font = BaseFont.CreateFont(
                BaseFont.HELVETICA,
                BaseFont.CP1252,
                BaseFont.NOT_EMBEDDED
            );

            canvas.BeginText();

            canvas.SetFontAndSize(font, 9);
            canvas.SetColorFill(BaseColor.BLACK);

            canvas.ShowTextAligned(
                Element.ALIGN_RIGHT,
                "Page " + writer.PageNumber,
                document.PageSize.Width - 20f,
                20f,
                0
            );

            canvas.EndText();
        }
    }
    //public class PageNumberPdfPageEventHelper : WatermarkPdfPageEventHelper
    //{
    //    public override void OnEndPage(PdfWriter writer, Document document)
    //    {
    //        // Watermark
    //        base.OnEndPage(writer, document);

    //        // Page number
    //        PdfContentByte canvas = writer.DirectContent;

    //        BaseFont font = BaseFont.CreateFont(
    //            BaseFont.HELVETICA,
    //            BaseFont.CP1252,
    //            BaseFont.NOT_EMBEDDED
    //        );

    //        canvas.BeginText();

    //        canvas.SetFontAndSize(font, 9);
    //        canvas.SetColorFill(BaseColor.GRAY);

    //        canvas.ShowTextAligned(
    //            Element.ALIGN_CENTER,
    //            "Page " + writer.PageNumber,
    //            document.PageSize.Width / 2,
    //            20f,
    //            0
    //        );

    //        canvas.EndText();
    //    }
    //}
}