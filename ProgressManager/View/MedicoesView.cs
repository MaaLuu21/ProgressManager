using ProgressManager.Entities;
using ProgressManager.View.Utils;
using System;

namespace ProgressManager.View
{
    class MedicoesView
    {
        public static void MostrarMedicoes(List<Medicao> medicoes)
        {
            int largura = 45;
            if (medicoes != null && medicoes.Count > 0)
            {
                Console.WriteLine(" --------------------------------------------");
                Console.WriteLine("|            MEDIÇÕES REGISTRADAS            |");
                Console.WriteLine(" --------------------------------------------");
                foreach (Medicao m in medicoes)
                {
                    Console.WriteLine($"|Data: {m.DataDeRegistro:dd/MM/yyyy}".PadRight(largura) + "|");
                    Console.WriteLine($"|Peso: {m.Peso} kg ".PadRight(largura) + "|");
                    Console.WriteLine($"|Cintura: {m.Cintura} ".PadRight(largura) + "|");
                    Console.WriteLine($"|Quadril: {m.Quadril} ".PadRight(largura) + "|");
                    Console.WriteLine($"|Biceps: {m.Biceps} ".PadRight(largura) + "|");
                    Console.WriteLine($"|Coxa: {m.Coxa} ".PadRight(largura) + "|");
                    Console.WriteLine($"|Panturrilha: {m.Panturrilha} ".PadRight(largura) + "|");
                    Console.WriteLine("|--------------------------------------------");
                }
            }
            else
            {
                ConsoleUtils.MostrarErro("Nenhuma medição registrada!");
            }

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
