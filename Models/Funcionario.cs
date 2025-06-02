using System.ComponentModel.DataAnnotations;

public class Funcionario : IValidatableObject
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string? Email { get; set; }

    public int EquipeId { get; set; }
    public Equipe? Equipe { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Cargo != null && Cargo.ToLower() == "gerente" && string.IsNullOrWhiteSpace(Email))
        {
            yield return new ValidationResult(
                "Email é obrigatório para o cargo de gerente.",
                new[] { nameof(Email) }
            );
        }
    }
}