using ProgressManager.View;
using System;

namespace ProgressManager
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var menu = new MenuView();
                menu.MenuConsole();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro inesperado: " + e.Message);
            }
        }
    }
}