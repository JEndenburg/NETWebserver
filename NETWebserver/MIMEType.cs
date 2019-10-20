using System;
using System.Collections.Generic;
using System.Text;

namespace NETWebserver
{
    public sealed class MIMEType
    {
        public static readonly MIMEType PlainText = new MIMEType("text", "plain");
        public static readonly MIMEType CSS = new MIMEType("text", "css");
        public static readonly MIMEType HTML = new MIMEType("text", "html");
        public static readonly MIMEType JavaScript = new MIMEType("text", "javscript");

        public static readonly MIMEType APNG = new MIMEType("image", "apng");
        public static readonly MIMEType BMP = new MIMEType("image", "bmp");
        public static readonly MIMEType GIF = new MIMEType("image", "gif");
        public static readonly MIMEType ICO = new MIMEType("image", "x-icon");
        public static readonly MIMEType JPEG = new MIMEType("image", "jpeg");
        public static readonly MIMEType PNG = new MIMEType("image", "png");
        public static readonly MIMEType SVG = new MIMEType("image", "svg+xml");
        public static readonly MIMEType TIFF = new MIMEType("image", "tiff");
        public static readonly MIMEType WebP = new MIMEType("image", "webp");

        public static readonly MIMEType Wave = new MIMEType("audio", "wave");
        public static readonly MIMEType AudioWebM = new MIMEType("audio", "webm");
        public static readonly MIMEType AudioOGG = new MIMEType("audio", "ogg");

        public static readonly MIMEType VideoWebM = new MIMEType("video", "webm");
        public static readonly MIMEType VideoOGG = new MIMEType("video", "ogg");

        public static readonly MIMEType ApplicationOGG = new MIMEType("application", "ogg");
        public static readonly MIMEType JSON = new MIMEType("application", "json");
        public static readonly MIMEType PDF = new MIMEType("application", "pdf");
        public static readonly MIMEType ZIP = new MIMEType("application", "zip");

        public string Type { get; private set; }
        public string SubType { get; private set; }

        private MIMEType(string type, string subType)
        {
            this.Type = type;
            this.SubType = subType;
        }

        public override string ToString()
        {
            return $"{Type}/{SubType}";
        }
    }
}
