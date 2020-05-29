using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCT.API.ViewModel
{
    public class CurrencyModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Fxrate { get; set; }
        public decimal RPI { get; set; }
        public int CountryId { get; set; }
        public string RenewYear { get; set; }

    }
}
