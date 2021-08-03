using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using IntegracaoVindi.API.Data.Repository;
using IntegracaoVindi.API.Model;
using IntregracaoVindi.API.Helpers;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntegracaoVindi.API.Business
{
	public class BillsBO
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<BillsBO> _log;
		private readonly IConfiguration _config;

		public BillsBO(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<BillsBO>();
			_config = config;
		}

        #region Change Data

        public Bill Insert(InsertBill bill)
        {
            string result;
            BillHolder billHolderr;


            try
            {
                var profileJson = Newtonsoft.Json.JsonConvert.SerializeObject(bill);
                result = ApiHelper.HttpPostJson("https://app.vindi.com.br/api/v1/bills", profileJson);
                billHolderr = JsonConvert.DeserializeObject<BillHolder>(result);

                return billHolderr.bill;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public Charge RefundBill(ChargeRefund insertRefund,int id)
        {
            string result;
            Charge refund;


            try
            {
                refund = new Charge();
                var profileJson = Newtonsoft.Json.JsonConvert.SerializeObject(insertRefund);
                result = ApiHelper.HttpPostJson($"https://app.vindi.com.br/api/v1/charges/{id}/refund", profileJson);
                refund = JsonConvert.DeserializeObject<Charge>(result);

                return refund;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        #endregion

        #region Retrieve Repository


        public List<Bill> Get()	
		{
			string result;


			List<Bill> paymentProfiles = new List<Bill>();
			try
			{
				result = ApiHelper.HttpGet("https://app.vindi.com.br/api/v1/bills");
				paymentProfiles = JsonConvert.DeserializeObject<List<Bill>>(result.Replace("{\"bills\":", "").Replace("condition\":null}]}", "condition\":null}]"));

				return paymentProfiles;


			}
			catch (Exception exception)
			{
				throw exception;
			}

		}


		#endregion
	}

	
}
