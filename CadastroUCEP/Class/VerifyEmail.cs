using System.Text.Json;

namespace CadastroUCEP.Class
{
    class VerifyEmail
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiKey = "";

        public static async Task<bool> CheckEmail(string email)
        {
            string url = $"https://api.hunter.io/v2/email-verifier?email={email}&api_key={apiKey}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(responseBody);

                JsonElement root = doc.RootElement;
                string status = root.GetProperty("data").GetProperty("status").GetString();

                return status == "valid";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro na consulta: {e.Message}");
                return false;
            }
        }
    }
}
