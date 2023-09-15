using System.Net.Http.Json;
using System;
using ConversorJsonParaXlsx.Models;
using ClosedXML.Excel;

namespace ConversorJsonParaXlsx
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Conversor de dados Json em arquivo Xlsx");

            Console.SetCursorPosition(0,6);
            Console.Write("Exemplo: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("tal.precisa.com/api");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 2);
            Console.Write("\nDigite a Url da APi: ");
            string url1 = Console.ReadLine();
            string url = "https://"+url1;

            Console.Clear();

            Console.WriteLine("Conversor de dados Json em arquivo Xlsx");

            Console.Write("\nDigite seu usuário: ");
            string user = Console.ReadLine();

            Console.Write("\nDigite sua senha: ");
            string pass = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Conversor de dados Json em arquivo Xlsx");

            Console.SetCursorPosition(0, 6);
            Console.Write("Exemplo: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("/v1/user/client");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 2);
            Console.Write("\nDigite a rota: ");
            string router = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Conversor de dados Json em arquivo Xlsx");

            Console.SetCursorPosition(0, 6);
            Console.Write("Exemplo: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"C:\Temp");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 2);
            Console.Write("\nDigite a pasta que deseja salvar o arquivo: ");
            string save = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Conversor de dados Json em arquivo Xlsx");

            Console.SetCursorPosition(0, 6);
            Console.Write("Exemplo: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("dados.xlsx");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 2);
            Console.Write("\nDigite um nome para o arquivo: ");
            string nome = Console.ReadLine();

            await CarregarDadosApi(url, user, pass, router, save, nome);

            Console.Clear();

            Console.WriteLine($"Arquivo salvo corretamente em ({save})");
        }

        private static async Task<String> GetToken(string url, string user, string pass)
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

        private static async Task CarregarDadosApi(string url, string user, string pass, string router, string save, string nome)
        {
            string apiUrl = url + router;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var token = await GetToken(url, user, pass);
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
                                converter(retorno.items, $"{save}\\{nome}");
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

        private static void converter(IEnumerable<Item> itens, String path)
        {
            using (var workbook = new XLWorkbook())
            {
                // Add a worksheet
                var worksheet = workbook.Worksheets.Add("Dados");

                // Define the header row
                Type type = (new Item()).GetType();
                var props = type.GetProperties();


                int ascii = 65;
                foreach (var prop in props)
                {
                    worksheet.Cells(((Char)ascii++) + "1").Value = prop.Name;
                }

                // Fill the data
                int row = 2;
                foreach (var item in itens)
                {
                    ascii = 65;
                    foreach (var prop in props)
                    {
                        worksheet.Cells(((Char)ascii++) + row.ToString()).Value = prop.GetValue(item) != null ? prop.GetValue(item).ToString() : null;
                    }

                    row++;
                }

                // Save the Excel package to a file
                workbook.SaveAs(path);

                Console.WriteLine("Excel file created successfully.");
            }
        }
    }
}