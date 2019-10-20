using System;
using System.Collections.Generic;
using System.Text;

namespace NETWebserver.Domain
{
    public class Content
    {
        public MIMEType Type { get; private set; }
        public KeyValuePair<string, string> MIMEParameter { get; private set; }
        public byte[] Bytes { get; private set; }
        public Encoding Encoding { get; private set; }

        public Content(MIMEType type, KeyValuePair<string, string> parameter, byte[] contentBytes, Encoding encoding)
        {
            this.Type = type;
            this.MIMEParameter = parameter;
            this.Bytes = contentBytes;
            this.Encoding = encoding;
        }

        public Content(MIMEType type, byte[] contentBytes, Encoding encoding) : this(type, new KeyValuePair<string, string>(), contentBytes, encoding)
        {
        }
    }
}
