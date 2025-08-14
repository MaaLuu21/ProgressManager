using ProgressManager.Entities;
using ProgressManager.Entities.Enums;
using ProgressManager.Exceptions;
using ProgressManager.Repositories;
using ProgressManager.Services;
using System.Globalization;

namespace ProgressManager.View
{
    class TelaPrincipalView // --- editar diagrama de classes
    {
        public void TelaInicial(Usuario usuarioLogado)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine(" ______________________________________ ");
                Console.WriteLine("|          SELECIONE UMA OPÇÃO         |");
                Console.WriteLine(" -------------------------------------- ");
                Console.WriteLine("| INSERIR MEDIDAS    - [0]             |");
                Console.WriteLine("| CALCULAR IMC       - [1]             |");
                Console.WriteLine("| PROGRESSO          - [2]             |");
                Console.WriteLine("| MODIFICAR MEDIDA   - [3]             |");
                Console.WriteLine("| MODIFICAR USUÁRIO  - [4]             |");
                Console.WriteLine("| REMOVER MEDIDA     - [5]             |");
                Console.WriteLine("| REMOVER USUARIO    - [6]             |");
                Console.WriteLine("| SAIR               - [7]             |");
                Console.WriteLine(" --------------------------------------");
                string entrada = Console.ReadLine();

                bool parseOk = Enum.TryParse<OpcoesMenuPrincipal>(entrada, out OpcoesMenuPrincipal opcoes);


                switch (opcoes)
                {
                    case OpcoesMenuPrincipal.InserirMedidas:
                        try
                        {
                            DateTime dataDeRegistro = EntradaUtils.LerEntrada(
                                "Data de hoje: ", entrada => (DateTime.TryParse(entrada, out var valor), valor));
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
                            var medicao = new Medicao(dataDeRegistro, peso, cintura, quadril, biceps, coxa, panturrilha);
                            usuarioLogado.Medicoes.Add(medicao);
                            UsuarioRepository.AtualizarUsuario(usuarioLogado.Id, usuarioLogado);
                        }
                        catch (DomainException e)
                        {
                            Console.Clear();
                            Console.WriteLine("ERROR: " + e.Message);
                            Thread.Sleep(5000);
                            break;
                        }
                        break;
                    case OpcoesMenuPrincipal.CalcularIMC:
                        Console.Clear();

                        var ultimaMedicao = usuarioLogado.Medicoes.Last();
                        if (ultimaMedicao != null)
                        {
                            double imc = ImcService.Imc(ultimaMedicao.Peso, usuarioLogado.Altura);
                            Console.WriteLine($"IMC: " + imc.ToString("F2", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma medição registrada para calcular o IMC");
                        }
                        Thread.Sleep(4000);
                        break;
                    case OpcoesMenuPrincipal.Sair:
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}

