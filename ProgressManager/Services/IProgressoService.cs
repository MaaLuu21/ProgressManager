using ProgressManager.Entities;

namespace ProgressManager.Services
{
    interface IProgressoService
    {
        Progresso CalcularProgresso(List<Medicao> medicoes); // --- Editar diagrama de classe
    }
}
