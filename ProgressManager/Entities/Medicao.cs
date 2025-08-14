namespace ProgressManager.Entities
{
    class Medicao
    {
        public DateTime DataDeRegistro { get; set; }
        public double Peso { get; set; }
        public double Cintura { get; set; }
        public double Quadril { get; set; }
        public double Biceps { get; set; }
        public double Coxa { get; set; }
        public double Panturrilha { get; set; }

        public Medicao() { }

        public Medicao(DateTime dataDeRegistro, double peso, double cintura, double quadril, 
            double biceps, double coxa, double panturrilha)
        {
            DataDeRegistro = dataDeRegistro;
            Peso = peso;
            Cintura = cintura;
            Quadril = quadril;
            Biceps = biceps;
            Coxa = coxa;
            Panturrilha = panturrilha;
        }
        public override string ToString()
        {
            return "\n"
                + DataDeRegistro
                + "\n"
                + Peso
                + Cintura
                + Quadril
                + Biceps
                + Coxa
                + Panturrilha;
        }
    }
}
