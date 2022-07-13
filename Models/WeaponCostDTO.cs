namespace AlbionCrafter.Models
{
    public class WeaponCostDTO
    {

        public decimal ReturnRate { get; set; }
        public decimal EmptyJournal { get; set; }
        public decimal FullJournal { get; set; }
        public Dictionary<string, long> Materials { get; set; }
        public Dictionary<string, decimal> WeaponSellPrice { get; set; }
        public List<WeaponStructure> WeaponStructure { get; set; }
    }
}
