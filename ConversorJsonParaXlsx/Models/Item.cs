using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorJsonParaXlsx.Models
{
    public class Item
    {
        public int id { get; set; }
        public string idExterno { get; set; }
        public string contato { get; set; }
        public string observacao { get; set; }
        public string tabelaPrazo { get; set; }
        public int prazo { get; set; }
        public bool ehIsentoDePisCofins { get; set; }
        public string tipoDeFornecedor { get; set; }
        public int prazoDeEntrega { get; set; }
        public string tipoDeFrete { get; set; }
        public bool transportadora { get; set; }
        public bool servico { get; set; }
        public int regimeEstadualTributarioId { get; set; }
        public bool produtorRural { get; set; }
        public string inscricaoEstadual { get; set; }
        public string numeroDoDocumento { get; set; }
        public string numeroDeIdentificacao { get; set; }
        public string orgaoExpedidor { get; set; }
        public string cei { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string nome { get; set; }
        public string fantasia { get; set; }
        public string telefone1 { get; set; }
        public string telefone2 { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string homePage { get; set; }
        public string redeSocial { get; set; }
        public string twitter { get; set; }
        public string comunicadorDeMensagensInstantaneas { get; set; }
        public string suframa { get; set; }
        public string tipoDePessoa { get; set; }
        public string tipoContribuinte { get; set; }
        public int holdingId { get; set; }
        public string tipoAliquotasEspecificas { get; set; }
        public string criadoEm { get; set; }
        public string atualizadoEm { get; set; }
        public Endereco endereco { get; set; }
    }
}
