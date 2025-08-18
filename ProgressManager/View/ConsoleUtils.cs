namespace ProgressManager.View
{
    class ConsoleUtils
    {
        public static void MostrarErro(string mensagem)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + mensagem);
            Console.ResetColor();
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
