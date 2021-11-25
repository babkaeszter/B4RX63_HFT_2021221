using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Models
{
    public enum Gender { male, female }
    public class Dog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Gender Sex { get; set; }
        [Required]
        public bool Castrated { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Height { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Owner Owner { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Course Course { get; set; }
    }
}
