namespace BountyApi.Models
{
    public class Bounty
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AliveReward { get; set; }
        public decimal DeadReward { get; set; }
        public bool Captured { get; set; }
    }
}
