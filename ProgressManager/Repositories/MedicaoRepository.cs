using ProgressManager.Entities;
using ProgressManager.Exceptions;

namespace ProgressManager.Repositories
{
    class MedicaoRepository
    {
        public static void RemoveMedicao(DateTime data, int id)// --- editar no diagrama de classe
        {
            var usuarios = UsuarioRepository.Carregar();
            var usuario = usuarios.Find(u => u.Id == id);

            if(usuario == null)
            {
                throw new DomainException($"ID: {id} não encontrado!");
            }

            var medicao = usuario.Medicoes.Find(m => m.DataDeRegistro == data);

            if (medicao != null)
            {
                usuario.Medicoes.Remove(medicao);
                UsuarioRepository.Salvar(usuarios);
                Console.WriteLine($"Medição da data {data.ToShortDateString()} removida com sucesso!");
            }
            else
            {
                throw new DomainException($"Medição {data.ToShortDateString()} não encontrada!");
            }
        }
        public static void AtualizarMedicao(DateTime data, Medicao novosDados, int id)// --- editar no diagrama de classe Medicao novos dados e ID
        {
            var usuarios = UsuarioRepository.Carregar();
            var usuario = usuarios.Find(u => u.Id == id);

            if (usuario == null)
            {
                throw new DomainException($"ID: {id} não encontrado!");
            }

            var medicao = usuario.Medicoes.Find(m => m.DataDeRegistro.Date == data.Date);

            if (medicao != null)
            {
                medicao.Peso = novosDados.Peso; 
                medicao.Cintura = novosDados.Cintura;
                medicao.Quadril = novosDados.Quadril;
                medicao.Biceps = novosDados.Biceps;
                medicao.Coxa = novosDados.Coxa;
                medicao.Panturrilha = novosDados.Panturrilha;
                UsuarioRepository.Salvar(usuarios);
            }
            else
            {
                throw new DomainException($"Medição {data.ToShortDateString()} não encontrada!");
            }
        }
    }
}
