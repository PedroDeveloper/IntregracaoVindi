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
	public class ChargeController : ControllerBase
	{
		private readonly ILoggerFactory _loggerFactory;
		private readonly ILogger<ChargeController> _log;
		private readonly IConfiguration _config;

		public ChargeController(ILoggerFactory loggerFactory, IConfiguration config)
		{
			_loggerFactory = loggerFactory;
			_log = loggerFactory.CreateLogger<ChargeController>();
			_config = config;
		}

		/// <summary>
		/// Retorna Cobranças existentes.
		/// </summary>
		/// <returns>Dados de Cobranças existentes</returns>
		/// <remarks>
		/// Utilize este método para efetuar o estorno (ou cancelamento) de uma cobrança já efetuada com sucesso. É importante observar que não é possível reverter um estorno realizado com sucesso.
		///Após a operação de estorno, a cobrança assumirá status = canceled.O cancelamento da fatura associda é opcional e pode ser informado através da opção cancel_bill no corpo da requisição.
		/// </remarks>

		[EnableCors("Policy1")]
		[HttpGet]
		public IActionResult Get()
		{
			ChargesBO chargesBO;
			List<Charge> charges;
			ObjectResult response;

			try
			{
				charges = new List<Charge>();
				_log.LogInformation("Starting Get()");

				chargesBO = new ChargesBO(_loggerFactory, _config);
				charges = chargesBO.Get();

				response = Ok(charges);

				_log.LogInformation($"Finishing Get() with '{charges.Count}' results");
			}
			catch (Exception ex)
			{
				_log.LogError(ex.Message);
				response = StatusCode(500, ex.Message);
			}

			return response;
		}



		/// <summary>
		/// Retorna Cobrança a partir de um ID .
		/// </summary>
		/// <returns>Dados da Cobrança existente</returns>
		[EnableCors("Policy1")]
		[HttpGet("{id}")]
		public IActionResult GetByID(int id)
		{
			ChargesBO chargesBO;
			Charge charge;
			ObjectResult response;

			try
			{
				charge = new Charge();
				_log.LogInformation("Starting Get()");

				chargesBO = new ChargesBO(_loggerFactory, _config);
				charge = chargesBO.GetByID(id);

				response = Ok(charge);

				_log.LogInformation($"Finishing Get() results");
			}
			catch (Exception ex)
			{
				_log.LogError(ex.Message);
				response = StatusCode(500, ex.Message);
			}

			return response;
		}

		/// <summary>
		/// Estornar uma Cobrança.
		/// </summary>
		/// <returns>Dados da Cobrança cancelada</returns>
		/// <remarks>
		/// Utilize este método para efetuar o estorno (ou cancelamento) de uma cobrança já efetuada com sucesso. É importante observar que não é possível reverter um estorno realizado com sucesso.
		///Após a operação de estorno, a cobrança assumirá status = canceled.O cancelamento da fatura associda é opcional e pode ser informado através da opção cancel_bill no corpo da requisição.
		/// </remarks>



		[HttpPost("{id}/refund")]
		[ProducesResponseType(typeof(Charge),StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Estono([FromBody] ChargeRefund insertRefund,int id)
		{
			ChargesBO chargesBO;
			Charge refund;
			try
			{
				refund = new Charge();
				_log.LogInformation($"Starting Post('{JsonConvert.SerializeObject(insertRefund, Formatting.None)}')");

				chargesBO = new ChargesBO(_loggerFactory, _config);
				refund = chargesBO.RefundBill(insertRefund,id);

				_log.LogInformation($"Finishing Post");

				return Ok(refund);

			}
			catch (Exception exception)
			{
				_log.LogError(exception.Message);
				throw exception;
			}

		}

	}
}
