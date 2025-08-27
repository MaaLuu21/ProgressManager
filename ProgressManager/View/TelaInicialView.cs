using ProgressManager.Entities.Enums;
using ProgressManager.Entities;
using ProgressManager.View.Utils;

namespace ProgressManager.View
{
    internal class TelaInicialView
    {
        public static Usuario TelaInicial()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" _________________________");
                Console.WriteLine("|Login    -  [0]          |");
                Console.WriteLine("|Cadastro -  [1]          |");
                Console.WriteLine("|Encerrar -  [2]          |");
                Console.WriteLine(" -------------------------");
                string entrada = Console.ReadLine()?.Trim();
                bool parseOk = Enum.TryParse<OpcoesMenuInicial>(entrada, out OpcoesMenuInicial opcoes);


                if (string.IsNullOrEmpty(entrada))
                {
                    ConsoleUtils.MostrarErro("Opção inválida! Digite apenas os números do menu.");
                    continue;
                }

                parseOk = Enum.TryParse(entrada, out opcoes) &&
                        Enum.IsDefined(typeof(OpcoesMenuInicial), opcoes);

                if (!parseOk)
                {
                    ConsoleUtils.MostrarErro("Opção inválida! Digite apenas os números do menu.");
                    continue;
                }

                switch (opcoes)
                {
                    case OpcoesMenuInicial.Login:
                        var usuarioLogado = LoginView.Login();
                        if (usuarioLogado != null)
                        {
                            return usuarioLogado;
                        }
                        break;

                    case OpcoesMenuInicial.Cadastro:
                        CadastroView.Cadastro();
                        break;

                    case OpcoesMenuInicial.Encerrar:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
