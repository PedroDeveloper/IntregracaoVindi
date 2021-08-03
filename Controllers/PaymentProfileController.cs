//using System;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using IntegracaoVindi.API.Business;
//using IntegracaoVindi.API.Model;
//using System.Collections.Generic;

//namespace IntegracaoVindi.API.Controllers
//{
//	[EnableCors("Policy1")]
//	[ApiController]
//	[Route("api/[controller]")]
//	public class PaymentProfileController : ControllerBase
//	{
//		private readonly ILoggerFactory _loggerFactory;
//		private readonly ILogger<PaymentProfileController> _log;
//		private readonly IConfiguration _config;

//		public PaymentProfileController(ILoggerFactory loggerFactory, IConfiguration config)
//		{
//			_loggerFactory = loggerFactory;
//			_log = loggerFactory.CreateLogger<PaymentProfileController>();
//			_config = config;
//		}


//		[HttpGet]
//        public IActionResult Get()
//        {
//            PaymentProfileBO paymentProfileBO;
//			List<PaymentProfile> paymentProfiles;
//            ObjectResult response;

//            try
//            {
//				paymentProfiles = new List<PaymentProfile>();
//                _log.LogInformation("Starting Get()");

//                paymentProfileBO = new PaymentProfileBO(_loggerFactory, _config);
//				paymentProfiles = paymentProfileBO.Get();

//                response = Ok(paymentProfiles);

//               _log.LogInformation($"Finishing Get() with '{paymentProfiles.Count}' results");
//            }
//            catch (Exception ex)
//            {
//                _log.LogError(ex.Message);
//                response = StatusCode(500, ex.Message);
//            }

//            return response;
//        }



//        [HttpPost]
//		[ProducesResponseType(StatusCodes.Status200OK)]
//		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
//		public IActionResult Post([FromBody] InsertPaymentProfile insertPaymentProfile)
//		{
//			PaymentProfileBO paymentProfileBO;

//			PaymentProfile paymentProfile = new PaymentProfile();

//			try
//			{
//				_log.LogInformation($"Starting Post('{JsonConvert.SerializeObject(insertPaymentProfile, Formatting.None)}')");

//				paymentProfileBO = new PaymentProfileBO(_loggerFactory, _config);

//				paymentProfile = paymentProfileBO.Insert(insertPaymentProfile);

//                _log.LogInformation($"Finishing Post");
			
//				return Ok(paymentProfile);

//			}
//			catch (Exception exception)
//			{
//				_log.LogError(exception.Message);
//				throw exception ;
//			}

//		}


//	}
//}
