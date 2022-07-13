using System.ComponentModel;

namespace AlbionCrafter.Helper
{
    public enum GearType
    {
        [Description("Warrior Weapons")]
        WarriorWeapons = 1,
        [Description("Hunter Weapons")]
        HunterWeapons = 2,
        [Description("Mage Weapons")]
        MageWeapons = 3,
        [Description("Warrior Armors")]
        WarriorArmors = 4,
        [Description("Hunter Armors")]
        HunterArmors = 5,
        [Description("Mage Armors")]
        MageArmors = 6,
    }
}
