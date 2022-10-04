namespace AlbionCrafter.Models
{
    public class WeaponCostDTO
    {

        public decimal ReturnRate { get; set; }
        public decimal EmptyJournal { get; set; }
        public decimal FullJournal { get; set; }
        public Dictionary<string, long> Materials { get; set; } = new Dictionary<string, long>();
        public Dictionary<string, decimal> WeaponSellPrice { get; set; } = new Dictionary<string, decimal>();
        public List<WeaponStructure> WeaponStructure { get; set; }
    }
}
