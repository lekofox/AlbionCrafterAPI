using AlbionCrafter.Models;

namespace AlbionCrafter.Interfaces
{
    public interface IProfitCalculator
    {
        List<ProfitStructure> GetProfitByWeapon(WeaponCostDTO weaponResultDTOs);
    }
}
