using ConversorJsonParaXlsx.Models;
using System.Net.Http.Json;

namespace ConversorJsonParaXlsx.Methods
{
    public class CarregarDadosApiMtd
    {
        internal static async Task CarregarDadosApi(string url, string user, string pass, string router, string save, string nome)
        {
            string apiUrl = url + router;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var token = await GetTokenMtd.GetToken(url, user, pass);
                    if (token != null)
                    {

                        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                        httpClient.DefaultRequestHeaders.Add("Authorization", token);

                        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            Dados retorno = await response.Content.ReadFromJsonAsync<Dados>();
                            Console.WriteLine("Conversor de dados Json em arquivo Xlsx");
                            Console.WriteLine("\nCarregando Arquivo Json");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Convertendo . . .");
                            Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                ConverterMtd.Converter(retorno.items, $"{save}\\{nome}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro na requisição: {ex.Message}");
                                throw ex;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na requisição: {ex.Message}");
                    throw ex;
                }
            }
        }
    }
}
