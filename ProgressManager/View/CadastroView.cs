using ProgressManager.Entities;
using ProgressManager.Exceptions;
using ProgressManager.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                usuarios.Add(new Usuario(nome, dataDeNascimento, altura, id));
                UsuarioRepository.Salvar(usuarios);
            }
            catch (DomainException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
