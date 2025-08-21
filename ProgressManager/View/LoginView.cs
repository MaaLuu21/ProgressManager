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
            int id = EntradaUtils.LerEntrada(
                "ID: ", entrada => (int.TryParse(entrada, out var valor), valor));

            var usuario = usuarios.Find(u => u.Id == id);

            if (usuario != null)
            {
                Console.Clear();
                Console.WriteLine($"Bem-vindo(a) {usuario.Nome}!!");
                Thread.Sleep(1800);
                return usuario;
            }
            else
            {
                Console.WriteLine("Usuario não foi encontrado!!");
                return null;
            }
        }
    }
}
