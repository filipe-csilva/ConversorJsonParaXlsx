using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorJsonParaXlsx.Models
{
    public class Dados
    {
        public int start { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public List<Item> items { get; set; }

        public String toJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
