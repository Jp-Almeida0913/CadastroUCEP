using CadastroUCEP.Data;
using CadastroUCEP.Models;


namespace CadastroUCEP.Class
{
    public class Commands
    {

        public static async Task NewUser(string name, string email)
        {
            var context = new AppDbContext();
            string password, hash, cep, number;
            bool stats;

            bool isValid = await VerifyEmail.CheckEmail(email);
            bool exist = context.users.Any(u => u.Email == email);
            var hasPassword = new HashPassword();

            if (!isValid) return;
            if (exist)
            {
                Console.WriteLine("Email já cadastrado!");
                return;
            }

            Console.WriteLine("Crie uma senha (mínimo 12 caracteres --> ");
            password = Console.ReadLine();
            while (password.Length < 12)
            {
                Console.Clear();
                Console.WriteLine("A senha não cumpre os requisitos (menos de 12 caracteres)\n\nCrie uma senha válida ---> ");
                password = Console.ReadLine();
            }
            
            hash = hasPassword.GeneratePassword(password);

            Console.WriteLine("Informe seu CEP --> ");
            cep = Console.ReadLine();

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

            using (context)
            {
                var user = new Users
                {
                    Name = name,
                    Email = email,
                    Password = hash,
                    Cep = cep,
                    Street = address.Street,
                    Number = number,
                    Neighborhood = address.Neighborhood,
                    City = address.City,
                    State = address.State
                };

                context.Add(user);
                await context.SaveChangesAsync();
                Console.WriteLine("Cadastrado no banco de dados com sucesso!");
            }
        }
    }
}