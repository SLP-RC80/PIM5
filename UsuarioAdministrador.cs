namespace PIMEventosTI.Models
{
    public class UsuarioAdministrador : Pessoa
    {
        public string Cargo { get; private set; }

        public UsuarioAdministrador(int id, string nome, string email, string cargo)
            : base(id, nome, email)
        {
            Cargo = cargo;
        }
    }
}
