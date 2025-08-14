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

        public Usuario(string nome, DateTime dataDeNascimento, double altura, int id)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Altura = altura;
            Id = id;
            Medicoes = new List<Medicao>();
        }

        public Usuario(string nome, DateTime dataDeNascimento, double altura, int id, List<Medicao> medicoes)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Altura = altura;
            Id = id;
            Medicoes = medicoes;
        }
    }
}
