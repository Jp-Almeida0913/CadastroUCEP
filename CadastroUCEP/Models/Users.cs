
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroUCEP.Models
{
    public class Users
    {
        public int User_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
