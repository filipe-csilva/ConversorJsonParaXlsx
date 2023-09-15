using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConversorJsonParaXlsx.Models
{
    public class Token
    {
        [JsonPropertyName("accessToken")]
        public String AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public String RefreshToken { get; set; }
    }
}
