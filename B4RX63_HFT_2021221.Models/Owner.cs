using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Models
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender Sex { get; set; }
        [Required]
        public int Age { get; set; }
        [NotMapped]
        public virtual ICollection<Dog> Dogs { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [NotMapped]
        public virtual Course Course { get; set; }
        public Owner()
        {
            Dogs = new List<Dog>();
        }
    }
}
