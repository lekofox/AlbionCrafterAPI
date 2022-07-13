using System.Xml.Linq;
using AlbionCrafter.Helper;
using AlbionCrafter.Interfaces;
using AlbionCrafter.Models;

namespace AlbionCrafter.Repository
{
    public class XmlRepository : IXmlRepository
    {
        public List<WeaponStructure> ListAllRecipes()
        {
            XDocument data = XDocument.Load("DB/db.xml");
            var query = from node in data.Descendants("root").Descendants("Gear")
                        select new WeaponStructure
                        {
                            WeaponName = node.Descendants("equipment").Elements("equipment_name").First().Value,
                            WeaponRecipe = node.Descendants("recipes").First().Elements().ToDictionary
                            (
                                e => e.Elements("material_id").First().Value.ToString(),
                                e => Convert.ToInt32(e.Elements("material_quantity").First().Value)
                            )
                        };
            var treatedQuery = query.ToList();
            var result = new List<WeaponStructure>();

            foreach (WeaponStructure weapon in treatedQuery)
            {
                result.Add(MaterialHelper.WeaponStructureConverter(weapon));
            }

            return result;
        }

        public List<WeaponStructure> ListRecipesByCategoryId(int categoryId)
        {
            XDocument data = XDocument.Load("DB/db.xml");
            var query = from node in data.Descendants("root").Descendants("Gear")
                        where (int)node.Elements("category").Elements("id").First() == categoryId
                        select new WeaponStructure
                        {
                            WeaponName = node.Descendants("equipment").Elements("equipment_name").First().Value,
                            WeaponRecipe = node.Descendants("recipes").First().Elements().ToDictionary
                            (
                                e => e.Elements("material_id").First().Value.ToString(),
                                e => Convert.ToInt32(e.Elements("material_quantity").First().Value)
                            )
                        };
            var treatedQuery = query.ToList();
            var result = new List<WeaponStructure>();

            foreach (WeaponStructure weapon in treatedQuery)
            {
                result.Add(MaterialHelper.WeaponStructureConverter(weapon));
            }
            return result;
        }
    }
}
