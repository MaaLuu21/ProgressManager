using ProgressManager.Entities;
using ProgressManager.Repositories;
using ProgressManager.View;

namespace ProgressManager
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                while (true)
                {
                    List<Usuario> usuarios = UsuarioRepository.Carregar();
                   /* if (usuarios.Count == 0)
                    {
                        Console.WriteLine("Nenhuma pessoas foi cadastrada ainda");
                    }
                    else
                    {
                        foreach (Usuario u in usuarios)
                        {
                            Console.WriteLine("___________________________________________");
                            Console.WriteLine("Nome: "
                                + u.Nome
                                + "\nData: "
                                + u.DataDeNascimento
                                + "\nAltura:"
                                + u.Altura
                                + "\nID: "
                                + u.Id);

                            if (u.Medicoes.Count > 0)
                            {
                                Console.WriteLine("Medicoes:");
                                foreach (var m in u.Medicoes)
                                {
                                    Console.WriteLine(m);// chama ToString() de Medicao
                                }
                            } 
                            else
                            {
                                Console.WriteLine("Nenhuma medição registrada.");
                            }
                        }
                    }
                   */
                    Usuario usuario = TelaInicialView.TelaInicial();
                    TelaPrincipalView telaPrincipal = new TelaPrincipalView();
                    if (usuario != null)
                    {
                        telaPrincipal.TelaPrincipal(usuario);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro inesperado: " + e.Message);
            }
        }
    }
}