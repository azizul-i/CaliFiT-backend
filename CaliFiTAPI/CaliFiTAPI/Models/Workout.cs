using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaliFiTAPI.Models
{
    public class Workout
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public int Duration { get; set; }
        public string Requirements { get; set; }
        public bool AddToLobby { get; set; }
        public int DifficultyLevel { get; set; }
        [Required]
        public int UserID { get; set; }

        public string Description { get; set; }

        public ICollection<Excercise> Excercises { get; set; }

    }
}
