using System;
using System.Collections.Generic;
using System.Text;

namespace NETWebserver
{
    public class Request
    {

        public HTTPMethod Method { get; private set; }
        public Uri RequestedUri { get; private set; }
        public string HTTPVersion { get; private set; }
        public IReadOnlyDictionary<string, string> Headers { get; private set; }
        public string RawBody { get; private set; }

        internal Request(HTTPMethod method, Uri requestedUri, string httpVersion, Dictionary<string, string> headers, string body)
        {
            this.Method = method;
            this.RequestedUri = requestedUri;
            this.HTTPVersion = httpVersion;
            this.Headers = headers;
            this.RawBody = body;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder($"{Method} {RequestedUri} {HTTPVersion}\n");
            foreach (string headerKey in Headers.Keys)
                stringBuilder.Append($"{headerKey}: {Headers[headerKey]}\n");
            stringBuilder.Append($"\n{RawBody}");
            return stringBuilder.ToString();
        }
    }
}
