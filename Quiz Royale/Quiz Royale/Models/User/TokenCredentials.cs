using System.Text.Json.Serialization;

namespace Quiz_Royale.Models.User
{
    /// <summary>
    /// Deze klasse heeft toegang tot het access token van de gebruiker.
    /// </summary>
    public class TokenCredentials
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}
