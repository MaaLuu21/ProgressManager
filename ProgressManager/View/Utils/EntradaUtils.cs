using ProgressManager.Exceptions;

namespace ProgressManager.View.Utils
{
    class EntradaUtils // --- editar no diagrama de classes
    {
        public static T LerEntrada<T> (string mensagem,Func<string, (bool valido, T valor)> parser)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine()?.Trim();

            var (valido, valor) = parser(entrada);

            if (!valido)
            {
                throw new DomainException(mensagem + " entrada inválida!");
            }

            return valor;
        }
    }
}
