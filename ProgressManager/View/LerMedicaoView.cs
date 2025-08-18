using ProgressManager.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressManager.View
{
    class LerMedicaoView
    {
        public static Medicao LerMedicao()
        {
            DateTime dataRegistro = EntradaUtils.LerEntrada(
                 "Data da medição: ", entrada => (DateTime.TryParse(entrada, out var valor), valor));
            double peso = EntradaUtils.LerEntrada(
                 "Peso: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));
            double cintura = EntradaUtils.LerEntrada(
                "Cintura: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));
            double quadril = EntradaUtils.LerEntrada(
                "Quadril: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));
            double biceps = EntradaUtils.LerEntrada(
                "Bíceps: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));
            double coxa = EntradaUtils.LerEntrada(
                "Coxa: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));
            double panturrilha = EntradaUtils.LerEntrada(
                "Panturrilha: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));

            return new Medicao(dataRegistro, peso, cintura, quadril, biceps, coxa, panturrilha);
        }
    }
}
