using ProgressManager.Entities;
using System.Text.Json;
using ProgressManager.Exceptions;

namespace ProgressManager.Repositories
{
    class UsuarioRepository
    {
        private static string _caminhoArquivo = "usuario.json";

        public static void Salvar(List <Usuario> usuario)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(usuario, options);
                File.WriteAllText(_caminhoArquivo, json);
            }
            catch (IOException e)
            {
                throw new DomainException("Ao salvar o arquivo " + e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new DomainException("Acesso negado: " + e.Message);
            }
            catch (JsonException e)
            {
                throw new DomainException("Erro na serializaçõ do Json: " + e.Message);
            }
        }

        public static List<Usuario> Carregar()
        {
            if (File.Exists(_caminhoArquivo))
            {
                string json = File.ReadAllText(_caminhoArquivo);
                var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();

                var usuariosOrdenados = usuarios.OrderByDescending(u => u.Medicoes != null && u.Medicoes.Any()
                             ? u.Medicoes.Min(m => m.DataDeRegistro)
                             : DateTime.MinValue).ToList();

                return usuariosOrdenados;
            }
            return new List<Usuario>();
        }
        
        public static bool RemoveUsuario(int id)
        {
            var usuarios = Carregar();
            var usuario = usuarios.Find(u => u.Id == id);

            if (usuario != null)
            {
                usuarios.Remove(usuario);
                Salvar(usuarios);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool AtualizarUsuario (int id, Usuario novosDados)
        {
            var usuarios = Carregar();
            var usuario = usuarios.Find (u => u.Id == id);

            if (usuario != null)
            {
                usuario.Nome = novosDados.Nome;
                usuario.DataDeNascimento = novosDados.DataDeNascimento;
                usuario.Altura = novosDados.Altura;
                usuario.Medicoes = novosDados.Medicoes;

                Salvar(usuarios);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
