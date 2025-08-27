using ProgressManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressManager.View
{
    class MostrarImcView
    {
        public static void MostrarImc(double peso, double altura)
        {
            double imc = ImcService.Imc(peso, altura);  
            string indice = ImcService.ImcIndice(peso, altura);

            if (indice.Contains("Peso Normal"))
                Console.ForegroundColor = ConsoleColor.Green;
            else if (indice.Contains("Sobrepeso"))
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"IMC: {imc:F2} - {indice}");
            Console.ResetColor();
        }
    }
}
