namespace ProgressManager.Entities
{
    internal class Progresso
    {
        public double DiferencaPeso { get; set; }
        public double DiferencaCintura { get; set; }
        public double DiferencaQuadril { get; set; }
        public double DiferencaBiceps { get; set; }
        public double DiferencaCoxa { get; set; }
        public double DiferencaPanturrilha { get; set; }

        public Progresso() { }

        public Progresso(double diferencaPeso, double diferancaCintura, double diferencaQuadril, 
            double diferancaBiceps, double diferencaCoxa, double diferencaPanturrilha)
        {
            DiferencaPeso = diferencaPeso;
            DiferencaCintura = diferancaCintura;
            DiferencaQuadril = diferencaQuadril;
            DiferencaBiceps = diferancaBiceps;
            DiferencaCoxa = diferencaCoxa;
            DiferencaPanturrilha = diferencaPanturrilha;
        }
        public override string ToString()
        {
            return "Peso: "
                + DiferencaPeso
                + "\nCintura: "
                + DiferencaCintura
                + "\nQuadril: "
                + DiferencaQuadril
                + "\nBicpes: "
                + DiferencaBiceps
                + "\nCoxa: "
                + DiferencaCoxa
                + "\nPanturrilha: "
                + DiferencaPanturrilha;
        }
    }
}
