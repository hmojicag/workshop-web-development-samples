using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Flurl;
using Flurl.Http;
using samplewebapp.Dto;

namespace samplewebapp.Pages {
    public class HelloModel : PageModel {

        public List<Puestos> Puestos = new List<Puestos>();
        
        public void OnGet() {
            
            //Remember to add Nuget: https://www.nuget.org/packages/Flurl.Http/
            //dotnet add package Flurl.Http
            
            string hostname = "<api host>";
            int company = 89;
            string consumerId = "<the consumer id>";
            string apikey = "<the apikey>";

            string token = GetToken(hostname, consumerId, apikey);

            Puestos = hostname
                .AppendPathSegment("puestos")
                .WithHeader("X-Company", company)
                .WithOAuthBearerToken(token)
                .GetJsonAsync<List<Puestos>>()
                .Result;
        }

        private string GetToken(string hostname, string consumerid, string apikey) {

            //POST http://surfingwebapi.azurewebsites.net/api/auth
            //Payload: { consumerId = consumerid, apiKey = apikey }
            var token = hostname
                .AppendPathSegment("auth")
                .PostJsonAsync(new {
                    consumerId = consumerid,
                    apiKey = apikey
                })
                .ReceiveJson<TokenResponse>()
                .Result;

            return token.Token;
        }
        
    }
}