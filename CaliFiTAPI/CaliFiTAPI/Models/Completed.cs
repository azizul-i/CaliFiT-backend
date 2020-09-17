using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaliFiTAPI.Models
{
    public class Completed
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompletedID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ExcerciseID { get; set; }
        [Required]
        public int WorkoutID { get; set; }
        public bool ExcerciseComplete { get; set; }
        public int WorkoutComplete { get; set; }
        [Required]
        public DateTime CompletionDate { get; set; }
    }
}
