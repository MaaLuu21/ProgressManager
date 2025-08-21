using ProgressManager.Entities;
using ProgressManager.View.Utils;
using System.Globalization;

namespace ProgressManager.View
{
    class LerMedicaoView
    {
        public static Medicao LerMedicao()
        {
            DateTime dataRegistro = EntradaUtils.LerEntrada(
                 "Data da medição: ", entrada => (DateTime.TryParse(entrada, out var valor), valor));
            double peso = EntradaUtils.LerEntrada(
                 "Peso: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor) && valor > 0, valor));
            double cintura = EntradaUtils.LerEntrada(
                "Cintura: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor) && valor > 0, valor));
            double quadril = EntradaUtils.LerEntrada(
                "Quadril: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor) && valor > 0, valor));
            double biceps = EntradaUtils.LerEntrada(
                "Bíceps: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor) && valor > 0, valor));
            double coxa = EntradaUtils.LerEntrada(
                "Coxa: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor) && valor > 0, valor));
            double panturrilha = EntradaUtils.LerEntrada(
                "Panturrilha: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor) && valor > 0, valor));

            return new Medicao(dataRegistro, peso, cintura, quadril, biceps, coxa, panturrilha);
        }
    }
}
