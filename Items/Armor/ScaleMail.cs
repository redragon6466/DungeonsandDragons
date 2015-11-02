using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Items.Armor.Interfaces;
using DNDSim.Items.Enumerations;

namespace DNDSim.Items.Armor
{
    public class ScaleMail : IScaleMail
    {
        public byte AraneSpellFailureChance
        {
            get
            {
                return 15;
            }
        }

        public byte ArmorBonus
        {
            get
            {
                return 4;
            }
        }

        public int ArmorCheckPenalty
        {
            get
            {
                return -4;
            }
        }

        public ushort cost
        {
            get
            {
                return 50;
            }
        }

        public byte MaximumDexertiyBonus
        {
            get
            {
                return 3;
            }
        }

        public ArmorProficienciesEnum ProficiencyRequired
        {
            get
            {
                return ArmorProficienciesEnum.Medium;
            }
        }

        public bool SpeedReduction
        {
            get
            {
                return true;
            }
        }

        public ushort Weight
        {
            get
            {
                return 30;
            }
        }
    }
}
