using ProgressManager.Entities;
using ProgressManager.Entities.Enums;
using ProgressManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressManager.View
{
    class MenuView // --- editar diagrama de classes
    {
        public static void MenuConsole()
        {
            List<Usuario> usuarios = UsuarioRepository.Carregar();

            while (true)
            {
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
                        Console.Write("Nome:");
                        string nome = Console.ReadLine();
                        Console.Write("Data de nascimento (DD/MM/YYYY): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                        {
                            Console.WriteLine("Data inválida!");
                        }
                        Console.Write("Altura: ");
                        if (!double.TryParse(Console.ReadLine(), out double altura))
                        {
                            Console.WriteLine("Altura inválida!");
                        }
                        Console.WriteLine("Insira o ID com no máximo 6 digitos ex: 154985");
                        Console.Write("ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id) && id <= 6)
                        {
                            Console.WriteLine("ID inválido!");
                        }
                        usuarios.Add(new Usuario());
                        break;
                }
                
            }


        }
    }
}
}
