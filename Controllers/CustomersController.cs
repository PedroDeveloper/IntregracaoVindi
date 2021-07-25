using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using IntegracaoVindi.API.Business;
using IntegracaoVindi.API.Model;
using System.Collections.Generic;

namespace IntegracaoVindi.API.Controllers
{
	[EnableCors("Policy1")]
	[ApiController]
	[Route("api/[controller]")]
	public class CustomersController : ControllerBase
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<CustomersController> _log;
		private readonly IConfiguration _config;

		public CustomersController(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<CustomersController>();
			_config = config;
		}


		[HttpGet]
        public IActionResult Get()
        {
            CustomersBO customersBO;
			List<Customer> customers;
            ObjectResult response;

            try
            {
				customers = new List<Customer>();
                _log.LogInformation("Starting Get()");

                customersBO = new CustomersBO(_loggerFactory, _config);
				customers = customersBO.Get();

                response = Ok(customers);

               _log.LogInformation($"Finishing Get() with '{customers.Count}' results");
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                response = StatusCode(500, ex.Message);
            }

            return response;
        }



        [HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Post([FromBody] Customer customer)
		{
			CustomersBO customersBO;

			try
			{
				_log.LogInformation($"Starting Post('{JsonConvert.SerializeObject(customer, Formatting.None)}')");

				customersBO = new CustomersBO(_loggerFactory, _config);
                if (customer.id == 0)
                {
					customer = customersBO.Insert(customer);
                }
                else
                {
					customer = customersBO.validCustomer(customer.id);

				}

                _log.LogInformation($"Finishing Post");
			
				return Ok(customer);

			}
			catch (Exception exception)
			{
				_log.LogError(exception.Message);
				throw exception ;
			}

		}



	}
}
