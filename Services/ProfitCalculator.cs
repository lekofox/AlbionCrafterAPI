using AlbionCrafter.Interfaces;
using AlbionCrafter.Models;

namespace AlbionCrafter.Services
{
    public class ProfitCalculator : IProfitCalculator
    {
        public List<ProfitStructure> CalculateProfit(WeaponCostDTO weaponCostDTO)
        {
            var result = new List<ProfitStructure>();

            foreach (var weapon in weaponCostDTO.WeaponStructure)
            {
                var profitCalc = new ProfitStructure();


                profitCalc.WeaponName = weapon.WeaponName;

                foreach (var recipeItem in weapon.WeaponRecipe)
                {
                    var itemName = recipeItem.Key;
                    var itemQuantity = recipeItem.Value;

                    profitCalc.WeaponCost += weaponCostDTO.Materials[itemName] * itemQuantity;
                }

                var sellPrice = weaponCostDTO.WeaponSellPrice[profitCalc.WeaponName];

                profitCalc.CraftProfit = sellPrice + (weaponCostDTO.FullJournal * 0.7m) - profitCalc.WeaponCost + (profitCalc.WeaponCost * weaponCostDTO.ReturnRate / 100);

                if (weaponCostDTO.Materials.ContainsKey($"{weapon.WeaponName}.Artifact"))
                {
                    profitCalc.CraftProfit -= weaponCostDTO.Materials[$"{weapon.WeaponName}.Artifact"] * weaponCostDTO.ReturnRate / 100;
                }

                result.Add(profitCalc);
            }

            return result;
        }
    }
}
