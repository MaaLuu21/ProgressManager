using ProgressManager.Entities;
using System.Text.Json;
using ProgressManager.Exceptions;

namespace ProgressManager.Repositories
{
    class UsuarioRepository
    {
        private static string caminhoArquivo = "usuario.json";

        public static void Salvar(List <Usuario> usuario)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(usuario, options);
                File.WriteAllText(caminhoArquivo, json);
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
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();

                var usuariosOrdenados = usuarios.Where(u => u.Medicoes != null && u.Medicoes.Any()).
                    OrderByDescending(u => u.Medicoes.Min(m => m.DataDeRegistro)).ToList();

                return usuariosOrdenados;
            }
            return new List<Usuario>();
        }
        
        public static void RemoveUsuario(int id)
        {
            var usuarios = Carregar();
            var usuario = usuarios.Find(u => u.Id == id);

            if (usuario != null)
            {
                usuarios.Remove(usuario);
                Salvar(usuarios);
                Console.WriteLine($"Usuario {usuario.Nome} removido com sucesso!");
            }
            else
            {
                throw new DomainException($"Usuario: {usuario.Nome}, ID: {usuario.Id} não encontrado!");
            }
        }
        public static void AtualizarUsuario (int id, Usuario novosDados)
        {
            var usuarios = Carregar();
            var usuario = usuarios.Find (u => u.Id == id);

            if (usuario != null)
            {
                usuario = novosDados;// TESTAR
                Salvar(usuarios);
                Console.WriteLine($"Usuario {usuario.Nome} atualizado com sucesso!");
            }
            else
            {
                throw new DomainException($"Usuario: {usuario.Nome}, ID: {usuario.Id} não encontrado!");
            }

        }
    }
}
