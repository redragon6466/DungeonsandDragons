using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Items.Enumerations;

namespace DNDSim.Items.Weapons
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class WeaponAttribute : Attribute
    {
        public WeaponAttribute(byte numberOfDice, byte diceType, int cost, byte criticalThreat, byte critcalMultiple, ushort rangeIncrement, ushort weight, DamageTypeEnum[] damageTypes)
        {
            NumberOfDice = numberOfDice;
            DiceType = diceType;
            Cost = cost;
            CriticalThreat = criticalThreat;
            CriticalMultiple = critcalMultiple;
            RangeIncrement = rangeIncrement;

        }

        public byte NumberOfDice { get; private set; }

        public byte DiceType { get; private set; }

        public int Cost { get; private set; }

        public byte CriticalThreat { get; private set; }

        public byte CriticalMultiple { get; private set; }

        public ushort RangeIncrement { get; private set; }

        public ushort Weight { get; private set; }

        public DamageTypeEnum[] DamageTypes { get; private set; }
    }
}
