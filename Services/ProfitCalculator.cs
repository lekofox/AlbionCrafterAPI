using AlbionCrafter.Interfaces;
using AlbionCrafter.Models;

namespace AlbionCrafter.Services
{
    public class ProfitCalculator : IProfitCalculator
    {

        public List<ProfitStructure> GetProfitByWeapon(WeaponCostDTO weaponCostDTO)
        {
            return BuildProfitStructure(weaponCostDTO);
        }

       private List<ProfitStructure> BuildProfitStructure(WeaponCostDTO weaponCostDTO)
        {
            var profitStructures = new List<ProfitStructure>();

            foreach (var weapon in weaponCostDTO.WeaponStructure)
            {
                profitStructures.Add(CalculateProfit(weapon, weaponCostDTO));
            }

            return profitStructures;
        }

        private ProfitStructure CalculateProfit(WeaponStructure weapon, WeaponCostDTO weaponCostDTO)
        {
            var profitStructure = new ProfitStructure();

            profitStructure.WeaponName = weapon.WeaponName;
            var sellPrice = weaponCostDTO.WeaponSellPrice[profitStructure.WeaponName];

            foreach (var recipeItem in weapon.WeaponRecipe)

            {
                var itemName = recipeItem.Key;
                var itemQuantity = recipeItem.Value;

                profitStructure.WeaponCost += weaponCostDTO.Materials[itemName] * itemQuantity;
            }

            profitStructure.CraftProfit = sellPrice + (weaponCostDTO.FullJournal * 0.7m) - profitStructure.WeaponCost + (profitStructure.WeaponCost * weaponCostDTO.ReturnRate / 100);

            if (weaponCostDTO.Materials.ContainsKey($"{weapon.WeaponName}.Artifact"))
            {
                profitStructure.CraftProfit -= weaponCostDTO.Materials[$"{weapon.WeaponName}.Artifact"] * weaponCostDTO.ReturnRate / 100;
            }

            return profitStructure;
        }
    }
}
