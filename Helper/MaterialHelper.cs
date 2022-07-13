using AlbionCrafter.Models;

namespace AlbionCrafter.Helper
{
    public class MaterialHelper
    {
        public static WeaponStructure WeaponStructureConverter(WeaponStructure weaponStructure)
        {
            WeaponStructure result = new WeaponStructure()
            {
                WeaponName = weaponStructure.WeaponName,
                WeaponRecipe = new Dictionary<string, int>()
            };
            

            foreach (var mat in weaponStructure.WeaponRecipe)
            {
                switch (mat.Key)
                {
                    case "1":
                        result.WeaponRecipe.Add("Bar", mat.Value);
                        break;
                    case "2":
                        result.WeaponRecipe.Add("Leather", mat.Value);
                        break;
                    case "3":
                        result.WeaponRecipe.Add("Plank", mat.Value);
                        break;
                    case "4":
                        result.WeaponRecipe.Add("Cloth", mat.Value);
                        break;
                    case "5":
                        result.WeaponRecipe.Add($"{weaponStructure.WeaponName}.Artifact", mat.Value);
                        break;


                }
            }
            
            return result;
        }
    }
}
