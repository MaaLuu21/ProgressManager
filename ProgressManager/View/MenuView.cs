using ProgressManager.Entities;
using ProgressManager.Entities.Enums;
using ProgressManager.Exceptions;
using ProgressManager.Repositories;
using System.Globalization;

namespace ProgressManager.View
{
    class MenuView // --- editar diagrama de classes
    {
        public  void MenuConsole()
        {
            List<Usuario> usuarios = UsuarioRepository.Carregar();
            List<Medicao> medicoes = new List<Medicao>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" ______________________________________ ");
                Console.WriteLine("|          SELECIONE UMA OPÇÃO         |");
                Console.WriteLine(" -------------------------------------- ");
                Console.WriteLine("| INSERIR UM USUÁRIO - [0]             |");
                Console.WriteLine("| INSERIR MEDIDAS    - [1]             |");
                Console.WriteLine("| CALCULAR IMC       - [2]             |");
                Console.WriteLine("| PROGRESSO          - [3]             |");
                Console.WriteLine("| MODIFICAR MEDIDA   - [4]             |");
                Console.WriteLine("| MODIFICAR USUÁRIO  - [5]             |");
                Console.WriteLine("| REMOVER MEDIDA     - [6]             |");
                Console.WriteLine("| REMOVER USUARIO    - [7]             |");
                Console.WriteLine("| SAIR               - [8]             |");
                Console.WriteLine(" --------------------------------------");
                string entrada = Console.ReadLine();

                bool parseOk = Enum.TryParse<Opcoes>(entrada, out Opcoes opcoes);

                switch (opcoes)
                {
                    case Opcoes.InserirUsuario:
                        Console.Clear();
                        try
                        {
                            string nome = EntradaUtils.LerEntrada(
                                "Nome: ", entrada => (!string.IsNullOrEmpty(entrada), entrada));
                            DateTime dataDeNascimento = EntradaUtils.LerEntrada(
                                "Data de nascimento (DD/MM/YYYY): ", entrada => (DateTime.TryParse(entrada, out var valor), valor));
                            double altura = EntradaUtils.LerEntrada(
                                "Altura: ", entrada => (double.TryParse(entrada, CultureInfo.InvariantCulture, out var valor), valor));

                            Console.WriteLine("Insira o ID com no máximo 6 digitos ex: 154985");
                            int id = EntradaUtils.LerEntrada(
                                "ID: ", entrada => (int.TryParse(entrada, out var valor), valor));

                            Console.WriteLine("Deseja inserir as medições já, ou apenas criar o usuario?");
                            Console.WriteLine("Para inserir as medições digite [0]");
                            Console.WriteLine("Para apenas criar o usuario e voltar ao menu digite [1]");
                            int resp = EntradaUtils.LerEntrada(": ", entrada => (int.TryParse(entrada, out var valor) && valor <= 1, valor));

                            if (resp == 0)
                            {
                                Console.Clear();
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
                                medicoes.Add(new Medicao(dataDeRegistro, peso, cintura, quadril, biceps, coxa, panturrilha));
                                usuarios.Add(new Usuario(nome, dataDeNascimento, altura, id, medicoes));
                            }
                        }
                        catch (DomainException e)
                        {
                            Console.WriteLine("ERROR: " + e.Message);
                            break;
                        }
                        break;
                    case Opcoes.InserirMedidas:

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}

