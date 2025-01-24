using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController:ControllerBase
    {
        private readonly FlutterWaveSettings _flutterWaveSettings;

        public PaymentsController(IOptions<FlutterWaveSettings> flutterWave)
        {
            _flutterWaveSettings = flutterWave.Value;
        }

        [HttpPost("initialize")]
        public async Task<IActionResult> InitializePayment([FromBody] PaymentRequest request)
        {
            var client = new RestClient("https://api.flutterwave.com/v3/payments");
            var restRequest = new RestRequest("",Method.Post);
            restRequest.AddHeader("Authorization", $"Bearer {_flutterWaveSettings.SecretKey}");
            restRequest.AddHeader("Content-Type", "application/json");

            restRequest.AddJsonBody(new 
            {
                tx_ref = $"tx-{Guid.NewGuid()}",
                amount = request.Amount,
                currency = request.Currency,
                redirect_url = "https://app.com/payment/callback",
                payment_options = "card,banktransfer,ussd",
                customer = new
                {
                    email = request.Email,
                    phoneNumber = request.PhoneNumber,
                    name = request.FullName
                }
            });
            var response = await client.ExecuteAsync(restRequest);
            return Ok(response.Content);
        }

        [HttpGet]
        public async Task<IActionResult> VerifyPayment([FromQuery] string transaction_id)
        {
            var client = new RestClient($"https://api.flutterwave.come/v3/transactions/{transaction_id}/verify");
            var request = new RestRequest("",Method.Get);
            request.AddHeader("Authorization", $"Bearer {_flutterWaveSettings.SecretKey}");

            var response = await client.ExecuteAsync(request);
            return Ok(response.Content);
        }
    }
}