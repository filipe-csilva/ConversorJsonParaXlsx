namespace ConversorJsonParaXlsx.Screens
{
    public class PrimaryScreen
    {
        public async static Task Show()
        {
            Console.WriteLine("Conversor de dados Json em arquivo Xlsx");

            Console.SetCursorPosition(0, 6);
            Console.Write("Exemplo: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("tal.precisa.com/api");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 2);
            Console.Write("\nDigite a Url da APi: ");
            string url1 = Console.ReadLine();
            string url = "https://" + url1;

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

            await Methods.CarregarDadosApiMtd.CarregarDadosApi(url, user, pass, router, save, nome);

            Console.Clear();

            Console.WriteLine($"Arquivo salvo corretamente em ({save})");
        }
    }
}
