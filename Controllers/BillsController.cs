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
	public class BillsController : ControllerBase
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<BillsController> _log;
		private readonly IConfiguration _config;

		public BillsController(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<BillsController>();
			_config = config;
		}

		[EnableCors("Policy1")]
		[HttpGet]
        public IActionResult Get()
        {
            BillsBO billsBO;
			List<Bill> bills;
            ObjectResult response;

            try
            {
				bills = new List<Bill>();
                _log.LogInformation("Starting Get()");

                billsBO = new BillsBO(_loggerFactory, _config);
				bills = billsBO.Get();

                response = Ok(bills);

               _log.LogInformation($"Finishing Get() with '{bills.Count}' results");
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                response = StatusCode(500, ex.Message);
            }

            return response;
        }


		[EnableCors("Policy1")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Post([FromBody] InsertBill insertBill)
		{
			BillsBO billsBO;
			Bill bill;
			try
			{
				bill = new Bill();
				_log.LogInformation($"Starting Post('{JsonConvert.SerializeObject(insertBill, Formatting.None)}')");

				billsBO = new BillsBO(_loggerFactory, _config);
					bill = billsBO.Insert(insertBill);

                _log.LogInformation($"Finishing Post");
			
				return Ok(bill);

			}
			catch (Exception exception)
			{
				_log.LogError(exception.Message);
				throw exception ;
			}

		}



	}
}
