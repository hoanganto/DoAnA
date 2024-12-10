using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    [Route("Telegram")]
    public class TelegramController : Controller
    {
        private readonly TelegramService _telegramService;

        public TelegramController(TelegramService telegramService)
        {
            _telegramService = telegramService;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest messageRequest)
        {
            if (string.IsNullOrEmpty(messageRequest?.Message) || string.IsNullOrEmpty(messageRequest?.ChatId))
            {
                return BadRequest("Message or ChatId cannot be empty.");
            }

            var result = await _telegramService.SendMessageAsync(messageRequest.ChatId, messageRequest.Message);

            if (result)
            {
                return Ok("Message sent successfully!");
            }

            return StatusCode(500, "Failed to send the message.");
        }

        public class MessageRequest
        {
            public string ChatId { get; set; }
            public string Message { get; set; }
        }
    }
}
