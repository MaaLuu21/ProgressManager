using ProgressManager.Entities;
using ProgressManager.Exceptions;

namespace ProgressManager.Repositories
{
    class MedicaoRepository
    {
        public static bool RemoveMedicao(DateTime data, int id)// --- editar no diagrama de classe
        {
            var usuarios = UsuarioRepository.Carregar();
            var usuario = usuarios.Find(u => u.Id == id);

            var medicao = usuario.Medicoes.Find(m => m.DataDeRegistro.Date == data.Date);

            if (medicao != null || usuario.Medicoes.Count > 0)
            {
                usuario.Medicoes.Remove(medicao);
                UsuarioRepository.Salvar(usuarios);

                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool AtualizarMedicao(DateTime data, Medicao novosDados, int id)// --- editar no diagrama de classe Medicao novos dados e ID
        {
            var usuarios = UsuarioRepository.Carregar();
            var usuario = usuarios.Find(u => u.Id == id);

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
                return true;    
            }
            else
            {
                return false;
            }
        }
    }
}
