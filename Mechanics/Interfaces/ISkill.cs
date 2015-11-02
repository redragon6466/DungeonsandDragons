using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Mechanics.Enumerations;

namespace DNDSim.Mechanics.Interfaces
{
    public interface ISkill
    {
        string name { get; }

        Stats keyAbility { get; }

        ushort rank { get; }

        ushort miscellaneousModifier { get; }

        ushort checkPenalty { get; }
    }
}
