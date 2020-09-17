using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaliFiTAPI.Models
{
    public class User
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Introduction { get; set; }
        public string FacebookID { get; set; }
        public string AvatarURL { get; set; }

        public ICollection<Workout> Workouts { get; set; }
        public ICollection<Completed> CompletedTasks { get; set; }
    }
}
