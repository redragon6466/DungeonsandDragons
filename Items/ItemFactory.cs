using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Items.Armor.Interfaces;
using DNDSim.Items.Interfaces;
using DNDSim.Items.Potion.Interfaces;
using DNDSim.Items.Weapons.Interfaces;

namespace DNDSim.Items
{
    public static class ItemFactory
    {
        public static void CreateTreasure(int encounterLevel)
        {
            
        }

        public static IArmorBase CreateArmor()
        {
            throw new NotImplementedException();
        }

        public static IPorionBase CreatePotion()
        {
            throw new NotImplementedException();
        }

        public static IWeaponBase CreateWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
