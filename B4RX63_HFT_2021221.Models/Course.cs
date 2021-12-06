using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Models
{
    //A kutyakiskolai tanfolyamok
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Organizer { get; set; }
        [Required]
        public string Trainer { get; set; }
        [NotMapped]
        public virtual ICollection<Owner> ParticipantOwners { get; set; }
        [NotMapped]
        public virtual ICollection<Dog> ParticipantDogs { get; set; }
        public Course()
        {
            this.ParticipantOwners = new List<Owner>();
            this.ParticipantDogs = new List<Dog>();
        }
    }
}
