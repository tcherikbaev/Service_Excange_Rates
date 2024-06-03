using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_Excange_Rates.Models
{
    public class MainModel
    {
        public string id { get; set; }
        public List<TestModel> exchangeRates { get; set; }
        public MainModel()
        {
            exchangeRates = new List<TestModel>();
        }
    }
}