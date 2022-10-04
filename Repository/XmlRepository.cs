using System.Runtime.InteropServices;
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
            List<WeaponStructure> weaponsStructure = new List<WeaponStructure>();

            
            List<WeaponStructure> treatedQuery = GetWeaponsStructure(data);

            AddMaterialTypeAndValueToStructure(treatedQuery, weaponsStructure);

            return weaponsStructure;
        }

        public List<WeaponStructure> ListRecipesByCategoryId(int categoryId)
        {
            XDocument data = XDocument.Load("DB/db.xml");
            List<WeaponStructure> weaponsStructure = new List<WeaponStructure>();

            List<WeaponStructure> treatedQuery = GetWeaponsStructure(data, categoryId);

            AddMaterialTypeAndValueToStructure(treatedQuery, weaponsStructure);

            return weaponsStructure;
        }

        private List<WeaponStructure> GetWeaponsStructure(XDocument data)
        {
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

            return query.ToList();
        }  
        
        private List<WeaponStructure> GetWeaponsStructure(XDocument data, int categoryId)
        {
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

            return query.ToList();
        }

        private void AddMaterialTypeAndValueToStructure(List<WeaponStructure> rawWeaponStructures, List<WeaponStructure> treatedWeaponStructures)
        {
            foreach (WeaponStructure weapon in rawWeaponStructures)
            {
                treatedWeaponStructures.Add(MaterialHelper.WeaponStructureConverter(weapon));
            }
        }
    }
}
