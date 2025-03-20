using CadastroUCEP.Class;

namespace CadastroUCEP
{
    class Program
    {
        public static async Task Main()
        {
            //await Commands.NewUser("João Pedro", "joaoalmeida1160@gmail.com");
            await Commands.LoginUser("joaoalmeida1160@gmail.com", "kikokikokiko");
        }
    }
}
