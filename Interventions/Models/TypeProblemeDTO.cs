using System.ComponentModel.DataAnnotations;

namespace Interventions.Models
{
    public class TypeProblemeDTO
    {
        [Key]


        public int Id { get; set; }





        [StringLength(100)]
        public string descriptionTypeProbleme { get; set; }
    }
}
