using System.Net.Http.Json;
using System;
using ConversorJsonParaXlsx.Models;
using ClosedXML.Excel;
using ConversorJsonParaXlsx.Screens;

namespace ConversorJsonParaXlsx
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await PrimaryScreen.Show();
        }
    }
}