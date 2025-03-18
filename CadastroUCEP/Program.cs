using CadastroUCEP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUCEP
{
    class Program
    {
        public static async Task Main()
        {
            await Commands.NewUser("João Pedro", "joaoalmeida1160@gmail.com", "12345678", "3265082");
        }
    }
}
