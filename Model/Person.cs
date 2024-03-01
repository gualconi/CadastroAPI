namespace CadastroAPI.Model
{
    public class Person
    {

        public int PersonID { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }

        public Person(int personID, string? nome, string? endereco, string? cidade, string? telefone, string? cpf)
        {
            PersonID = personID;
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Telefone = telefone;
            CPF = cpf;
        }
        public Person()
        {
        }
    }
}
