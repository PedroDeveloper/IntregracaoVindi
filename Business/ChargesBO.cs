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
	public class ChargesBO
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<ChargesBO> _log;
		private readonly IConfiguration _config;

		public ChargesBO(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<ChargesBO>();
			_config = config;
		}

        #region Change Data
        
        public Charge RefundBill(ChargeRefund insertRefund,int id)
        {
            string result;
            ChargeHolder chargeHolder;


            try
            {
				chargeHolder = new ChargeHolder();
                var profileJson = Newtonsoft.Json.JsonConvert.SerializeObject(insertRefund);
                result = ApiHelper.HttpPostJson($"https://app.vindi.com.br/api/v1/charges/{id}/refund", profileJson);
				chargeHolder = JsonConvert.DeserializeObject<ChargeHolder>(result);

                return chargeHolder.charge;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        #endregion

        #region Retrieve Repository


        public List<Charge> Get()	
		{
			string result;


			List<Charge> charges = new List<Charge>();
			try
			{
				result = ApiHelper.HttpGet("https://app.vindi.com.br/api/v1/charges");
				charges = JsonConvert.DeserializeObject<List<Charge>>(result.Replace("{\"charges\":", "").Replace("}}]}", "}}]"));

				return charges;


			}
			catch (Exception exception)
			{
				throw exception;
			}

		}
		public Charge GetByID(int id)
		{
			string result;
			Charge charge;
			ChargeHolder chargeHolder;
			try
			{
				chargeHolder = new ChargeHolder();
				charge = new Charge();

				result = ApiHelper.HttpGet($"https://app.vindi.com.br/api/v1/charges/{id}");
				chargeHolder = JsonConvert.DeserializeObject<ChargeHolder>(result);

				return chargeHolder.charge;


			}
			catch (Exception exception)
			{
				throw exception;
			}
			

		}


		#endregion
	}

	
}
