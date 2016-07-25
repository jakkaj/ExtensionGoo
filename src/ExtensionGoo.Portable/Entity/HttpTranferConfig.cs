﻿using System.Collections.Generic;

namespace ExtensionGoo.Portable.Entity
{
    public class HttpTransferConfig
    {
        public string Url { get; set; }
        public string Data { get; set; }
        public byte[] ByteData { get; set; }

        public string Verb { get; set; }

        public string BaseUrl { get; set; }

        public string Auth { get; set; }
        public string AuthScheme { get; set; }

        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Cookies { get; set; }

        public string Accept { get; set; }
        public List<string> AcceptEncoding { get; set; }

        public string ContentEncoding { get; set; }

        public bool IsValid { get; set; }

        public bool Gzip { get; set; }

        public bool AllowRedirect { get; set; }
        

        public int Timeout { get; set; }
    }
}
