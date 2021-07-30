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
	public class CustomersBO
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<CustomersBO> _log;
		private readonly IConfiguration _config;

		public CustomersBO(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<CustomersBO>();
			_config = config;
		}

        #region Change Data

        public Customer validCustomer(long id)
        {
            string result;
            CustomerHolder customerHolder;
            try
            {
                result = ApiHelper.HttpGet("https://app.vindi.com.br/api/v1/customers/"+id);
                customerHolder = JsonConvert.DeserializeObject<CustomerHolder>(result);

                return customerHolder.customer;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public Customer Insert(Customer customer)
        {
            string result;
			string costumerJson;
            CustomerHolder customerHolder;
            try
            {
                costumerJson = Newtonsoft.Json.JsonConvert.SerializeObject(customer);
                result = ApiHelper.HttpPostJson("https://app.vindi.com.br/api/v1/customers", costumerJson);
                customerHolder = JsonConvert.DeserializeObject<CustomerHolder>(result);

                return customerHolder.customer;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


		#endregion

		#region Retrieve Repository


		public Customer Get(int id)
		{
			string result;


			Customer customer = new Customer();
			try
			{
				result = ApiHelper.HttpGet("https://app.vindi.com.br/api/v1/customers/${id}");
				customer = JsonConvert.DeserializeObject<Customer>(result);

				return customer;


			}
			catch (Exception exception)
			{
				throw exception;
			}

		}

		public List<Customer> Get()
		{
			string result;


			List<Customer> customers = new List<Customer>();
			try
			{
				result = ApiHelper.HttpGet("https://app.vindi.com.br/api/v1/customers");
				customers = JsonConvert.DeserializeObject<List<Customer>>(result.Replace("{\"customers\":", "").Replace("}]}", "}]"));

				return customers;


			}
			catch (Exception exception)
			{
				throw exception;
			}

		}


		#endregion
	}

	
}
