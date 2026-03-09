namespace PIMEventosTI.Models
{
    public abstract class Pessoa
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }

        protected Pessoa(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
