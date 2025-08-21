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
                Console.WriteLine(" _________________________");
                Console.WriteLine("|Login    -  [0]          |");
                Console.WriteLine("|Cadastro -  [1]          |");
                Console.WriteLine("|Encerrar -  [2]          |");
                Console.WriteLine(" -------------------------");
                string entrada = Console.ReadLine();
                bool parseOk = Enum.TryParse<OpcoesMenuInicial>(entrada, out OpcoesMenuInicial opcoes);

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
                        Console.Clear();
                        ConsoleUtils.MostrarErro("Opção inválida");
                        break;
                }
            }
        }
    }
}
