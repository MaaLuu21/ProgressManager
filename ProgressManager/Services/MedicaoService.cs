using ProgressManager.Entities;
using ProgressManager.Repositories;

namespace ProgressManager.Services
{
    class MedicaoService
    {
        public static string RemoverMedicao(DateTime data, int id)
        {
            bool removido = MedicaoRepository.RemoveMedicao(data, id);

            if (removido)
            {
                return "Medição removida com sucesso!";
            }
            else
            {
                return "Medição não encontrada!";
            }
        }
        public static string AtualizarMedicao(DateTime data, Medicao novosDados, int id)
        {
            bool atualizado = MedicaoRepository.AtualizarMedicao(data, novosDados, id);

            if (atualizado)
            {
                return "Medição atualizada com sucesso!";
            }
            else
            {
                return "Medição não encontrada!";
            }
        }
    }
}
