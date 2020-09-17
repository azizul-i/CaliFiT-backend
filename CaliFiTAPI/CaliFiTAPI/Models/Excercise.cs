using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaliFiTAPI.Models
{
    public class Excercise
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExcerciseID { get; set; }
        [Required]
        public int WorkoutID { get; set; }
        public string ExcerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int RestPeriod { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }


    }
}
