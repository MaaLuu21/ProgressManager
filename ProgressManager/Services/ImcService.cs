namespace ProgressManager.Services
{
    class ImcService
    {
        public double Imc (double altura, double peso)
        {
            return peso * (altura * altura);
        }
    }
}
