using AlbionCrafter.Models;

namespace AlbionCrafter.Interfaces
{
    public interface IWeaponTreat
    {
        WeaponCostDTO ListWeapons(List<WeaponStructure> weaponStructures);
    }
}
