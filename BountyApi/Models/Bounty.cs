using System.ComponentModel.DataAnnotations;

namespace BountyApi.Models
{
    public class Bounty
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal AliveReward { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal DeadReward { get; set; }

        public bool Captured { get; set; }
    }
}
