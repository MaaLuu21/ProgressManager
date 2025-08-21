namespace ProgressManager.Services
{
    class ImcService
    {
        public static double Imc (double peso, double altura)
        {
            return peso / (altura * altura);
        }
        public static string ImcIndice (double peso, double altura)
        {
            double imc = Imc(peso, altura);

            if (imc < 18.5) return "Abaixo do peso!";
            if (imc > 18.5 && imc <= 24.9) return "Peso Normal!";
            if (imc > 24.9 && imc <= 29.9) return "Sobrepeso!";
            if (imc > 29.9 && imc <= 30) return "Obesidade I!";
            if (imc > 30 && imc <= 39.9) return "Obesidade II!";
            return "Obesidade III!";

        }
    }
}
