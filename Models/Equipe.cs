public class Equipe
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Setor { get; set; }
    
    public ICollection<Funcionario> Funcionarios { get; set; }
}
