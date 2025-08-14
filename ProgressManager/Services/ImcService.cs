namespace ProgressManager.Services
{
    class ImcService
    {
        public static double Imc (double peso, double altura)
        {
            return peso / (altura * altura);
        }
    }
}
