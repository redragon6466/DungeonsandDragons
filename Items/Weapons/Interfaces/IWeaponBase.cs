using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Items.Enumerations;

namespace DNDSim.Items.Weapons.Interfaces
{

    public interface IWeaponBase
    {
        int Damange();

        byte CriticalMultiplier{get;}

        WeaponTypeEnum WeaponType { get; }

        WeaponProficienciesEnum ProficiencyRequired { get; }
    }
}
