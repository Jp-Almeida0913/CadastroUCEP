using System.Text.Json;
using System.Text.Json.Serialization;


namespace CadastroUCEP.Class
{
    public class Address
    {
        [JsonPropertyName("cep")]
        public string CEP { get; set; }

        [JsonPropertyName("logradouro")]
        public string Street { get; set; }

        [JsonPropertyName("bairro")]
        public string Neighborhood { get; set; }

        [JsonPropertyName("localidade")]
        public string City { get; set; }

        [JsonPropertyName("uf")]
        public string State { get; set; }


        public override string ToString()
        {
            return $"Cep: {CEP}\nRua: {Street}\nBairro: {Neighborhood}\nCidade: {City}\nEstado: {State}";
        }
    }

    public class AddressService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Address> GetAddress(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var address = JsonSerializer.Deserialize<Address>(responseBody);

                if (address == null || string.IsNullOrEmpty(address.Street)) return null;

                return address;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

    }
}

