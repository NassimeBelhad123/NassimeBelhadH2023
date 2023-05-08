using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interventions.Entities;


[Table("Problemes")]

public class Probleme
{

    private DateTime _dateProbleme = DateTime.Now;
    [Key]
    public int Id { get; set; }

    [Required]
    
    [MinLength(3)]
    public string prenom { get; set; }

    // ajouter le reste des propriétés

    public DateTime DateProbleme
    {
        get { return _dateProbleme;}
        set { _dateProbleme = value;}
    }

    public string nom { get; set; }

    public string? noTypeProblem { get; set; }

    public string? courriel { get; set; }

    public string? courrielConfirmation { get; set;}

    public string? telephone { get; set; }

    public string notification { get;}

    public string noUnite { get; set; }


}
