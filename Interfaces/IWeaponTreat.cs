using AlbionCrafter.Helper;
using AlbionCrafter.Models;

namespace AlbionCrafter.Interfaces
{
    public interface IWeaponTreat
    {
        WeaponCostDTO ListWeapons();

        WeaponCostDTO ListWeaponsByCategoryId(GearType gearType);
    }
}
