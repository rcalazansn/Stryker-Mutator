namespace StrykerMutator.Domain
{
    public class Pessoa
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public Pessoa(string nome, int idade)
        {
            Id = Guid.NewGuid();

            Nome = nome;
            Idade = idade;
            
            Validar();
        }

        public bool MaiorDeIdade() => Idade >= 18;
        private void Validar()
        {
            if (string.IsNullOrEmpty(Nome) || Nome.Split(' ').Length < 2)
                throw new Exception("Nome deve ser composto por nome e sobrenome");
        }
    }
}