namespace ProgressManager.Entities
{
    internal class Progresso
    {
        public double DiferencaPeso { get; set; }
        public double DiferancaCintura { get; set; }
        public double DiferencaQuadril { get; set; }
        public double DiferancaBiceps { get; set; }
        public double DiferencaCoxa { get; set; }
        public double DiferencaPanturrilha { get; set; }

        public Progresso() { }

        public Progresso(double diferencaPeso, double diferancaCintura, double diferencaQuadril, 
            double diferancaBiceps, double diferencaCoxa, double diferencaPanturrilha)
        {
            DiferencaPeso = diferencaPeso;
            DiferancaCintura = diferancaCintura;
            DiferencaQuadril = diferencaQuadril;
            DiferancaBiceps = diferancaBiceps;
            DiferencaCoxa = diferencaCoxa;
            DiferencaPanturrilha = diferencaPanturrilha;
        }
    }
}
