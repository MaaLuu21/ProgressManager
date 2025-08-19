using ProgressManager.Entities;
using ProgressManager.Repositories;

namespace ProgressManager.Services
{
    class UsuarioService
    {
        public static string RemoverUsuario (int id)
        {
            bool removido = UsuarioRepository.RemoveUsuario(id);

            if (removido)
            {
                return "Usuario removido com sucesso!";
            }
            else
            {
                return "Usuário não encontrado!";
            }
        }
        public static string AtualizarUsuario(int id, Usuario novosDados)
        {
            bool atualizado = UsuarioRepository.AtualizarUsuario(id, novosDados);

            if (atualizado)
            {
                return "Usuario atualizado com sucesso!";
            }
            else
            {
                return "Usuário não encontrado!";
            }
        }
    }
}
