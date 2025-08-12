using ProgressManager.Entities;
using ProgressManager.Repositories;

namespace ProgressManager.Services
{
    class CalcularProgressoService : IProgressoService
    {
        public List<Medicao> Medicoes { get; set; }

        public Progresso CalcularProgresso(List<Medicao> medicoes)// --- editar no diagrama de classe
        {
            if(medicoes == null || medicoes.Count < 2)
            {
                return new Progresso();
            }

            var primeira = medicoes.OrderBy(m => m.DataDeRegistro).First();
            var ultima = medicoes.OrderBy(m => m.DataDeRegistro).Last();


            return new Progresso(
                ultima.Peso - primeira.Peso, ultima.Cintura - primeira.Cintura, 
                ultima.Quadril - primeira.Quadril, ultima.Biceps - primeira.Biceps,
                ultima.Coxa - primeira.Coxa, ultima.Panturrilha - primeira.Panturrilha);
        }
    }
}
