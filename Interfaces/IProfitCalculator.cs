using AlbionCrafter.Models;

namespace AlbionCrafter.Interfaces
{
    public interface IProfitCalculator
    {
        List<ProfitStructure> CalculateProfit(WeaponCostDTO weaponResultDTOs);
    }
}
