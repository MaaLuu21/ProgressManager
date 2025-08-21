using ProgressManager.Entities;
using ProgressManager.Exceptions;
using ProgressManager.Repositories;
using ProgressManager.View.Utils;
using System.Globalization;

namespace ProgressManager.View
{
    internal class CadastroView
    {
        public static void Cadastro()
        {
            List<Usuario> usuarios = UsuarioRepository.Carregar();
            try
            {
                string nome = EntradaUtils.LerEntrada(
                    "Nome: ", entrada => (!string.IsNullOrEmpty(entrada), entrada));
                DateTime dataDeNascimento = EntradaUtils.LerEntrada(
                    "Data de nascimento (DD/MM/YYYY): ", entrada => (DateTime.TryParse(entrada, out var valor), valor));
                double altura = EntradaUtils.LerEntrada(
                    "Altura: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));
                Console.WriteLine("Insira o ID com no máximo 6 digitos ex: 154985, ele será seu LOGIN");
                int id = EntradaUtils.LerEntrada(
                    "ID(LOGIN): ", entrada => (int.TryParse(entrada, out var valor), valor));
                if (!usuarios.Any(u => u.Id == id))
                {
                    usuarios.Add(new Usuario(nome, dataDeNascimento, altura, id));
                    UsuarioRepository.Salvar(usuarios);
                }
                else
                {
                    Console.WriteLine("Já existe uma pessoa com esse ID! Tente novamente");
                    return;
                }
            }
            catch (DomainException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
