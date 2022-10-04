using AlbionCrafter.Helper;
using AlbionCrafter.Interfaces;
using AlbionCrafter.Models;

namespace AlbionCrafter.Services
{
    public class WeaponTreat : IWeaponTreat
    {

        private readonly IXmlRepository _xmlRepository;

        public WeaponTreat(IXmlRepository xmlRepository)
        {
            _xmlRepository = xmlRepository;
        }

        public WeaponCostDTO ListWeapons()
        {
            var weaponCostDto =  new WeaponCostDTO();
            var weaponStructures = _xmlRepository.ListAllRecipes();

            AddWeaponToWeaponStructure(weaponStructures, weaponCostDto);
           
            return weaponCostDto;
        }

        public WeaponCostDTO ListWeaponsByCategoryId(GearType gearType)
        {
            var weaponCostDto = new WeaponCostDTO();
            var weaponStructures = _xmlRepository.ListRecipesByCategoryId((int)gearType);

            AddWeaponToWeaponStructure(weaponStructures, weaponCostDto);

            return weaponCostDto;
        }

        private void AddWeaponToWeaponStructure(IEnumerable<WeaponStructure> weaponStructures, WeaponCostDTO weaponCostDto)
        {
            foreach( var weapon in weaponStructures)
            {
                AddMaterialToWeapon(weapon, weaponCostDto);
                weaponCostDto.WeaponSellPrice.TryAdd($"{weapon.WeaponName}", 0);
            }
            weaponCostDto.WeaponStructure = weaponStructures.ToList();
        }

        private void AddMaterialToWeapon(WeaponStructure weapon, WeaponCostDTO weaponCostDto)
        {
            foreach( var weaponMaterial in weapon.WeaponRecipe)
            {
                weaponCostDto.Materials.TryAdd(weaponMaterial.Key, 0);
            }
        }

    }
}
