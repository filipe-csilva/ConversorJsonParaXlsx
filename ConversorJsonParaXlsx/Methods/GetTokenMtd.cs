using ConversorJsonParaXlsx.Models;
using System.Net.Http.Json;

namespace ConversorJsonParaXlsx.Methods
{
    public class GetTokenMtd
    {
        internal static async Task<String> GetToken(string url, string user, string pass)
        {
            string apiUrl = url + "/auth";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                //autenticação

                HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUrl, new { username = user, password = pass });

                if (response.IsSuccessStatusCode)
                {
                    Token acesstoken = await response.Content.ReadFromJsonAsync<Token>();
                    //return acesstoken != null ? acesstoken.AccessToken : null;
                    return acesstoken?.AccessToken;
                }
                else
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}
