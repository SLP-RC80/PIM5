namespace PIMEventosTI.Models
{
    public class Participante : Pessoa
    {
        public string Instituicao { get; private set; }

        public Participante(int id, string nome, string email, string instituicao)
            : base(id, nome, email)
        {
            Instituicao = instituicao;
        }
    }
}
