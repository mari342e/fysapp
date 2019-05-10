using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Handler.Handlers
{
    public static class ClientHttp
    {
        public static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://fysappapi.herokuapp.com/")
        };        
    }
}
