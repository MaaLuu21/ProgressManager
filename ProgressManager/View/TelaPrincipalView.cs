using ProgressManager.Entities;
using ProgressManager.Entities.Enums;
using ProgressManager.Exceptions;
using ProgressManager.Repositories;
using ProgressManager.Services;
using ProgressManager.View.Utils;
using System.Globalization;

namespace ProgressManager.View
{
    class TelaPrincipalView // --- editar diagrama de classes
    {
        public void TelaInicial(Usuario usuarioLogado)
        {
            OpcoesMenuPrincipal opcoes;
            bool parseOk = false;
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
                string entrada = Console.ReadLine()?.Trim();

                parseOk = Enum.TryParse(entrada, out opcoes) &&
                          Enum.IsDefined(typeof(OpcoesMenuPrincipal), opcoes);

                if (string.IsNullOrEmpty(entrada))
                {
                    ConsoleUtils.MostrarErro("Opção inválida! Digite apenas os números do menu.");
                    continue;
                }

                if (!parseOk)
                {
                    ConsoleUtils.MostrarErro("Opção inválida! Digite apenas os números do menu.");
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
                                Console.WriteLine("Aperte alguma tecla para voltar ao menu!!");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("Aperte alguma tecla para voltar ao menu!!");
                            Console.ReadKey();
                            break;

                        case OpcoesMenuPrincipal.Progresso:
                            Console.Clear();
                            CalcularProgressoService service = new CalcularProgressoService();

                            if (usuarioLogado.Medicoes != null && usuarioLogado.Medicoes.Count > 0)
                            {
                                Progresso progresso = service.CalcularProgresso(usuarioLogado.Medicoes);
                                Console.WriteLine(progresso);
                            }
                            Console.WriteLine("Aperte alguma tecla para voltar ao menu!!");
                            Console.ReadKey();
                            break;

                        case OpcoesMenuPrincipal.ModificarMedida:
                            Console.Clear();
                            if (medicoes == null || medicoes.Count == 0)
                            {
                                Console.WriteLine("Nenhuma medição registrada ainda!!");
                                Console.WriteLine("Aperte alguma tecla para voltar ao menu!!");
                                Console.ReadKey();
                                break;
                            }
                            DateTime dataModificada = EntradaUtils.LerEntrada(
                                "Digite a data da medição que deseja modificar:",
                                entrada => (DateTime.TryParse(entrada, out var valor), valor));

                            var medicaoAtualizada = LerMedicaoView.LerMedicao();
                            ConsoleUtils.MostrarSucesso(MedicaoService.AtualizarMedicao(dataModificada, medicaoAtualizada, usuarioLogado.Id));

                            break;

                        case OpcoesMenuPrincipal.ModificarUsuario:
                            Console.Clear();

                            string nome = EntradaUtils.LerEntrada(
                                "Nome: ", entrada => (!string.IsNullOrEmpty(entrada), entrada));
                            DateTime dataDeNascimento = EntradaUtils.LerEntrada(
                                "Data de nascimento (DD/MM/YYYY): ", entrada => (DateTime.TryParse(entrada, out var valor), valor));
                            double altura = EntradaUtils.LerEntrada(
                                "Altura: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));
                            usuarioLogado.Nome = nome;
                            usuarioLogado.DataDeNascimento = dataDeNascimento; 
                            usuarioLogado.Altura = altura;

                            ConsoleUtils.MostrarSucesso(UsuarioService.AtualizarUsuario(usuarioLogado.Id, usuarioLogado));

                            break;

                        case OpcoesMenuPrincipal.RemoverMedida:// arrumar para só remover q2uando tiver medida
                            Console.Clear();
                            if (medicoes == null || medicoes.Count > 0)
                            {
                                DateTime dataRemovida = EntradaUtils.LerEntrada(
                                    "Digite a data da medição que deseja remover:",
                                    entrada => (DateTime.TryParse(entrada, out var valor), valor));

                                ConsoleUtils.MostrarSucesso(MedicaoService.RemoverMedicao(dataRemovida, usuarioLogado.Id));
                                usuarioLogado.Medicoes.RemoveAll(m => m.DataDeRegistro.Date == dataRemovida.Date);
                            }
                            else
                            {
                                ConsoleUtils.MostrarErro("Nenhuma medição registrada para remover!");

                            }
                                break;

                        case OpcoesMenuPrincipal.RemoverUsuario:
                            Console.Clear();
                            char removerUsuario = EntradaUtils.LerEntrada(
                                "Deseja remover seu usuário? [s] para remover [n] para cancelar: ", entrada => (!string.IsNullOrWhiteSpace(entrada), entrada.ToLower()[0]));
                            if (removerUsuario == 's')
                            {
                                ConsoleUtils.MostrarSucesso(UsuarioService.RemoverUsuario(usuarioLogado.Id));
                                return;
                            }
                            if (removerUsuario == 'n')
                            {
                                Console.WriteLine("Operação cancelada!");
                                Thread.Sleep(1800);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida! Digite [s] ou [n]");
                            }

                            break;

                        case OpcoesMenuPrincipal.Sair:
                            Console.Clear();
                            return;

                        default:
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

