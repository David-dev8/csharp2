using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class TokenCredentials
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}
