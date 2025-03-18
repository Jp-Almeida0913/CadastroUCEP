using CadastroUCEP.Data;
using CadastroUCEP.Models;


namespace CadastroUCEP.Class
{
    public class Commands
    {

        public static async Task NewUser(string name, string email, string password, string cep)
        {
            string number;
            bool stats;
            bool isValid = await VerifyEmail.CheckEmail(email);

            if (string.IsNullOrWhiteSpace(cep)) return;

            AddressService service = new AddressService();
            Address address = await service.GetAddress(cep);

            if (address == null || string.IsNullOrEmpty(address.Street))
            {
                Console.WriteLine("Invalid ZIP Code!");
                return;
            }

            Console.Write("Informe o número da casa --> ");
            number = Console.ReadLine();

            if (!isValid) return;

            using (var context = new AppDbContext())
            {
                var user = new Users
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    Cep = cep,
                    Street = address.Street,
                    Number = number,
                    Neighborhood = address.Neighborhood,
                    City = address.City,
                    State = address.State
                };

                context.Add(user);
                context.SaveChanges();
                Console.WriteLine("Cadastrado no banco de dados com sucesso!");
            }
        }
    }
}