using Figgle.Fonts;
using ProgressManager.Entities;
using ProgressManager.Repositories;
using ProgressManager.View.Utils;

namespace ProgressManager.View
{
    class LoginView
    {
        public static Usuario Login()
        {
            Console.Clear();
            var usuarios = UsuarioRepository.Carregar();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite '0' para voltar.");
                Console.Write("ID:");
                string entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    ConsoleUtils.MostrarErro("ID não pode ficar em branco!");
                    continue;
                }

                if (!int.TryParse(entrada, out int id))
                {
                    ConsoleUtils.MostrarErro("ID inválido! Digite apenas números.");
                    continue;
                }

                if (id == 0)
                    return null;

                var usuario = usuarios.Find(u => u.Id == id);

                if (usuario != null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(FiggleFonts.Starwars.Render($"Bem-vindo(a)!!"));
                    Console.ResetColor();
                    Console.ResetColor();
                    Thread.Sleep(1800);
                    return usuario;
                }
                else
                {
                    ConsoleUtils.MostrarErro("Usuário não foi encontrado!!");
                }
            }
        }
    }
}
