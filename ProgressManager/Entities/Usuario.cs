namespace ProgressManager.Entities
{
    class Usuario
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double Altura { get; set; }
        public int Id { get; set; }
        public List<Medicao> Medicoes { get; set; }

        public Usuario() { }

    }
}
