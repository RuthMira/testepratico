public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string? Email { get; set; }

    public int EquipeId { get; set; }
    public Equipe Equipe { get; set; }
}
