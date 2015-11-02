using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Items.Weapons.Interfaces;
using DNDSim.Items.Enumerations;
using DNDSim.Mechanics;
namespace DNDSim.Items.Weapons
{
    //[WeaponAttribute(1, 10, 50, 19, 2, 0, 8, new DamageTypeEnum[] { DamageTypeEnum.Slashing })]
    public class Greatsword : IGreatsword
    {
        public Greatsword()
        {
            NumberOfDice = 1;
            DiceType = 10;
            Cost = 50;
            CriticalThreat = 19;
            CriticalMultiplier = 2;
            RangeIncrement = 0;
            DamageTypes = new DamageTypeEnum[] { DamageTypeEnum.Slashing };
            WeaponType = WeaponTypeEnum.TwoHandedMelee;
            ProficiencyRequired = WeaponProficienciesEnum.Greatsword;

        }

        public byte NumberOfDice { get;  set; }

        public byte DiceType { get;  set; }

        public int Cost { get;  set; }

        public byte CriticalThreat { get;  set; }

        public byte CriticalMultiplier { get; set; }

        public ushort RangeIncrement { get; set; }

        public ushort Weight { get; private set; }

        public DamageTypeEnum[] DamageTypes { get; set; }

        public WeaponTypeEnum WeaponType { get; set; }

        public WeaponProficienciesEnum ProficiencyRequired { get; }

        public int Damange()
        {
            return Dice.RollTheDice(NumberOfDice, DiceType, 0);
        }
    }
}
