using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Items.Enumerations;
using DNDSim.Characters.Enumerations;

namespace DNDSim.Characters.Classes.Interfaces
{
    public interface IClassBase
    {
        byte hitDie { get; }

        BaseAttackBonusProgressionEnum BaseAttackBonusProgression { get; }

        BaseSaveProgressionEnum FortitudeSaveProgression { get; }

        BaseSaveProgressionEnum ReflexSaveProgression { get; }

        BaseSaveProgressionEnum WillSaveProgression { get; }

        WeaponProficienciesEnum[] WeaponProficiencies { get; }

        ArmorProficienciesEnum[] ArmorProficiencies { get; }

    }
}
