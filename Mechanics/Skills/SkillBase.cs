using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Mechanics.Enumerations;
using DNDSim.Mechanics.Interfaces;

namespace DNDSim.Mechanics.Skills
{
    public abstract class SkillBase : ISkill
    {
        public ushort checkPenalty
        {
            get;
        }

        public Stats keyAbility
        {
            get;
        }

        public ushort miscellaneousModifier
        {
            get;
        }

        public string name
        {
            get;
        }

        public ushort rank
        {
            get;
        }
    }
}
