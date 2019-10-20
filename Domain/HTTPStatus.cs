using System;
using System.Collections.Generic;
using System.Text;

namespace NETWebserver.Domain
{
    public sealed class HTTPStatus
    {
        public static readonly HTTPStatus OK = new HTTPStatus(200, "OK");
        public static readonly HTTPStatus Created = new HTTPStatus(201, "Created");
        public static readonly HTTPStatus Accepted = new HTTPStatus(202, "Accepted");
        public static readonly HTTPStatus NoContent = new HTTPStatus(204, "No Content");

        public static readonly HTTPStatus MovedPermanently = new HTTPStatus(301, "Moved Permanently");
        public static readonly HTTPStatus Found = new HTTPStatus(302, "Found");
        public static readonly HTTPStatus NotModified = new HTTPStatus(304, "Not Modified");
        public static readonly HTTPStatus TemporaryRedirect = new HTTPStatus(307, "Temporary Redirect");
        public static readonly HTTPStatus PermanentRedirect = new HTTPStatus(308, "Permanent Redirect");

        public static readonly HTTPStatus BadRequest = new HTTPStatus(400, "Bad Request");
        public static readonly HTTPStatus Unauthorized = new HTTPStatus(401, "Unauthorized");
        public static readonly HTTPStatus Forbidden = new HTTPStatus(403, "Forbidden");
        public static readonly HTTPStatus NotFound = new HTTPStatus(404, "Not Found");
        public static readonly HTTPStatus MethodNotAllowed = new HTTPStatus(405, "Method Not Allowed");
        public static readonly HTTPStatus NotAcceptable = new HTTPStatus(406, "Not Acceptable");
        public static readonly HTTPStatus RequestTimeout = new HTTPStatus(408, "Request Timeout");
        public static readonly HTTPStatus Conflict = new HTTPStatus(409, "Conflict");
        public static readonly HTTPStatus Gone = new HTTPStatus(410, "Gone");
        public static readonly HTTPStatus LengthRequired = new HTTPStatus(411, "Length Required");
        public static readonly HTTPStatus UnprocessableEntity = new HTTPStatus(422, "Unprocessable Entity");
        public static readonly HTTPStatus Locked = new HTTPStatus(423, "Locked");
        public static readonly HTTPStatus FailedDependency = new HTTPStatus(424, "Failed Dependency");
        public static readonly HTTPStatus TooManyRequests = new HTTPStatus(429, "Too Many Requests");
        public static readonly HTTPStatus UnavailableForLegalReasons = new HTTPStatus(451, "Unavailable For Legal Reasons");

        public static readonly HTTPStatus InternalServerError = new HTTPStatus(500, "Internal Server Error");
        public static readonly HTTPStatus NotImplemented = new HTTPStatus(501, "Not Implemented");
        public static readonly HTTPStatus BadGateway = new HTTPStatus(502, "Bad Gateway");
        public static readonly HTTPStatus ServiceUnavailable = new HTTPStatus(503, "Service Unavailable");
        public static readonly HTTPStatus GatewayTimeout = new HTTPStatus(504, "Gateway Timeout");
        public static readonly HTTPStatus HTTPVersionNotSupported = new HTTPStatus(505, "HTTP Version Not Supported");
        public static readonly HTTPStatus InsufficientStorage = new HTTPStatus(507, "Insufficient Storage");
        public static readonly HTTPStatus LoopDetected = new HTTPStatus(508, "Loop Detected");
        public static readonly HTTPStatus NetworkAuthenticationRequired = new HTTPStatus(511, "Network Authentication Required");

        public int Code { get; private set; }
        public string Message { get; private set; }

        private HTTPStatus(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public override string ToString()
        {
            return $"{Code} {Message}";
        }
    }
}
