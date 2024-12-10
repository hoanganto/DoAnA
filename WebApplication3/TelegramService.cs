using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3
{
    public class TelegramService
    {
        private readonly HttpClient _httpClient;
        private readonly string _botToken;
        private readonly string _apiUrl = "https://api.telegram.org/bot";

        // Khởi tạo với HttpClient và BotToken
        public TelegramService(HttpClient httpClient, string botToken)
        {
            _httpClient = httpClient;
            _botToken = botToken;
        }

        // Phương thức gửi tin nhắn đến Telegram
        public async Task<bool> SendMessageAsync(string chatId, string message)
        {
            var url = $"{_apiUrl}{_botToken}/sendMessage";
            var jsonContent = $"{{\"chat_id\": \"{chatId}\", \"text\": \"{message}\"}}";

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(url, content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
