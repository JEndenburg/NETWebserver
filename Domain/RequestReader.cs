using System;
using System.Text;
using System.Collections.Generic;

namespace NETWebserver.Domain
{
    public class RequestReader
    {
        public Request ReadRequest(byte[] buffer)
        {
            HTTPMethod method;
            Uri uri;
            string version;
            Dictionary<string, string> headers;
            string body;


            string[] requestLines = Encoding.UTF8.GetString(buffer).Split('\n');

            ReadMethodUriVersion(requestLines[0], out method, out uri, out version);
            int bodyStartIndex;
            headers = GetHeaders(requestLines, out bodyStartIndex);
            if (method != HTTPMethod.GET)
                body = GetBody(requestLines, bodyStartIndex + 1, (headers.ContainsKey("content-length")) ? int.Parse(headers["content-length"]) : -1);
            else
                body = string.Empty;

            return new Request(method, uri, version, headers, body);
        }

        private void ReadMethodUriVersion(string methodUriVersionLine, out HTTPMethod method, out Uri uri, out string version)
        {
            string[] lineParts = methodUriVersionLine.Split(' ');
            method = ParseMethod(lineParts[0]);
            uri = new Uri(lineParts[1], UriKind.Relative);
            version = lineParts[2];
        }

        private HTTPMethod ParseMethod(string methodString)
        {
            switch(methodString.ToUpper())
            {
                case "GET":
                    return HTTPMethod.GET;
                case "POST":
                    return HTTPMethod.POST;
                case "PUT":
                    return HTTPMethod.PUT;
                case "DELETE":
                    return HTTPMethod.DELETE;
                default:
                    return HTTPMethod.UNKNOWN;
            }
        }

        private Dictionary<string, string> GetHeaders(string[] requestLines, out int headersEndIndex)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            int currentLineIndex = 1;
            string currentLine;
            while(!(currentLine = requestLines[currentLineIndex].Trim()).Equals(String.Empty))
            {
                string[] headerKV = currentLine.Split(':');
                if (headerKV.Length == 2)
                    headers.Add(headerKV[0].Trim().ToLower(), headerKV[1].Trim().ToLower());
                currentLineIndex++;
            }
            headersEndIndex = currentLineIndex;
            return headers;
        }

        private string GetBody(string[] requestLines, int bodyStartIndex, int contentLength = -1)
        {
            string body = string.Join('\n', requestLines, bodyStartIndex, requestLines.Length - bodyStartIndex);
            if (contentLength >= 0)
                return body.Substring(0, contentLength);
            else
                return body;
        }
    }
}
