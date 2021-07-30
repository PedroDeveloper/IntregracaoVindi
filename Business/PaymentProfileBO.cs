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
	public class PaymentProfileBO
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<PaymentProfileBO> _log;
		private readonly IConfiguration _config;

		public PaymentProfileBO(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<PaymentProfileBO>();
			_config = config;
		}

		#region Change Data

		public PaymentProfile Insert (InsertPaymentProfile insertPaymentProfile)
		{
			string result;
			string profileJson;
			PaymentProfile paymentProfile;


			try
			{
				
				profileJson =  Newtonsoft.Json.JsonConvert.SerializeObject(insertPaymentProfile);
				result = ApiHelper.HttpPostJson("https://app.vindi.com.br/api/v1/payment_profiles", profileJson);
				paymentProfile = JsonConvert.DeserializeObject<PaymentProfile>(result.Replace("{\"payment_profile\":","").Replace("}}}", "}}"));

				return paymentProfile;
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}


		#endregion

		#region Retrieve Repository


		public List<PaymentProfile> Get()
		{
			string result;


			List<PaymentProfile> paymentProfiles = new List<PaymentProfile>();
			try
			{
				result = ApiHelper.HttpGet("https://app.vindi.com.br/api/v1/payment_profiles");
				paymentProfiles = JsonConvert.DeserializeObject<List<PaymentProfile>>(result.Replace("{\"payment_profiles\":", "").Replace("}}]}", "}}]"));

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
