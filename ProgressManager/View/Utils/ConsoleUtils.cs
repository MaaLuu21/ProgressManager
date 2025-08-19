namespace ProgressManager.View.Utils
{
    class ConsoleUtils
    {
        public static void MostrarErro(string mensagem)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERRO: " + mensagem);
            Console.ResetColor();
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        public static void MostrarSucesso(string mensagem)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SUCESSO: " + mensagem);
            Console.ResetColor();
            Thread.Sleep(1800); 
        }
    }
}
