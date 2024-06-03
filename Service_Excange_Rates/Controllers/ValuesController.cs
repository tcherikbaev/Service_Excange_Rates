using Service_Excange_Rates.Models;
using Service_Excange_Rates.Models.CallingStoredProcedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace Service_Excange_Rates.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        DataAccess access = null;

        public ValuesController()
        {
            access = new DataAccess();
        }
        [Route("api/ExchangeRates")]
        [HttpPost]
        public MainModel Get([FromBody]TestPost value)
        {
            string ot = WebConfigurationManager.AppSettings["operationType"];
            TestModel temp = new TestModel();
            MainModel m = new MainModel();
            m.id = value.id;
            if (value.operationType == ot)
            {

                
                List<TestModel> model = access.GetData();
                m.exchangeRates.AddRange(model);


                //temp.valCode = "USD";
                //temp.buyOrSel = 0;
                //temp.rate = 76.9;
                //temp.rateDt = "15.05.2020  14:17:00";
                //m.id = value.id;
                //m.exchangeRates.Add(temp);
                //m.exchangeRates.Add(new TestModel
                //{
                //    valCode = "USD",
                //    buyOrSel = 1,
                //    rate = 76,
                //    rateDt = "15.05.2020  14:17:00"
                //});
                //m.exchangeRates.Add(new TestModel
                //{
                //    valCode = "EUR",
                //    buyOrSel = 0,
                //    rate = 80,
                //    rateDt = "15.05.2020  14:17:00"
                //});

            }
            else
            {

                //m = new MainModel();
            }
            return m;


        }
    }
}
