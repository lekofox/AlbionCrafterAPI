using AlbionCrafter.Models;

namespace AlbionCrafter.Interfaces
{
    public interface IXmlRepository
    {

        public List<WeaponStructure> ListAllRecipes();

        public List<WeaponStructure> ListRecipesByCategoryId(int categoryId);
    }
}
