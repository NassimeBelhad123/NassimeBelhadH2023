using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interventions.Entities
{



    [Table("TypesProbleme")]
    public class TypeProbleme
    {
        [Key]


        public int Id { get; set; }





        [StringLength(100)]
        public string descriptionTypeProbleme { get; set; }
    }
}
