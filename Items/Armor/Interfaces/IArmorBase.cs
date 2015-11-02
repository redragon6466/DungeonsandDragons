using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Items.Enumerations;

namespace DNDSim.Items.Armor.Interfaces
{
    public interface IArmorBase
    {
        ushort cost { get; }

        byte ArmorBonus { get; }

        byte MaximumDexertiyBonus { get; }

        int ArmorCheckPenalty { get; }

        byte AraneSpellFailureChance { get; }

        bool SpeedReduction { get; }

        ushort Weight { get; }

        ArmorProficienciesEnum ProficiencyRequired { get; }
    }
}
