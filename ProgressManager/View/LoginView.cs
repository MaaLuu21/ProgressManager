using ProgressManager.Entities;
using ProgressManager.Repositories;
using ProgressManager.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressManager.View
{
    class LoginView
    {
        public static Usuario Login()
        {
            var usuarios = UsuarioRepository.Carregar();
            int id = EntradaUtils.LerEntrada(
                "ID: ", entrada => (int.TryParse(entrada, out var valor), valor));

            var usuario = usuarios.Find(u => u.Id == id);

            if (usuario != null)
            {
                Console.Clear();
                Console.WriteLine($"Bem-vindo(a) {usuario.Nome}!!");
                Thread.Sleep(1500);
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
