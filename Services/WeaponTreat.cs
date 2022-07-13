using AlbionCrafter.Interfaces;
using AlbionCrafter.Models;

namespace AlbionCrafter.Services
{
    public class WeaponTreat : IWeaponTreat
    {
        public WeaponCostDTO ListWeapons(List<WeaponStructure> weaponStructures)
        {
            var result =  new WeaponCostDTO();
            result.Materials = new Dictionary<string, long>();
            result.WeaponSellPrice = new Dictionary<string, decimal>();

            foreach (var weapon in weaponStructures)
            {
                foreach (var weaponMaterial in weapon.WeaponRecipe)
                {
                    result.Materials.TryAdd(weaponMaterial.Key, 0);
                }

                result.WeaponSellPrice.TryAdd($"{weapon.WeaponName}", 0);
            }

            result.WeaponStructure = weaponStructures;

            return result;
        }
    }
}
