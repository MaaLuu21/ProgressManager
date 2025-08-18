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
            List<Medicao> medicoes = usuarioLogado.Medicoes;
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

                if (!parseOk)
                {
                    
                    
                    continue; // volta para o início do while
                }
                try
                {
                    switch (opcoes)
                    {
                        case OpcoesMenuPrincipal.InserirMedidas:
                            Console.Clear();
                            var medicao = LerMedicaoView.LerMedicao();

                            usuarioLogado.Medicoes.Add(medicao);
                            UsuarioRepository.AtualizarUsuario(usuarioLogado.Id, usuarioLogado);

                            break;

                        case OpcoesMenuPrincipal.CalcularIMC:
                            Console.Clear();
                            var ultimaMedicao = usuarioLogado.Medicoes.LastOrDefault();
                            if (ultimaMedicao != null)
                            {
                                double imc = ImcService.Imc(ultimaMedicao.Peso, usuarioLogado.Altura);
                                Console.WriteLine($"IMC: " + imc.ToString("F2", CultureInfo.InvariantCulture));
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma medição registrada para calcular o IMC!!");
                                Console.WriteLine("Aperte alguma tecla do teclado para voltar ao menu!!");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("Aperte alguma tecla do teclado para voltar ao menu!!");
                            Console.ReadKey();
                            break;

                        case OpcoesMenuPrincipal.Progresso:
                            Console.Clear();
                            CalcularProgressoService service = new CalcularProgressoService();

                            if (medicoes != null && medicoes.Count > 0)
                            {
                                Progresso progresso = service.CalcularProgresso(medicoes);
                                Console.WriteLine(progresso);
                            }
                            Console.WriteLine("Aperte alguma tecla do teclado para voltar ao menu!!");
                            Console.ReadKey();
                            break;

                        case OpcoesMenuPrincipal.ModificarMedida:
                            if (medicoes == null || medicoes.Count == 0)
                            {
                                Console.WriteLine("Nenhuma medição registrada ainda!!");
                                Console.WriteLine("Aperte alguma tecla do teclado para voltar ao menu!!");
                                Console.ReadKey();
                                break;
                            }
                            DateTime dataEscolhida = EntradaUtils.LerEntrada(
                                "Digite a data da medição que deseja modificar:",
                                entrada => (DateTime.TryParse(entrada, out var valor), valor));

                            var medicaoAtualizada = LerMedicaoView.LerMedicao();
                            MedicaoRepository.AtualizarMedicao(medicaoAtualizada.DataDeRegistro, medicaoAtualizada, usuarioLogado.Id);

                            break;

                        case OpcoesMenuPrincipal.Sair:
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (DomainException e)
                {
                    ConsoleUtils.MostrarErro(e.Message);
                    continue;
                }
            }
        }
    }
}

